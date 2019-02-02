'Δρομολογητής επεξεργαστή με ουρές προτεραιότητας
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
                    Throw New Exception("Επιχειρείται η φόρτωση διεργασίας με χαμηλότερη προτεραιότητα")

                _nop = False
                _current = _priorities(i).Dequeue
                _timerunning = 0
                AddHandler _current.IORequest, AddressOf UnLoad
                AddHandler _current.Suspended, AddressOf UnLoad
                Console.WriteLine(_time & "# Φορτώθηκε για εκτέλεση στον επεξεργαστή το pcb " & _current.PID)
                Return
            End If
        Next
        _nop = True
    End Sub

    Public Sub UnLoad(Optional ByVal Applicant As PCB = Nothing)
        If _current Is Nothing Then Throw New Exception("Επιχειρείται κατέβασμα χωρίς τρέχουσα διεργασία")
        If Not Applicant Is Nothing Then
            If Not _current Is Applicant Then Throw New Exception("Σφάλμα συγχρονισμού")
            RemoveHandler _current.IORequest, AddressOf UnLoad
            RemoveHandler _current.Suspended, AddressOf UnLoad
        End If

        If _current.IsFinished(0) Then 'άν τελείωσε απο επεξεργαστή
            _immigrant = _current
            _current.Forfeit(0)
            _current = Nothing
            RaiseEvent ImmigrationRequest(_immigrant)
        Else 'η αν τελείωσε ο εκχωρημένος χρόνος
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
        'τοποθετεί το νέο pcb στην κατάλληλη ουρά
        _priorities(PCB.Priority).Enqueue(PCB)
        Console.WriteLine(_time & "# Το pcb " & PCB.PID & " τροφοδοτήθηκε στον επεξεργαστη")
        _nop = False
    End Sub

    Public ReadOnly Property Nop() As Boolean Implements IResource.Nop
        Get
            Return _nop
        End Get
    End Property

    Public Function GetImmigrant() As PCB Implements IResource.GetImmigrant
        If _immigrant Is Nothing Then Throw New Exception("Δεν βρέθηκε διεργασία προς μετανάστευση")
        Dim r As PCB = _immigrant
        _immigrant = Nothing
        Return r
    End Function

    Public Sub Execute() Implements IResource.Execute
        'αν δεν υπάρχει τρέχον pcb τότε φόρτωση ενός
        If _current Is Nothing Then
            Load()
            If _nop Then
                Console.WriteLine(_time & "# Ο επεξεργαστής αδρανεί")
                Return
            Else
                PureExecute()
            End If
        Else 'αν φορτώθηκε κάτι ή ηταν φορτωμένο πρίν τότε
            If _timerunning < QUANTUM Then  'αν δεν έχει τελειώσει ο εκχωρημένος χρόνος
                If AllDone(_current.Priority - 1) Then 'και δεν υπάρχει ικανός ανταγωνιστής
                    PureExecute()
                Else 'αν έχει ικανό ανταγωνιστή
                    _current.Suspend()
                    Load()
                    If Not _current Is Nothing Then
                        PureExecute()
                    End If
                End If
            Else 'ή αν έχει τελειώσει ο εκχωρημένος χρόνος
                If Not AllDone(_current.Priority) Then
                    _current.Suspend()
                    Load()
                    If Not _current Is Nothing Then
                        PureExecute()
                    Else
                        Console.WriteLine(_time & "# Ο επεξεργαστής αδρανεί")
                    End If
                Else
                    PureExecute()
                End If
            End If
        End If
    End Sub

    Protected Sub PureExecute()
        ' εκτελείται {
        Console.WriteLine(_time & "# Ο επεξεργαστής εκτελεί το pcb " & _current.PID & " και απομένουν " & _current.RemainingTimeCPU & " κύκλοι, έχει τρέξει για " & _timerunning)
        _current.DoTime(0)
        _timerunning += 1
        ' }
    End Sub
End Class
