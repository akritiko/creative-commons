'Represents a real number with the precision of two decimal digits.

Public Class PrecisionOfTwo

    'Attributes

    Private number As Decimal

    'Methods

    'Constructor
    Public Sub New(ByRef number As Double)
        Me.number = number
    End Sub

    'Adds two instances of the class and returns the value calculated.
    Public Function add(ByRef term2 As precisionOfTwo) As precisionOfTwo
        Me.number = Me.number + term2.number
        Me.number = Me.number.Round(Me.number, 2)
        Return Me
    End Function

    'Subtracts two instances of the class and returns the value calculated.
    Public Function subt(ByRef term2 As precisionOfTwo) As precisionOfTwo
        Me.number = Me.number - term2.number
        Me.number = Me.number.Round(Me.number, 2)
        Return Me
    End Function

    'Multiplies two instances of the class and returns the value calculated.
    Public Function mul(ByRef term2 As PrecisionOfTwo) As PrecisionOfTwo
        Me.number = Me.number * term2.number
        Me.number = Me.number.Round(Me.number, 2)
        Return Me
    End Function

    'Divides two instances of the class and returns the value calculated.
    Public Function div(ByRef term2 As PrecisionOfTwo) As PrecisionOfTwo
        Me.number = Me.number / term2.number
        Me.number = Me.number.Round(Me.number, 2)
        Return Me
    End Function

    Public Sub setEqualTo(ByRef num As Decimal)
        Me.number = num
    End Sub

    Public Sub setEqualToZero()
        Me.number = 0
    End Sub

    Public Function getDecNumber() As Decimal
        Return Me.number
    End Function


    'Overrides the method toString() of the Object class. It actually converts the value of an instance of this class into string. We need this method because we need to print the zeros of the fractional part (VB.net ignores them by default).
    Public Overrides Function toString() As String
        Dim numToString As String
        'Converts the attribute number to a string (initialization)
        numToString = Me.number.ToString
        'Represent the fractional and decimal parts of the number respectively
        Dim fractionalPart, decimalPart As Decimal
        decimalPart = Int(Me.number)
        fractionalPart = Me.number - decimalPart
        'If the number is 0, returns the string "0,00". 
        If Me.number.Equals(0D) Then
            numToString = "0,00"
            'If the fractional part is equal to 0,then it concatenates the current string with the ",00"
        ElseIf fractionalPart = 0D Then
            numToString = decimalPart.ToString + ",00"
            'If the fractional part is < 1, concatenates the current string with the "0"
        Else
            Dim aux As Decimal
            aux = fractionalPart * 10
            fractionalPart = Int(aux)
            aux = aux - fractionalPart
            If aux = 0D Then
                numToString = numToString + "0"
            End If
        End If
        Return numToString
    End Function

    'Converts a string to an instance of the class.
    Public Shared Function stringToPrecisionOfTwo(ByRef alphanumeric As String) As PrecisionOfTwo
        Dim validNumber As Double
        'Converts the string alphanumeric to a double
        validNumber = validNumber.Parse(alphanumeric)
        'Creates an instance of the class using the value of the validNumber
        Dim tempPrecisionOfTwo As New PrecisionOfTwo(validNumber)
        Return tempPrecisionOfTwo
    End Function

    Public Function copyNumber() As PrecisionOfTwo
        Dim tempNum As New PrecisionOfTwo(Me.number)
        Return tempNum
    End Function

End Class