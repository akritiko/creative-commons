'This class represents the stuff that works in the business that uses this software. It containes both personal data and information concidering his job.

Public Class Person

    'Attributes

    'Personal data
    Private surname As String
    Private name As String
    Private address As String
    Private phone As String
    Private id As String
    Private afm As String
    'Employee's Identification
    Private ama As String
    Private dateOfHiring As Date
    Private duty As Duties
    Private password As String

    'Enumeration type that determines which are the duties of the person (employee) in the business.
    Enum Duties
        идиойтгтгс
        упеухумос
        сеябитояос
        сеж
        лпаялам
        богхос
    End Enum

    'Methods

    'Constructor
    Public Sub New(ByVal _surname As String, ByVal _name As String, ByVal _address As String, ByVal _phone As String, ByVal _id As String, ByVal _afm As String, ByVal _ama As String, ByVal _dateOfHiring As Date, ByVal _duty As Duties, ByVal _pass As String)
        surname = _surname
        name = _name
        address = _address
        phone = _phone
        id = _id
        afm = _afm
        ama = _ama
        dateOfHiring = _dateOfHiring
        duty = _duty
        password = _pass
    End Sub

    'Returns person's attributes in a string variable.
    Public Overrides Function ToString() As String

        Return surname + "_" + name + "_" + address + "_" + phone + "_" + id + "_" + afm + "_" + ama + "_" + dateOfHiring.Day.ToString + "/" + dateOfHiring.Month.ToString + "/" + dateOfHiring.Year.ToString + "_" + duty.ToString + "_" + password

    End Function

    'Converts a string to the appropriate enumeration index of the Duties type.
    Public Shared Function stringToDuty(ByVal theString As String) As Integer
        Dim enumerator As Integer
        Select Case theString
            Case "идиойтгтгс"
                enumerator = 0
            Case "упеухумос"
                enumerator = 1
            Case "сеябитояос"
                enumerator = 2
            Case "сеж"
                enumerator = 3
            Case "лпаялам"
                enumerator = 4
            Case "богхос"
                enumerator = 5
        End Select
        'Returns the appropriate value
        Return enumerator
    End Function

    'Converts a string to a valid instance of the Date class.
    Public Shared Function stringToDate(ByVal theString As String) As Date
        Dim bufCounter As Integer = 0
        Dim dateFieldIndex As Integer = 0
        Dim buffer As String = ""
        'Each position represents the day, month and  year respectively.
        Dim dateParts(3) As String

        'This for loop splits the string of the date into day, moth and year, which are separated by the slash character (/).
        For bufCounter = 0 To theString.Length - 1
            If Not theString.Substring(bufCounter, 1).Equals("/") Then
                buffer = buffer + theString.Substring(bufCounter, 1)
            Else
                dateParts(dateFieldIndex) = buffer
                dateFieldIndex = dateFieldIndex + 1
                buffer = ""
            End If
        Next
        'The remainder of the initial string stored into the buffer represent the last part of the date. 
        dateParts(dateFieldIndex) = buffer

        'Creates an instance of the Date class using the dateParts array.
        Dim theDate As New Date(dateParts(2), dateParts(1), dateParts(0))

        Return theDate
    End Function

    'The following methods return the value of the attribute indicated by their names.

    Public ReadOnly Property handleName() As String
        Get
            Return name
        End Get
    End Property

    Public ReadOnly Property handleSurname() As String
        Get
            Return surname
        End Get
    End Property

    Public ReadOnly Property handleAddress() As String
        Get
            Return address
        End Get
    End Property

    Public ReadOnly Property handlePhone() As String
        Get
            Return phone
        End Get
    End Property

    Public ReadOnly Property handleId() As String
        Get
            Return id
        End Get
    End Property

    Public ReadOnly Property handleAfm() As String
        Get
            Return afm
        End Get
    End Property

    Public ReadOnly Property handleAma() As String
        Get
            Return ama
        End Get
    End Property

    Public ReadOnly Property handleDateOfHiring() As Date
        Get
            Return dateOfHiring
        End Get
    End Property

    Public ReadOnly Property handleDuty() As Duties
        Get
            Return duty
        End Get
    End Property

    Public ReadOnly Property handlePassword() As String
        Get
            Return password
        End Get
    End Property

End Class