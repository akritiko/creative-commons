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
            Console.WriteLine("������ ������� ���������. �� �������� ������ �� �����:")
            Console.WriteLine("1.  ������ ������� �������")
            Console.WriteLine("2.  ������ ������ ����������� ���� pcb")
            Console.WriteLine("3.  ������������ �� ���������� ������������")
            Console.WriteLine("4.  ���� ���� ������� �������� ������� ������")
            Console.WriteLine("5.  ��� ���� ������ �������� ������� ������")
            Console.WriteLine("6.  ���� ���� ��������� �������� ������� ������")
            Console.WriteLine("7.  ��� ���� ��������� �������� ������� ������")
            Console.WriteLine("8.  ���� ���� ��������� �������� ���")
            Console.WriteLine("9.  ��� ���� ��������� �������� ���")
            Console.WriteLine("10. ���� ���� ���������� ���������")
            Console.WriteLine("11. ��� ���� ���������� ���������")
            Console.WriteLine("12. ����� ������� ������")
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
            Console.WriteLine(_time & "# To pcb " & O.PID & " �������� ������������� ���� �����")
            DSK.Feed(CPU.GetImmigrant)
        Else
            Console.WriteLine(_time & "# To pcb " & O.PID & " ��������� ���� ������� ���")
        End If
    End Sub

    Sub FeedbackDSK(ByVal O As PCB)
        If Not O.CPUDone Then
            Console.WriteLine(_time & "# To pcb " & O.PID & " �������� ������������� ���� ��� �����������")
            CPU.Feed(DSK.GetImmigrant)
        Else
            Console.WriteLine(_time & "# To pcb " & O.PID & " ��������� ���� ������� ���")
        End If
    End Sub

End Module
