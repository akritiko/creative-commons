Module Main
    Public UniversalSeed As Integer
    Dim CPU As SCPUPQ
    Dim DSK As New SDSKCS
    Dim Persistor As IO.FileStream
    Public _time As Integer = 0

    Sub Main()

        Dim argvector(9) As String
        Try
            If Environment.GetCommandLineArgs().GetUpperBound(0) <> 12 Then Throw New Exception
            argvector = Environment.GetCommandLineArgs
            Randomizer.Initialize(argvector(1))
            CPU = New SCPUPQ(argvector(3))
            Persistor = IO.File.Open(argvector(12), IO.FileMode.Create)
            Console.SetOut(New IO.StreamWriter(Persistor))
        Catch ex As Exception
            Console.WriteLine("Σφάλμα αριθμού ορισμάτων. Τα ορίσματα πρέπει να είναι:")
            Console.WriteLine("1.  Σπόρος τυχαίων αριθμών")
            Console.WriteLine("2.  Χρόνος παύσης δημιουργίας νέων pcb")
            Console.WriteLine("3.  Χρονοτεμάχιο εκ περιτροπής δρομολόγησης")
            Console.WriteLine("4.  Κάτω όριο πλήθους τεμαχίων εισόδου εξόδου")
            Console.WriteLine("5.  ’νω όριο πλήθος τεμαχίων εισόδου εξόδου")
            Console.WriteLine("6.  Κάτω όριο διάρκειας τεμαχίων εισόδου εξόδου")
            Console.WriteLine("7.  ’νω όριο διάρκειας τεμαχίων εισόδου εξόδου")
            Console.WriteLine("8.  Κάτω όριο διάρκειας τεμαχίων ΚΜΕ")
            Console.WriteLine("9.  ’νω όριο διάρκειας τεμαχίων ΚΜΕ")
            Console.WriteLine("10. Κάτω όριο αιτουμένων κυλίνδρων")
            Console.WriteLine("11. ’νω όριο αιτουμένων κυλίνδρων")
            Console.WriteLine("12. Όνομα αρχείου εξόδου")
            Exit Sub

        End Try

        AddHandler CPU.ImmigrationRequest, AddressOf FeedbackCPU
        AddHandler DSK.ImmigrationRequest, AddressOf FeedbackDSK

        For i As Integer = 0 To argvector(2)
            _time += 1
            Dim holder = New PCB(argvector(4), _
                                argvector(5), _
                                argvector(6), _
                                argvector(7), _
                                argvector(8), _
                                argvector(9), _
                                argvector(10), _
                                argvector(10))

            Dim replica As PCB = holder.Clone
            replica.Dump()

            CPU.Feed(holder)

            CPU.Execute()
            DSK.Execute()
        Next

        While (Not DSK.Nop) Or (Not CPU.Nop)
            _time += 1

            DSK.Execute()
            CPU.Execute()

        End While

        Console.Out.Flush()
        Console.Out.Close()

    End Sub

    Sub FeedbackCPU(ByVal O As PCB)
        If Not O.DSKDone Then
            Console.WriteLine(_time & "# To pcb " & O.PID & " αιτήθηκε μετανάστευσης προς δίσκο")
            DSK.Feed(CPU.GetImmigrant)
        Else
            Console.WriteLine(_time & "# To pcb " & O.PID & " εκπλήρωσε τους σκοπούς του")
        End If
    End Sub

    Sub FeedbackDSK(ByVal O As PCB)
        If Not O.CPUDone Then
            Console.WriteLine(_time & "# To pcb " & O.PID & " αιτήθηκε μετανάστευσης προς τον επεξεργαστή")
            CPU.Feed(DSK.GetImmigrant)
        Else
            Console.WriteLine(_time & "# To pcb " & O.PID & " εκπλήρωσε τους σκοπούς του")
        End If
    End Sub

End Module
