Imports System.io

Public Class FileHandler

    Private Shared path As String

    Public Shared Sub createDirectory(ByRef path As String)
        Dim newDirectory As Directory
        newDirectory.CreateDirectory(path)

    End Sub

    Public Shared Sub createTxtFile(ByRef path As String, ByRef name As String)
        Dim newTxtFile As File
        newTxtFile.Create(path + name + ".txt")
    End Sub

    Public Shared Sub createSbmFile(ByRef path As String, ByRef name As String)
        Dim newSbmFile As File
        newSbmFile.Create(path + name + ".txt")
    End Sub

    Public Shared Sub createReceipt(ByVal cashRegister As Cash, ByVal tableNum As Integer, ByRef table As TableOrder, ByRef total As String)

        Dim i, quantity As Integer
        Dim fileName As String
        Dim user As Person



        user = cashRegister.getUser()
        If user Is Nothing Then
            MsgBox("дЕМ УПэЯВЕИ СЕЯБИТЭЯОР ЦИА АУТЭ ТО ТЯАПщФИ.")
        Else

            Dim today As Date

            tableNum = tableNum + 1


            createPath()
            fileName = CStr(Logistics.getAndIncreaseReceiptNumber)
            FileOpen(1, path + "/" + fileName + ".txt", OpenMode.Output)
            PrintLine(1, "DRINK 'N' DINE")
            PrintLine(1, "SNACK-BAR")
            PrintLine(1, "кеыжояос мийгс 41")
            PrintLine(1, "ажл: 012345678")
            PrintLine(1, "доу д хес/мийгс")
            PrintLine(1, "тгк: 2310 123456")
            PrintLine(1, "")
            PrintLine(1, user.handleSurname + " " + user.handleName)
            PrintLine(1, "тяапефи " + tableNum.ToString)
            PrintLine(1, "")

            For i = 0 To table.getNumberOfItems - 1
                Dim orderPart As ListViewItem
                orderPart = table.removeLastFromList()
                Dim theFpa As String
                Dim fpa As Boolean
                fpa = CBool(orderPart.SubItems(3).Text)
                If fpa Then
                    theFpa = "19%"
                Else
                    theFpa = "9%"
                End If
                PrintLine(1, orderPart.SubItems(0).Text, TAB(30), orderPart.SubItems(1).Text, TAB(), orderPart.SubItems(2).Text, TAB(), theFpa)
                quantity = quantity + orderPart.SubItems(1).Text
            Next

            PrintLine(1, "летягта еуяы ", total)
            PrintLine(1, "TEMAXIA ", quantity)
            PrintLine(1, "")
            PrintLine(1, Today.Today)
            PrintLine(1, Today.TimeOfDay.ToString)
            PrintLine(1, "")
            PrintLine(1, "аяихлос паяаццекиас ", fileName)

            FileClose(1)
        End If
    End Sub

    Public Shared Sub createPath()
        Dim currentDate As Date
        Dim day As String
        Dim month As String
        Dim year As String

        day = currentDate.Today.Day.ToString
        month = currentDate.Today.Month.ToString
        year = currentDate.Today.Year.ToString

        path = year + "/" + month + "/" + day

        Dim dir As Directory
        dir.CreateDirectory(path)

    End Sub

    Public Shared Sub createZReport(ByRef dayIncome As String)
        FileOpen(1, path + "/" + "z.txt", OpenMode.Output)
        PrintLine(1, "глеягсио дектио ф " + Logistics.getZNumber.ToString)
        PrintLine(1, "")
        PrintLine(1, "жпа а 9%")
        PrintLine(1, "леийто а")
        PrintLine(1, "йахаяо а")
        PrintLine(1, "жпа а")
        PrintLine(1, "")
        PrintLine(1, "жпа б 19%")
        PrintLine(1, "леийто б")
        PrintLine(1, "йахаяо б")
        PrintLine(1, "жпа б")
        PrintLine(1, "")
        PrintLine(1, "леийта аб", TAB(), dayIncome)
        PrintLine(1, "йахаяа аб")
        PrintLine(1, "жпа аб")
        FileClose(1)
    End Sub

End Class