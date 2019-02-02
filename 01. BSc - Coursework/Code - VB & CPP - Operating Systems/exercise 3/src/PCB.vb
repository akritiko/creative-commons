Public Class PCB
    Implements ICloneable
    Implements IComparer

    Private _pid As Integer
    Protected _timeframes() As Stack
    Private _priority As Integer
    Public Event IORequest(ByVal O As PCB)
    Public Event CPURequest(ByVal O As PCB)
    Public Event Suspended(ByVal O As PCB)

    Public Sub New(ByVal LIOC As Integer, ByVal HIOC As Integer, ByVal LIOD As Integer, ByVal HIOD As Integer, ByVal LCPUD As Integer, ByVal HCPUD As Integer, ByVal LCP As Integer, ByVal HCP As Integer)
        '{Low,High}Input Output{Count,Duration},{Low,High}CPU Duration,{Low,High}Cylinder Position
        ReDim _timeframes(1)
        For i As Integer = 0 To _timeframes.GetUpperBound(0)
            _timeframes(i) = New Stack
        Next
        _timeframes(0).Push(Randomizer.Generate(LCPUD, HCPUD))
        'σύμβαση 0 = cpu, 1 = io
        For i As Integer = 0 To Randomizer.Generate(LIOC, HIOC) - 1
            _timeframes(0).Push(Randomizer.Generate(LCPUD, HCPUD))
            _timeframes(1).Push(New Integer() {Randomizer.Generate(LIOD, HIOD), Randomizer.Generate(LCP, HCP)})
        Next

        _pid = ProcessServices.AllocatePID
        _priority = Randomizer.Generate(0, 13)

        Console.WriteLine(_time & "# Δημιουργήθηκε νεο pcb " & _pid & " προτεραιότητας " & PriorityClass & "[" & _priority & "]")

    End Sub

    Protected Sub New(ByVal Timeframes As Stack(), ByVal Pid As Integer, ByVal Priority As Integer)
        ReDim _timeframes(1)
        _timeframes(0) = Timeframes(0).Clone
        _timeframes(1) = Timeframes(1).Clone
        _pid = Pid
        _priority = Priority
    End Sub

    Public Sub DoTime(ByVal Type As Integer)
        'μείωση του εναπομείναντος χρόνου
        If Type = 0 Then
            If _timeframes(Type).Count = 0 Or _timeframes(Type).Peek = 0 Then Throw New Exception("Η τρέχουσα διεργασία [" & _pid & "] έχει ολοκληρώσει την εργασία της στην ΚΜΕ")
            _timeframes(Type).Push(_timeframes(Type).Pop - 1)
        Else
            If _timeframes(Type).Count = 0 Or _timeframes(Type).Peek(0) = 0 Then Throw New Exception("Η τρέχουσα διεργασία [" & _pid & "] έχει ολοκληρώσει την εργασία της στο Δίσκο")
            Reactor.Push(_timeframes(Type).Pop)
            _timeframes(1).Push(New Integer() {Reactor.Peek(0) - 1, Reactor.Pop(1)})
        End If


        If IsFinished(Type) Then
            If Type = 0 Then
                RaiseEvent IORequest(Me)
            Else 'type = 1
                RaiseEvent CPURequest(Me)
            End If
        End If
    End Sub

    Public Sub Dump()
        Console.Write(_time & "# PCB pid:" & _pid & " περιέχει: C" & _timeframes(0).Pop & ", ")
        For i As Integer = 1 To _timeframes(1).Count
            Console.Write("D{" & _timeframes(1).Peek(0) & "," & _timeframes(1).Pop(1) & "}, ")
            Console.Write("C" & _timeframes(0).Pop & ", ")
        Next
        Console.WriteLine()

    End Sub

    Public Function Clone() Implements ICloneable.clone
        Return New PCB(_timeframes, _pid, _priority)

    End Function

    'Public ReadOnly Property IsDead() As Boolean
    '    Get
    '        Return _timeframes(0).Count = 0 And _timeframes(1).Count = 0
    '    End Get
    'End Property

    Public ReadOnly Property DSKDone() As Boolean
        Get
            Return _timeframes(1).Count = 0
        End Get
    End Property

    Public ReadOnly Property CPUDone() As Boolean
        Get
            Return _timeframes(0).Count = 0
        End Get
    End Property

    Public ReadOnly Property IsFinished(ByVal Type As Integer) As Boolean
        Get
            If Type = 0 Then
                Return _timeframes(Type).Peek = 0
            Else
                Return _timeframes(Type).Peek(0) = 0
            End If

        End Get
    End Property

    Public ReadOnly Property Priority() As Integer
        Get
            Return _priority
        End Get
    End Property

    Public ReadOnly Property PID() As Integer
        Get
            Return _pid
        End Get
    End Property

    Public ReadOnly Property RemainingTimeCPU() As Integer
        Get
            Return _timeframes(0).Peek
        End Get
    End Property

    Public ReadOnly Property RemainingTimeDSK() As Integer
        Get
            Return _timeframes(1).Peek(0)
        End Get
    End Property

    Public Sub Forfeit(ByVal Type As Integer)
        _timeframes(Type).Pop()
    End Sub

    Public ReadOnly Property PriorityClass() As String
        Get
            If _priority <= 6 Then Return "kernel"
            Return "user"
        End Get
    End Property

    Public ReadOnly Property RequestedCylinder() As Integer
        Get
            If _timeframes(1).Count = 0 Then Return -1
            Return _timeframes(1).Peek(1)
        End Get
    End Property

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        If CType(x, PCB).RequestedCylinder < CType(y, PCB).RequestedCylinder Then Return -1
        If CType(x, PCB).RequestedCylinder > CType(y, PCB).RequestedCylinder Then Return 1
        Return 0
    End Function

    Public Sub Suspend()
        RaiseEvent Suspended(Me)
    End Sub
End Class
