Public Class TableOrder

    Private orderList As New Queue
    Private orderListIndex As Integer = -1
    Private orderBill As New PrecisionOfTwo(0.0)

    Public Sub addToList(ByRef item)
        orderList.Enqueue(item)
    End Sub

    Public Function removeLastFromList() As Object
        Return orderList.Dequeue()
    End Function

    Public Function getNumberOfItems() As Integer
        Return orderList.Count
    End Function

    Public Property handleListIndex()
        Get
            Return orderListIndex
        End Get
        Set(ByVal index)
            orderListIndex = index
        End Set
    End Property

    Public Sub setBillEqualTo(ByRef price As PrecisionOfTwo)
        orderBill.setEqualTo(price.getDecNumber)
    End Sub

    Public Function getTableBill() As PrecisionOfTwo
        Return orderBill.copyNumber
    End Function

    Public Function getBillAsString() As String
        Return orderBill.ToString
    End Function

    Public Sub clearBill()
        orderBill.setEqualToZero()
        orderListIndex = 0
    End Sub
End Class