Imports System.Math

'������� ��� �� ������� �������� ���������� ��������
Public Module Randomizer
    Public UniversalSeed As Integer
    Private _r As New Random(UniversalSeed)

    '������������ �� ��� �����
    Sub Initialize(ByVal Seed As Integer)
        _r = New Random(Seed)

    End Sub

    '�������� ������� ������ ��� �����
    Private Function GenerateP(ByVal Low As Integer, ByVal High As Integer) As Integer
        Dim r As Double = _r.NextDouble()
        r *= High - Low
        r += Low
        'Console.WriteLine("#{" & Low & "," & High & "}" & CInt(r))
        If r < Low Or High < r Then Throw New Exception
        Return r

    End Function

    Function Generate(ByVal Low As Integer, ByVal High As Integer) As Integer
        If Low > High Then Throw New ArgumentException
        If Low >= 0 Then Return GenerateP(Low, High)
        Dim offset As Integer = Abs(Low)
        Dim r As Integer = GenerateP(Low + offset, High + offset) - offset
        'Console.WriteLine("#{" & Low & "," & High & "}" & CInt(r))
        If r < Low Or High < r Then Throw New Exception
        Return r
    End Function
End Module
