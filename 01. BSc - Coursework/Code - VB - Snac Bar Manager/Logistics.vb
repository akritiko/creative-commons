Public Class Logistics

    Private Shared receiptNum As Integer = 0
    Private Shared zNumber As Integer
    Private Shared initialCash As New PrecisionOfTwo(0.0)

    Public Shared Sub initializeDay()
        Dim tempZ As String
        Dim tempinitialCash As String
        FileOpen(1, "config.sbm", OpenMode.Input)
        'Z manipulation
        tempZ = LineInput(1)
        zNumber = tempZ + 1
        'initialCash
        tempinitialCash = LineInput(1)
        tempinitialCash = tempinitialCash.Substring(1, tempinitialCash.Length - 2)
        initialCash.setEqualTo(CDec(tempinitialCash))
        FileClose(1)

    End Sub

    Public Shared Function getAndIncreaseReceiptNumber()
        receiptNum = receiptNum + 1
        Return receiptNum
    End Function

    Public Shared Function getInitialCash() As PrecisionOfTwo
        Dim initCash As New PrecisionOfTwo(0.0)
        initCash.setEqualTo(initialCash.getDecNumber())
        Return initCash
    End Function

    Public Shared Function getZNumber() As Integer
        Return zNumber
    End Function

End Class
