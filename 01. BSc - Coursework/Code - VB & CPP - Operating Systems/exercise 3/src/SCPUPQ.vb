'������������ ����������� �� ����� ��������������
Class SCPUPQ
    Implements IResource

    Private _priorities() As Queue
    Private _current As PCB
    Private _timerunning As Integer = 0
    Private _immigrant As PCB
    Private _nop As Boolean
    Private QUANTUM As Integer
    Public Event ImmigrationRequest(ByVal O As PCB) Implements IResource.ImmigrationRequest

    Sub New(ByVal Q As Integer)
        QUANTUM = Q
        ReDim _priorities(13)
        For i As Integer = 0 To _priorities.GetUpperBound(0)
            _priorities(i) = New Queue
        Next

    End Sub

    Public Sub Load()
        For i As Integer = 0 To _priorities.GetUpperBound(0)
            If _priorities(i).Count <> 0 Then
                If Not _current Is Nothing AndAlso _current.Priority <= i Then _
                    Throw New Exception("������������ � ������� ���������� �� ���������� �������������")

                _nop = False
                _current = _priorities(i).Dequeue
                _timerunning = 0
                AddHandler _current.IORequest, AddressOf UnLoad
                AddHandler _current.Suspended, AddressOf UnLoad
                Console.WriteLine(_time & "# ��������� ��� �������� ���� ����������� �� pcb " & _current.PID)
                Return
            End If
        Next
        _nop = True
    End Sub

    Public Sub UnLoad(Optional ByVal Applicant As PCB = Nothing)
        If _current Is Nothing Then Throw New Exception("������������ ��������� ����� �������� ���������")
        If Not Applicant Is Nothing Then
            If Not _current Is Applicant Then Throw New Exception("������ ������������")
            RemoveHandler _current.IORequest, AddressOf UnLoad
            RemoveHandler _current.Suspended, AddressOf UnLoad
        End If

        If _current.IsFinished(0) Then '�� �������� ��� �����������
            _immigrant = _current
            _current.Forfeit(0)
            _current = Nothing
            RaiseEvent ImmigrationRequest(_immigrant)
        Else '� �� �������� � ����������� ������
            _priorities(_current.Priority).Enqueue(_current)
            _current = Nothing
        End If
    End Sub

    Public ReadOnly Property AllDone(Optional ByVal StartingPriority As Integer = 0) As Boolean
        Get
            If StartingPriority = -1 Then StartingPriority = 0
            While StartingPriority >= 0
                If Not _priorities(StartingPriority).Count = 0 Then Return False
                StartingPriority -= 1
            End While
            Return True
        End Get
    End Property

    Public Sub Feed(ByVal PCB As PCB) Implements IResource.Feed
        '��������� �� ��� pcb ���� ��������� ����
        _priorities(PCB.Priority).Enqueue(PCB)
        Console.WriteLine(_time & "# �� pcb " & PCB.PID & " ������������� ���� �����������")
        _nop = False
    End Sub

    Public ReadOnly Property Nop() As Boolean Implements IResource.Nop
        Get
            Return _nop
        End Get
    End Property

    Public Function GetImmigrant() As PCB Implements IResource.GetImmigrant
        If _immigrant Is Nothing Then Throw New Exception("��� ������� ��������� ���� ������������")
        Dim r As PCB = _immigrant
        _immigrant = Nothing
        Return r
    End Function

    Public Sub Execute() Implements IResource.Execute
        '�� ��� ������� ������ pcb ���� ������� ����
        If _current Is Nothing Then
            Load()
            If _nop Then
                Console.WriteLine(_time & "# � ������������ �������")
                Return
            Else
                PureExecute()
            End If
        Else '�� ��������� ���� � ���� ��������� ���� ����
            If _timerunning < QUANTUM Then  '�� ��� ���� ��������� � ����������� ������
                If AllDone(_current.Priority - 1) Then '��� ��� ������� ������ ������������
                    PureExecute()
                Else '�� ���� ����� �����������
                    _current.Suspend()
                    Load()
                    If Not _current Is Nothing Then
                        PureExecute()
                    End If
                End If
            Else '� �� ���� ��������� � ����������� ������
                If Not AllDone(_current.Priority) Then
                    _current.Suspend()
                    Load()
                    If Not _current Is Nothing Then
                        PureExecute()
                    Else
                        Console.WriteLine(_time & "# � ������������ �������")
                    End If
                Else
                    PureExecute()
                End If
            End If
        End If
    End Sub

    Protected Sub PureExecute()
        ' ���������� {
        Console.WriteLine(_time & "# � ������������ ������� �� pcb " & _current.PID & " ��� ��������� " & _current.RemainingTimeCPU & " ������, ���� ������ ��� " & _timerunning)
        _current.DoTime(0)
        _timerunning += 1
        ' }
    End Sub
End Class
