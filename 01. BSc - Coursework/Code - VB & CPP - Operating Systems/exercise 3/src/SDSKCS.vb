Class SDSKCS : Implements IResource
    Private _front() As PCB
    Private _current As PCB
    Private _behind As Collection
    Private _immigrant As PCB
    Public Event ImmigrationRequest(ByVal O As PCB) Implements IResource.ImmigrationRequest
    'Private _nop As Boolean
    Private _timerunning As Integer

    Public Sub New()
        _behind = New Collection

    End Sub

    Public Sub Execute() Implements IResource.Execute
        If Not _current Is Nothing Then
            'εκτέλεση
            If _current.RemainingTimeDSK <= 0 Then Throw New Exception("Την πάτησες μεγαλοπρεπώς φίλτατε")
            PureExecute()
        Else 'αναζήτηση και εκτέλεση
            Load()
            If _current Is Nothing Then
                RepositionHead()
                Load()
                If _current Is Nothing Then
                    '_nop = True
                    Console.WriteLine(_time & "# Ο δίσκος αδρανεί")
                Else
                    PureExecute()
                End If
            Else
                PureExecute()
            End If
        End If
    End Sub

    Private Sub PureExecute()
        ' εκτελείται {
        Console.WriteLine(_time & "# Ο δίσκος εξυπηρετεί το pcb " & _current.PID & " και απομένουν " & _current.RemainingTimeDSK & " κύκλοι, έχει τρέξει για " & _timerunning)
        _current.DoTime(1)
        _timerunning += 1
        '_nop = False
        ' }
    End Sub

    Public Sub Load()
        Reactor.Push(PullFront)
        If Reactor.Peek Is Nothing Then
            Reactor.Pop()
        Else
            _current = Reactor.Pop
            AddHandler _current.CPURequest, AddressOf UnLoad
            _timerunning = 0
            Console.WriteLine(_time & "# Φορτώθηκε για εκτέλεση στον δίσκο το pcb " & _current.PID)
        End If
    End Sub

    Public Sub UnLoad(ByVal Applicant As PCB)
        _immigrant = _current
        RemoveHandler _current.CPURequest, AddressOf UnLoad
        _current = Nothing
        _immigrant.Forfeit(1)
        RaiseEvent ImmigrationRequest(_immigrant)

    End Sub

    Public Sub Feed(ByVal PCB As PCB) Implements IResource.Feed
        If _current Is Nothing Then
            _behind.Add(PCB)
            Return
        End If
        If PCB.RequestedCylinder < _current.RequestedCylinder Then
            _behind.Add(PCB)
        Else
            PushFront(PCB)
        End If
        Console.WriteLine(_time & "# Το pcb " & PCB.PID & " τροφοδοτήθηκε στον δίσκο")
    End Sub

    Public Sub PushFront(ByVal PCB As PCB)
        If PCB Is Nothing Then Throw New Exception
        If _front Is Nothing Then
            ReDim _front(0)
            _front(0) = PCB
        Else
            ReDim Preserve _front(_front.GetUpperBound(0) + 1)
            _front(_front.GetUpperBound(0)) = PCB
        End If
        _front.Sort(_front, PCB)
    End Sub

    Public Function PullFront() As PCB
        If _front Is Nothing Then Return Nothing

        Dim r As PCB = _front(0)
        Select Case _front.GetUpperBound(0)
            Case 0
                _front = Nothing
            Case 1
                _front = New PCB() {_front(1)}
            Case Is > 1
                Dim nfront As PCB()
                ReDim nfront(_front.GetUpperBound(0) - 1)
                For i As Integer = 1 To _front.GetUpperBound(0)
                    nfront(i - 1) = _front(i)
                Next
                _front = nfront
        End Select
        Return r

    End Function

    Private Sub RepositionHead()
        For Each pcb As PCB In _behind
            PushFront(pcb)
        Next
        _behind = New Collection
        'If _front Is Nothing Then _nop = True
    End Sub

    Public Function GetImmigrant() As PCB Implements IResource.GetImmigrant
        If _immigrant Is Nothing Then Throw New Exception("No immigrant here")
        Reactor.Push(_immigrant)
        _immigrant = Nothing
        Return Reactor.Pop
    End Function

    Public ReadOnly Property Nop() As Boolean Implements IResource.Nop
        Get
            Return _current Is Nothing And _front Is Nothing And _behind.Count = 0
        End Get
    End Property

End Class
