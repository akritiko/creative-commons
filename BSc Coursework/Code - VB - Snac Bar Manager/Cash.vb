Public Class Cash

    Private user As Person
    Private money As PrecisionOfTwo

    Public Sub New()
        money = Logistics.getInitialCash
    End Sub

    Public Sub setNewUser(ByRef newUser)
        user = newUser
    End Sub

    Public Function getUser() As Person
        Return user
    End Function

    Public Sub releaseCash()
        user = Nothing
    End Sub

    Public Property handleMoney()
        Get
            Return money
        End Get
        Set(ByVal amount)
            money.add(amount)
        End Set
    End Property

    Public Function getMoney() As PrecisionOfTwo
        Dim tempMoney As PrecisionOfTwo
        tempMoney = money.copyNumber
        Return tempMoney
    End Function

    Public Function getMoneyAsString() As String
        Return money.ToString
    End Function

    Public Function isAvailable() As Boolean
        If user Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

End Class