Public Class FrmKeyboard
    Inherits System.Windows.Forms.Form

    Private activeTxt As New TextBox
    Private buffer As String
    Private greekOrLatin = True

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlNumbers As System.Windows.Forms.Panel
    Friend WithEvents cmd0 As System.Windows.Forms.Button
    Friend WithEvents cmd9 As System.Windows.Forms.Button
    Friend WithEvents cmd8 As System.Windows.Forms.Button
    Friend WithEvents cmd7 As System.Windows.Forms.Button
    Friend WithEvents cmd6 As System.Windows.Forms.Button
    Friend WithEvents cmd5 As System.Windows.Forms.Button
    Friend WithEvents cmd4 As System.Windows.Forms.Button
    Friend WithEvents cmd3 As System.Windows.Forms.Button
    Friend WithEvents cmd2 As System.Windows.Forms.Button
    Friend WithEvents cmd1 As System.Windows.Forms.Button
    Friend WithEvents pnlLetters As System.Windows.Forms.Panel
    Friend WithEvents cmdLang As System.Windows.Forms.Button
    Friend WithEvents cmdExtra2 As System.Windows.Forms.Button
    Friend WithEvents cmdExtra1 As System.Windows.Forms.Button
    Friend WithEvents cmdSpace As System.Windows.Forms.Button
    Friend WithEvents cmdW As System.Windows.Forms.Button
    Friend WithEvents cmdPS As System.Windows.Forms.Button
    Friend WithEvents cmdX As System.Windows.Forms.Button
    Friend WithEvents cmdF As System.Windows.Forms.Button
    Friend WithEvents cmdY As System.Windows.Forms.Button
    Friend WithEvents cmdT As System.Windows.Forms.Button
    Friend WithEvents cmdS As System.Windows.Forms.Button
    Friend WithEvents cmdR As System.Windows.Forms.Button
    Friend WithEvents cmdP As System.Windows.Forms.Button
    Friend WithEvents cmdO As System.Windows.Forms.Button
    Friend WithEvents cmdKS As System.Windows.Forms.Button
    Friend WithEvents cmdN As System.Windows.Forms.Button
    Friend WithEvents cmdM As System.Windows.Forms.Button
    Friend WithEvents cmdL As System.Windows.Forms.Button
    Friend WithEvents cmdK As System.Windows.Forms.Button
    Friend WithEvents cmdI As System.Windows.Forms.Button
    Friend WithEvents cmdTH As System.Windows.Forms.Button
    Friend WithEvents cmdH As System.Windows.Forms.Button
    Friend WithEvents cmdZ As System.Windows.Forms.Button
    Friend WithEvents cmdE As System.Windows.Forms.Button
    Friend WithEvents cmdD As System.Windows.Forms.Button
    Friend WithEvents cmdG As System.Windows.Forms.Button
    Friend WithEvents cmdB As System.Windows.Forms.Button
    Friend WithEvents cmdA As System.Windows.Forms.Button
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmKeyboard))
        Me.pnlNumbers = New System.Windows.Forms.Panel
        Me.cmd0 = New System.Windows.Forms.Button
        Me.cmd9 = New System.Windows.Forms.Button
        Me.cmd8 = New System.Windows.Forms.Button
        Me.cmd7 = New System.Windows.Forms.Button
        Me.cmd6 = New System.Windows.Forms.Button
        Me.cmd5 = New System.Windows.Forms.Button
        Me.cmd4 = New System.Windows.Forms.Button
        Me.cmd3 = New System.Windows.Forms.Button
        Me.cmd2 = New System.Windows.Forms.Button
        Me.cmd1 = New System.Windows.Forms.Button
        Me.pnlLetters = New System.Windows.Forms.Panel
        Me.cmdLang = New System.Windows.Forms.Button
        Me.cmdExtra2 = New System.Windows.Forms.Button
        Me.cmdExtra1 = New System.Windows.Forms.Button
        Me.cmdSpace = New System.Windows.Forms.Button
        Me.cmdW = New System.Windows.Forms.Button
        Me.cmdPS = New System.Windows.Forms.Button
        Me.cmdX = New System.Windows.Forms.Button
        Me.cmdF = New System.Windows.Forms.Button
        Me.cmdY = New System.Windows.Forms.Button
        Me.cmdT = New System.Windows.Forms.Button
        Me.cmdS = New System.Windows.Forms.Button
        Me.cmdR = New System.Windows.Forms.Button
        Me.cmdP = New System.Windows.Forms.Button
        Me.cmdO = New System.Windows.Forms.Button
        Me.cmdKS = New System.Windows.Forms.Button
        Me.cmdN = New System.Windows.Forms.Button
        Me.cmdM = New System.Windows.Forms.Button
        Me.cmdL = New System.Windows.Forms.Button
        Me.cmdK = New System.Windows.Forms.Button
        Me.cmdI = New System.Windows.Forms.Button
        Me.cmdTH = New System.Windows.Forms.Button
        Me.cmdH = New System.Windows.Forms.Button
        Me.cmdZ = New System.Windows.Forms.Button
        Me.cmdE = New System.Windows.Forms.Button
        Me.cmdD = New System.Windows.Forms.Button
        Me.cmdG = New System.Windows.Forms.Button
        Me.cmdB = New System.Windows.Forms.Button
        Me.cmdA = New System.Windows.Forms.Button
        Me.cmdBack = New System.Windows.Forms.Button
        Me.pnlNumbers.SuspendLayout()
        Me.pnlLetters.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlNumbers
        '
        Me.pnlNumbers.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.pnlNumbers.BackColor = System.Drawing.Color.Transparent
        Me.pnlNumbers.Controls.Add(Me.cmd0)
        Me.pnlNumbers.Controls.Add(Me.cmd9)
        Me.pnlNumbers.Controls.Add(Me.cmd8)
        Me.pnlNumbers.Controls.Add(Me.cmd7)
        Me.pnlNumbers.Controls.Add(Me.cmd6)
        Me.pnlNumbers.Controls.Add(Me.cmd5)
        Me.pnlNumbers.Controls.Add(Me.cmd4)
        Me.pnlNumbers.Controls.Add(Me.cmd3)
        Me.pnlNumbers.Controls.Add(Me.cmd2)
        Me.pnlNumbers.Controls.Add(Me.cmd1)
        Me.pnlNumbers.Enabled = False
        Me.pnlNumbers.Location = New System.Drawing.Point(592, 0)
        Me.pnlNumbers.Name = "pnlNumbers"
        Me.pnlNumbers.Size = New System.Drawing.Size(200, 272)
        Me.pnlNumbers.TabIndex = 91
        '
        'cmd0
        '
        Me.cmd0.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd0.ForeColor = System.Drawing.Color.Brown
        Me.cmd0.Location = New System.Drawing.Point(72, 208)
        Me.cmd0.Name = "cmd0"
        Me.cmd0.Size = New System.Drawing.Size(50, 50)
        Me.cmd0.TabIndex = 65
        Me.cmd0.TabStop = False
        Me.cmd0.Text = "0"
        '
        'cmd9
        '
        Me.cmd9.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd9.ForeColor = System.Drawing.Color.Brown
        Me.cmd9.Location = New System.Drawing.Point(136, 144)
        Me.cmd9.Name = "cmd9"
        Me.cmd9.Size = New System.Drawing.Size(50, 50)
        Me.cmd9.TabIndex = 64
        Me.cmd9.TabStop = False
        Me.cmd9.Text = "9"
        '
        'cmd8
        '
        Me.cmd8.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd8.ForeColor = System.Drawing.Color.Brown
        Me.cmd8.Location = New System.Drawing.Point(72, 144)
        Me.cmd8.Name = "cmd8"
        Me.cmd8.Size = New System.Drawing.Size(50, 50)
        Me.cmd8.TabIndex = 63
        Me.cmd8.TabStop = False
        Me.cmd8.Text = "8"
        '
        'cmd7
        '
        Me.cmd7.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd7.ForeColor = System.Drawing.Color.Brown
        Me.cmd7.Location = New System.Drawing.Point(8, 144)
        Me.cmd7.Name = "cmd7"
        Me.cmd7.Size = New System.Drawing.Size(50, 50)
        Me.cmd7.TabIndex = 62
        Me.cmd7.TabStop = False
        Me.cmd7.Text = "7"
        '
        'cmd6
        '
        Me.cmd6.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd6.ForeColor = System.Drawing.Color.Brown
        Me.cmd6.Location = New System.Drawing.Point(136, 80)
        Me.cmd6.Name = "cmd6"
        Me.cmd6.Size = New System.Drawing.Size(50, 50)
        Me.cmd6.TabIndex = 61
        Me.cmd6.TabStop = False
        Me.cmd6.Text = "6"
        '
        'cmd5
        '
        Me.cmd5.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd5.ForeColor = System.Drawing.Color.Brown
        Me.cmd5.Location = New System.Drawing.Point(72, 80)
        Me.cmd5.Name = "cmd5"
        Me.cmd5.Size = New System.Drawing.Size(50, 50)
        Me.cmd5.TabIndex = 60
        Me.cmd5.TabStop = False
        Me.cmd5.Text = "5"
        '
        'cmd4
        '
        Me.cmd4.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd4.ForeColor = System.Drawing.Color.Brown
        Me.cmd4.Location = New System.Drawing.Point(8, 80)
        Me.cmd4.Name = "cmd4"
        Me.cmd4.Size = New System.Drawing.Size(50, 50)
        Me.cmd4.TabIndex = 59
        Me.cmd4.TabStop = False
        Me.cmd4.Text = "4"
        '
        'cmd3
        '
        Me.cmd3.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd3.ForeColor = System.Drawing.Color.Brown
        Me.cmd3.Location = New System.Drawing.Point(136, 16)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(50, 50)
        Me.cmd3.TabIndex = 58
        Me.cmd3.TabStop = False
        Me.cmd3.Text = "3"
        '
        'cmd2
        '
        Me.cmd2.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd2.ForeColor = System.Drawing.Color.Brown
        Me.cmd2.Location = New System.Drawing.Point(72, 16)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(50, 50)
        Me.cmd2.TabIndex = 57
        Me.cmd2.TabStop = False
        Me.cmd2.Text = "2"
        '
        'cmd1
        '
        Me.cmd1.BackColor = System.Drawing.Color.CadetBlue
        Me.cmd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmd1.ForeColor = System.Drawing.Color.Brown
        Me.cmd1.Location = New System.Drawing.Point(8, 16)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(50, 50)
        Me.cmd1.TabIndex = 56
        Me.cmd1.TabStop = False
        Me.cmd1.Text = "1"
        '
        'pnlLetters
        '
        Me.pnlLetters.Controls.Add(Me.cmdLang)
        Me.pnlLetters.Controls.Add(Me.cmdExtra2)
        Me.pnlLetters.Controls.Add(Me.cmdExtra1)
        Me.pnlLetters.Controls.Add(Me.cmdSpace)
        Me.pnlLetters.Controls.Add(Me.cmdW)
        Me.pnlLetters.Controls.Add(Me.cmdPS)
        Me.pnlLetters.Controls.Add(Me.cmdX)
        Me.pnlLetters.Controls.Add(Me.cmdF)
        Me.pnlLetters.Controls.Add(Me.cmdY)
        Me.pnlLetters.Controls.Add(Me.cmdT)
        Me.pnlLetters.Controls.Add(Me.cmdS)
        Me.pnlLetters.Controls.Add(Me.cmdR)
        Me.pnlLetters.Controls.Add(Me.cmdP)
        Me.pnlLetters.Controls.Add(Me.cmdO)
        Me.pnlLetters.Controls.Add(Me.cmdKS)
        Me.pnlLetters.Controls.Add(Me.cmdN)
        Me.pnlLetters.Controls.Add(Me.cmdM)
        Me.pnlLetters.Controls.Add(Me.cmdL)
        Me.pnlLetters.Controls.Add(Me.cmdK)
        Me.pnlLetters.Controls.Add(Me.cmdI)
        Me.pnlLetters.Controls.Add(Me.cmdTH)
        Me.pnlLetters.Controls.Add(Me.cmdH)
        Me.pnlLetters.Controls.Add(Me.cmdZ)
        Me.pnlLetters.Controls.Add(Me.cmdE)
        Me.pnlLetters.Controls.Add(Me.cmdD)
        Me.pnlLetters.Controls.Add(Me.cmdG)
        Me.pnlLetters.Controls.Add(Me.cmdB)
        Me.pnlLetters.Controls.Add(Me.cmdA)
        Me.pnlLetters.Enabled = False
        Me.pnlLetters.Location = New System.Drawing.Point(8, 0)
        Me.pnlLetters.Name = "pnlLetters"
        Me.pnlLetters.Size = New System.Drawing.Size(584, 272)
        Me.pnlLetters.TabIndex = 92
        '
        'cmdLang
        '
        Me.cmdLang.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdLang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdLang.ForeColor = System.Drawing.Color.Black
        Me.cmdLang.Image = CType(resources.GetObject("cmdLang.Image"), System.Drawing.Image)
        Me.cmdLang.Location = New System.Drawing.Point(520, 144)
        Me.cmdLang.Name = "cmdLang"
        Me.cmdLang.Size = New System.Drawing.Size(50, 115)
        Me.cmdLang.TabIndex = 114
        Me.cmdLang.TabStop = False
        Me.cmdLang.Text = "ÅËË"
        Me.cmdLang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdExtra2
        '
        Me.cmdExtra2.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdExtra2.Enabled = False
        Me.cmdExtra2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdExtra2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExtra2.Location = New System.Drawing.Point(72, 208)
        Me.cmdExtra2.Name = "cmdExtra2"
        Me.cmdExtra2.Size = New System.Drawing.Size(50, 50)
        Me.cmdExtra2.TabIndex = 113
        Me.cmdExtra2.TabStop = False
        '
        'cmdExtra1
        '
        Me.cmdExtra1.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdExtra1.Enabled = False
        Me.cmdExtra1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdExtra1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExtra1.Location = New System.Drawing.Point(8, 208)
        Me.cmdExtra1.Name = "cmdExtra1"
        Me.cmdExtra1.Size = New System.Drawing.Size(50, 50)
        Me.cmdExtra1.TabIndex = 112
        Me.cmdExtra1.TabStop = False
        '
        'cmdSpace
        '
        Me.cmdSpace.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdSpace.Location = New System.Drawing.Point(136, 208)
        Me.cmdSpace.Name = "cmdSpace"
        Me.cmdSpace.Size = New System.Drawing.Size(368, 50)
        Me.cmdSpace.TabIndex = 111
        Me.cmdSpace.TabStop = False
        '
        'cmdW
        '
        Me.cmdW.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdW.Location = New System.Drawing.Point(456, 144)
        Me.cmdW.Name = "cmdW"
        Me.cmdW.Size = New System.Drawing.Size(50, 50)
        Me.cmdW.TabIndex = 110
        Me.cmdW.TabStop = False
        Me.cmdW.Text = "Ù"
        '
        'cmdPS
        '
        Me.cmdPS.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPS.Location = New System.Drawing.Point(392, 144)
        Me.cmdPS.Name = "cmdPS"
        Me.cmdPS.Size = New System.Drawing.Size(50, 50)
        Me.cmdPS.TabIndex = 109
        Me.cmdPS.TabStop = False
        Me.cmdPS.Text = "Ø"
        '
        'cmdX
        '
        Me.cmdX.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdX.Location = New System.Drawing.Point(328, 144)
        Me.cmdX.Name = "cmdX"
        Me.cmdX.Size = New System.Drawing.Size(50, 50)
        Me.cmdX.TabIndex = 108
        Me.cmdX.TabStop = False
        Me.cmdX.Text = "×"
        '
        'cmdF
        '
        Me.cmdF.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdF.Location = New System.Drawing.Point(264, 144)
        Me.cmdF.Name = "cmdF"
        Me.cmdF.Size = New System.Drawing.Size(50, 50)
        Me.cmdF.TabIndex = 107
        Me.cmdF.TabStop = False
        Me.cmdF.Text = "Ö"
        '
        'cmdY
        '
        Me.cmdY.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdY.Location = New System.Drawing.Point(200, 144)
        Me.cmdY.Name = "cmdY"
        Me.cmdY.Size = New System.Drawing.Size(50, 50)
        Me.cmdY.TabIndex = 106
        Me.cmdY.TabStop = False
        Me.cmdY.Text = "Õ"
        '
        'cmdT
        '
        Me.cmdT.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdT.Location = New System.Drawing.Point(136, 144)
        Me.cmdT.Name = "cmdT"
        Me.cmdT.Size = New System.Drawing.Size(50, 50)
        Me.cmdT.TabIndex = 105
        Me.cmdT.TabStop = False
        Me.cmdT.Text = "Ô"
        '
        'cmdS
        '
        Me.cmdS.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdS.Location = New System.Drawing.Point(72, 144)
        Me.cmdS.Name = "cmdS"
        Me.cmdS.Size = New System.Drawing.Size(50, 50)
        Me.cmdS.TabIndex = 104
        Me.cmdS.TabStop = False
        Me.cmdS.Text = "Ó"
        '
        'cmdR
        '
        Me.cmdR.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdR.Location = New System.Drawing.Point(8, 144)
        Me.cmdR.Name = "cmdR"
        Me.cmdR.Size = New System.Drawing.Size(50, 50)
        Me.cmdR.TabIndex = 103
        Me.cmdR.TabStop = False
        Me.cmdR.Text = "Ñ"
        '
        'cmdP
        '
        Me.cmdP.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdP.Location = New System.Drawing.Point(456, 80)
        Me.cmdP.Name = "cmdP"
        Me.cmdP.Size = New System.Drawing.Size(50, 50)
        Me.cmdP.TabIndex = 102
        Me.cmdP.TabStop = False
        Me.cmdP.Text = "Ð"
        '
        'cmdO
        '
        Me.cmdO.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdO.Location = New System.Drawing.Point(392, 80)
        Me.cmdO.Name = "cmdO"
        Me.cmdO.Size = New System.Drawing.Size(50, 50)
        Me.cmdO.TabIndex = 101
        Me.cmdO.TabStop = False
        Me.cmdO.Text = "Ï"
        '
        'cmdKS
        '
        Me.cmdKS.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdKS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdKS.Location = New System.Drawing.Point(328, 80)
        Me.cmdKS.Name = "cmdKS"
        Me.cmdKS.Size = New System.Drawing.Size(50, 50)
        Me.cmdKS.TabIndex = 100
        Me.cmdKS.TabStop = False
        Me.cmdKS.Text = "Î"
        '
        'cmdN
        '
        Me.cmdN.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdN.Location = New System.Drawing.Point(264, 80)
        Me.cmdN.Name = "cmdN"
        Me.cmdN.Size = New System.Drawing.Size(50, 50)
        Me.cmdN.TabIndex = 99
        Me.cmdN.TabStop = False
        Me.cmdN.Text = "Í"
        '
        'cmdM
        '
        Me.cmdM.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdM.Location = New System.Drawing.Point(200, 80)
        Me.cmdM.Name = "cmdM"
        Me.cmdM.Size = New System.Drawing.Size(50, 50)
        Me.cmdM.TabIndex = 98
        Me.cmdM.TabStop = False
        Me.cmdM.Text = "Ì"
        '
        'cmdL
        '
        Me.cmdL.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdL.Location = New System.Drawing.Point(136, 80)
        Me.cmdL.Name = "cmdL"
        Me.cmdL.Size = New System.Drawing.Size(50, 50)
        Me.cmdL.TabIndex = 97
        Me.cmdL.TabStop = False
        Me.cmdL.Text = "Ë"
        '
        'cmdK
        '
        Me.cmdK.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdK.Location = New System.Drawing.Point(72, 80)
        Me.cmdK.Name = "cmdK"
        Me.cmdK.Size = New System.Drawing.Size(50, 50)
        Me.cmdK.TabIndex = 96
        Me.cmdK.TabStop = False
        Me.cmdK.Text = "Ê"
        '
        'cmdI
        '
        Me.cmdI.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdI.Location = New System.Drawing.Point(8, 80)
        Me.cmdI.Name = "cmdI"
        Me.cmdI.Size = New System.Drawing.Size(50, 50)
        Me.cmdI.TabIndex = 95
        Me.cmdI.TabStop = False
        Me.cmdI.Text = "É"
        '
        'cmdTH
        '
        Me.cmdTH.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdTH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTH.Location = New System.Drawing.Point(456, 16)
        Me.cmdTH.Name = "cmdTH"
        Me.cmdTH.Size = New System.Drawing.Size(50, 50)
        Me.cmdTH.TabIndex = 94
        Me.cmdTH.TabStop = False
        Me.cmdTH.Text = "È"
        '
        'cmdH
        '
        Me.cmdH.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdH.Location = New System.Drawing.Point(392, 16)
        Me.cmdH.Name = "cmdH"
        Me.cmdH.Size = New System.Drawing.Size(50, 50)
        Me.cmdH.TabIndex = 93
        Me.cmdH.TabStop = False
        Me.cmdH.Text = "Ç"
        '
        'cmdZ
        '
        Me.cmdZ.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdZ.Location = New System.Drawing.Point(327, 15)
        Me.cmdZ.Name = "cmdZ"
        Me.cmdZ.Size = New System.Drawing.Size(50, 50)
        Me.cmdZ.TabIndex = 92
        Me.cmdZ.TabStop = False
        Me.cmdZ.Text = "Æ"
        '
        'cmdE
        '
        Me.cmdE.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdE.Location = New System.Drawing.Point(263, 15)
        Me.cmdE.Name = "cmdE"
        Me.cmdE.Size = New System.Drawing.Size(50, 50)
        Me.cmdE.TabIndex = 91
        Me.cmdE.TabStop = False
        Me.cmdE.Text = "Å"
        '
        'cmdD
        '
        Me.cmdD.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdD.Location = New System.Drawing.Point(199, 15)
        Me.cmdD.Name = "cmdD"
        Me.cmdD.Size = New System.Drawing.Size(50, 50)
        Me.cmdD.TabIndex = 90
        Me.cmdD.TabStop = False
        Me.cmdD.Text = "Ä"
        '
        'cmdG
        '
        Me.cmdG.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdG.Location = New System.Drawing.Point(135, 15)
        Me.cmdG.Name = "cmdG"
        Me.cmdG.Size = New System.Drawing.Size(50, 50)
        Me.cmdG.TabIndex = 89
        Me.cmdG.TabStop = False
        Me.cmdG.Text = "Ã"
        '
        'cmdB
        '
        Me.cmdB.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdB.Location = New System.Drawing.Point(71, 15)
        Me.cmdB.Name = "cmdB"
        Me.cmdB.Size = New System.Drawing.Size(50, 50)
        Me.cmdB.TabIndex = 88
        Me.cmdB.TabStop = False
        Me.cmdB.Text = "Â"
        '
        'cmdA
        '
        Me.cmdA.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdA.Location = New System.Drawing.Point(7, 15)
        Me.cmdA.Name = "cmdA"
        Me.cmdA.Size = New System.Drawing.Size(50, 50)
        Me.cmdA.TabIndex = 87
        Me.cmdA.TabStop = False
        Me.cmdA.Text = "Á"
        '
        'cmdBack
        '
        Me.cmdBack.BackColor = System.Drawing.Color.CadetBlue
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(527, 15)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(50, 115)
        Me.cmdBack.TabIndex = 93
        Me.cmdBack.TabStop = False
        Me.cmdBack.Text = "<--"
        '
        'FrmKeyboard
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(794, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.pnlNumbers)
        Me.Controls.Add(Me.pnlLetters)
        Me.Enabled = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(112, 470)
        Me.Name = "FrmKeyboard"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ðëçêôñïëüãéï"
        Me.pnlNumbers.ResumeLayout(False)
        Me.pnlLetters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub setTxt(ByRef _txt)
        ' Sets the active textBox
        activeTxt = _txt
    End Sub

    Public Sub emptyBuffer()
        ' Emptys the buffer of the keyboard
        buffer = ""
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        ' Deletes the last character of the buffer
        buffer = activeTxt.Text
        If Len(buffer) > 1 Then
            buffer = Mid(buffer, 1, Len(buffer) - 1)
        Else
            buffer = ""
        End If
        ' The buffer is then copied to the active textbox
        activeTxt.Text = buffer
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "1"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "2"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "3"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "4"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "5"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "6"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "7"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "8"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "9"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmd0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd0.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "0"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdA.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "A"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "A"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdB.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Â"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "B"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdG.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ã"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "C"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdD.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ä"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "D"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdE.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Å"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "E"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZ.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Æ"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "F"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdH.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ç"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "G"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdTH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTH.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "È"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "H"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdI.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "É"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "I"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdK.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ê"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "J"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdL.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ë"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "K"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdM.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ì"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "L"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdN.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Í"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "M"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdKS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKS.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Î"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "N"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdO.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ï"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "O"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdP.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ð"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "P"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdR.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ñ"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "Q"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdS.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ó"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "R"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdT.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ô"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "S"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdY.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Õ"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "T"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ö"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "U"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdX.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "×"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "V"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPS.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ø"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "W"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdW.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        If greekOrLatin = True Then
            buffer = buffer + "Ù"
            activeTxt.Text = buffer
        Else
            buffer = buffer + "X"
            activeTxt.Text = buffer
        End If
        activeTxt.Modified = True
    End Sub

    Private Sub cmdExtra1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExtra1.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "Y"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmdExtra2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExtra2.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + "Z"
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmdSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSpace.Click
        ' Adds the appropriate character to the active textbox
        buffer = activeTxt.Text
        buffer = buffer + " "
        activeTxt.Text = buffer
        activeTxt.Modified = True
    End Sub

    Private Sub cmdLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLang.Click
        ' Changes the language of the keyboard from greek to english or vise versa
        If greekOrLatin = True Then
            cmdA.Text = "A"
            cmdB.Text = "B"
            cmdG.Text = "C"
            cmdD.Text = "D"
            cmdE.Text = "E"
            cmdZ.Text = "F"
            cmdH.Text = "G"
            cmdTH.Text = "H"
            cmdI.Text = "I"
            cmdK.Text = "J"
            cmdL.Text = "K"
            cmdM.Text = "L"
            cmdN.Text = "M"
            cmdKS.Text = "N"
            cmdO.Text = "O"
            cmdP.Text = "P"
            cmdR.Text = "Q"
            cmdS.Text = "R"
            cmdT.Text = "S"
            cmdY.Text = "T"
            cmdF.Text = "U"
            cmdX.Text = "V"
            cmdPS.Text = "W"
            cmdW.Text = "X"
            cmdExtra1.Enabled = True
            cmdExtra1.Text = "Y"
            cmdExtra2.Enabled = True
            cmdExtra2.Text = "Z"
            greekOrLatin = False
            cmdLang.Image = Image.FromFile("flag_uk.gif")
            cmdLang.Text = "ENG"
        Else
            cmdA.Text = "Á"
            cmdB.Text = "Â"
            cmdG.Text = "Ã"
            cmdD.Text = "Ä"
            cmdE.Text = "Å"
            cmdZ.Text = "Æ"
            cmdH.Text = "Ç"
            cmdTH.Text = "È"
            cmdI.Text = "É"
            cmdK.Text = "Ê"
            cmdL.Text = "Ë"
            cmdM.Text = "Ì"
            cmdN.Text = "Í"
            cmdKS.Text = "Î"
            cmdO.Text = "Ï"
            cmdP.Text = "Ð"
            cmdR.Text = "Ñ"
            cmdS.Text = "Ó"
            cmdT.Text = "Ô"
            cmdY.Text = "Õ"
            cmdF.Text = "Ö"
            cmdX.Text = "×"
            cmdPS.Text = "Ø"
            cmdW.Text = "Ù"
            cmdExtra1.Enabled = False
            cmdExtra1.Text = ""
            cmdExtra2.Enabled = False
            cmdExtra2.Text = ""
            greekOrLatin = True
            cmdLang.Image = Image.FromFile("flag_gr.gif")
            cmdLang.Text = "ÅËË"
        End If
    End Sub

    Private Sub frmKeyboard_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
        ' Highlights the keyboard
        Me.Activate()
    End Sub
End Class