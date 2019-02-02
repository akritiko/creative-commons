Module ProcessServices
    Private _pidcount

    Sub New()
        _pidcount = 0
    End Sub

    Function AllocatePID() As Integer
        Dim res As Integer = _pidcount
        _pidcount += 1
        Return res

    End Function

End Module
