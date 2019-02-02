Public Class FrmMain
    Inherits System.Windows.Forms.Form

    Private orders As frmOrder

    Private sbOwners As New ArrayList
    Private logedInOwners As New ArrayList
    Private managers As New ArrayList
    Private logedInManager As Person
    Private employees As New ArrayList
    Private logedInEmployees As New ArrayList
    Private managersCashRegister As New Cash
    Private dayCashRegister As New Cash
    Private cashRegisters As New ArrayList
    Public cashiersCount As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim i As Integer
        For i = 0 To 1
            cashRegisters.Add(New Cash)
        Next
        orders = New frmOrder(cashRegisters, managersCashRegister)

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
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents pnlFirstFloor As System.Windows.Forms.Panel
    Friend WithEvents cmdTable34 As System.Windows.Forms.Button
    Friend WithEvents cmdTable30 As System.Windows.Forms.Button
    Friend WithEvents cmdTable26 As System.Windows.Forms.Button
    Friend WithEvents cmdTable22 As System.Windows.Forms.Button
    Friend WithEvents cmdTable32 As System.Windows.Forms.Button
    Friend WithEvents cmdTable31 As System.Windows.Forms.Button
    Friend WithEvents cmdTable29 As System.Windows.Forms.Button
    Friend WithEvents cmdTable28 As System.Windows.Forms.Button
    Friend WithEvents cmdTable27 As System.Windows.Forms.Button
    Friend WithEvents cmdTable25 As System.Windows.Forms.Button
    Friend WithEvents cmdTable24 As System.Windows.Forms.Button
    Friend WithEvents cmdTable23 As System.Windows.Forms.Button
    Friend WithEvents cmdTable21 As System.Windows.Forms.Button
    Friend WithEvents cmdTable20 As System.Windows.Forms.Button
    Friend WithEvents cmdTable19 As System.Windows.Forms.Button
    Friend WithEvents cmdTable18 As System.Windows.Forms.Button
    Friend WithEvents cmdTable17 As System.Windows.Forms.Button
    Friend WithEvents pnlGroundFloor As System.Windows.Forms.Panel
    Friend WithEvents cmdCouch8 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch7 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch6 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch5 As System.Windows.Forms.Button
    Friend WithEvents cmdTable16 As System.Windows.Forms.Button
    Friend WithEvents cmdTable12 As System.Windows.Forms.Button
    Friend WithEvents cmdTable8 As System.Windows.Forms.Button
    Friend WithEvents cmdTable4 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch4 As System.Windows.Forms.Button
    Friend WithEvents cmdTable15 As System.Windows.Forms.Button
    Friend WithEvents cmdTable14 As System.Windows.Forms.Button
    Friend WithEvents cmdTable13 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch3 As System.Windows.Forms.Button
    Friend WithEvents cmdTable11 As System.Windows.Forms.Button
    Friend WithEvents cmdTable10 As System.Windows.Forms.Button
    Friend WithEvents cmdTable9 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch2 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch1 As System.Windows.Forms.Button
    Friend WithEvents cmdTable7 As System.Windows.Forms.Button
    Friend WithEvents cmdTable6 As System.Windows.Forms.Button
    Friend WithEvents cmdTable5 As System.Windows.Forms.Button
    Friend WithEvents cmdTable3 As System.Windows.Forms.Button
    Friend WithEvents cmdTable2 As System.Windows.Forms.Button
    Friend WithEvents cmdTable1 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch17 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch15 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch14 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch13 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch12 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch10 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch9 As System.Windows.Forms.Button
    Friend WithEvents lblSBM As System.Windows.Forms.Label
    Friend WithEvents cmdTable33 As System.Windows.Forms.Button
    Friend WithEvents cmdCouch11 As System.Windows.Forms.Button
    Friend WithEvents lblStairs As System.Windows.Forms.Label
    Friend WithEvents cmdCouch16 As System.Windows.Forms.Button
    Friend WithEvents cmdInsertEmployee As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteEmployee As System.Windows.Forms.Button
    Friend WithEvents cmdLongIn As System.Windows.Forms.Button
    Friend WithEvents cmdLogOut As System.Windows.Forms.Button
    Friend WithEvents cmdLock As System.Windows.Forms.Button
    Friend WithEvents chkGroundFloor As System.Windows.Forms.CheckBox
    Friend WithEvents chkFirstFloor As System.Windows.Forms.CheckBox
    Friend WithEvents lsvCurrentEmployees As System.Windows.Forms.ListView
    Friend WithEvents cmdChangeManager As System.Windows.Forms.Button
    Friend WithEvents cmdFunctions As System.Windows.Forms.Button
    Friend WithEvents pnlMainButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlFunctions As System.Windows.Forms.Panel
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents presentPerson As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsDuties As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsId As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdBar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmMain))
        Me.cmdExit = New System.Windows.Forms.Button
        Me.pnlFirstFloor = New System.Windows.Forms.Panel
        Me.cmdCouch9 = New System.Windows.Forms.Button
        Me.cmdTable18 = New System.Windows.Forms.Button
        Me.cmdTable17 = New System.Windows.Forms.Button
        Me.cmdCouch17 = New System.Windows.Forms.Button
        Me.cmdCouch16 = New System.Windows.Forms.Button
        Me.cmdCouch15 = New System.Windows.Forms.Button
        Me.cmdCouch14 = New System.Windows.Forms.Button
        Me.cmdTable34 = New System.Windows.Forms.Button
        Me.cmdTable30 = New System.Windows.Forms.Button
        Me.cmdTable26 = New System.Windows.Forms.Button
        Me.cmdTable22 = New System.Windows.Forms.Button
        Me.cmdCouch13 = New System.Windows.Forms.Button
        Me.cmdTable33 = New System.Windows.Forms.Button
        Me.cmdTable32 = New System.Windows.Forms.Button
        Me.cmdTable31 = New System.Windows.Forms.Button
        Me.cmdCouch12 = New System.Windows.Forms.Button
        Me.cmdTable29 = New System.Windows.Forms.Button
        Me.cmdTable28 = New System.Windows.Forms.Button
        Me.cmdTable27 = New System.Windows.Forms.Button
        Me.cmdCouch11 = New System.Windows.Forms.Button
        Me.cmdCouch10 = New System.Windows.Forms.Button
        Me.cmdTable25 = New System.Windows.Forms.Button
        Me.cmdTable24 = New System.Windows.Forms.Button
        Me.cmdTable23 = New System.Windows.Forms.Button
        Me.cmdTable21 = New System.Windows.Forms.Button
        Me.cmdTable20 = New System.Windows.Forms.Button
        Me.cmdTable19 = New System.Windows.Forms.Button
        Me.cmdInsertEmployee = New System.Windows.Forms.Button
        Me.pnlGroundFloor = New System.Windows.Forms.Panel
        Me.cmdBar = New System.Windows.Forms.Button
        Me.cmdCouch8 = New System.Windows.Forms.Button
        Me.cmdCouch7 = New System.Windows.Forms.Button
        Me.cmdCouch6 = New System.Windows.Forms.Button
        Me.cmdCouch5 = New System.Windows.Forms.Button
        Me.cmdTable16 = New System.Windows.Forms.Button
        Me.cmdTable12 = New System.Windows.Forms.Button
        Me.cmdTable8 = New System.Windows.Forms.Button
        Me.cmdTable4 = New System.Windows.Forms.Button
        Me.cmdCouch4 = New System.Windows.Forms.Button
        Me.cmdTable15 = New System.Windows.Forms.Button
        Me.cmdTable14 = New System.Windows.Forms.Button
        Me.cmdTable13 = New System.Windows.Forms.Button
        Me.cmdCouch3 = New System.Windows.Forms.Button
        Me.cmdTable11 = New System.Windows.Forms.Button
        Me.cmdTable10 = New System.Windows.Forms.Button
        Me.cmdTable9 = New System.Windows.Forms.Button
        Me.cmdCouch2 = New System.Windows.Forms.Button
        Me.cmdCouch1 = New System.Windows.Forms.Button
        Me.cmdTable7 = New System.Windows.Forms.Button
        Me.cmdTable6 = New System.Windows.Forms.Button
        Me.cmdTable5 = New System.Windows.Forms.Button
        Me.cmdTable3 = New System.Windows.Forms.Button
        Me.cmdTable2 = New System.Windows.Forms.Button
        Me.cmdTable1 = New System.Windows.Forms.Button
        Me.cmdDeleteEmployee = New System.Windows.Forms.Button
        Me.lblSBM = New System.Windows.Forms.Label
        Me.cmdLongIn = New System.Windows.Forms.Button
        Me.lblStairs = New System.Windows.Forms.Label
        Me.cmdLogOut = New System.Windows.Forms.Button
        Me.cmdLock = New System.Windows.Forms.Button
        Me.chkGroundFloor = New System.Windows.Forms.CheckBox
        Me.chkFirstFloor = New System.Windows.Forms.CheckBox
        Me.cmdFunctions = New System.Windows.Forms.Button
        Me.lsvCurrentEmployees = New System.Windows.Forms.ListView
        Me.presentPerson = New System.Windows.Forms.ColumnHeader
        Me.personsDuties = New System.Windows.Forms.ColumnHeader
        Me.personsId = New System.Windows.Forms.ColumnHeader
        Me.cmdChangeManager = New System.Windows.Forms.Button
        Me.pnlMainButtons = New System.Windows.Forms.Panel
        Me.pnlFunctions = New System.Windows.Forms.Panel
        Me.cmdBack = New System.Windows.Forms.Button
        Me.pnlFirstFloor.SuspendLayout()
        Me.pnlGroundFloor.SuspendLayout()
        Me.pnlMainButtons.SuspendLayout()
        Me.pnlFunctions.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.IndianRed
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.White
        Me.cmdExit.Location = New System.Drawing.Point(888, 8)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(128, 75)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "ÅÎÏÄÏÓ"
        '
        'pnlFirstFloor
        '
        Me.pnlFirstFloor.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlFirstFloor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch9)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable18)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable17)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch17)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch16)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch15)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch14)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable34)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable30)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable26)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable22)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch13)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable33)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable32)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable31)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch12)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable29)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable28)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable27)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch11)
        Me.pnlFirstFloor.Controls.Add(Me.cmdCouch10)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable25)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable24)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable23)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable21)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable20)
        Me.pnlFirstFloor.Controls.Add(Me.cmdTable19)
        Me.pnlFirstFloor.Location = New System.Drawing.Point(17, 40)
        Me.pnlFirstFloor.Name = "pnlFirstFloor"
        Me.pnlFirstFloor.Size = New System.Drawing.Size(496, 616)
        Me.pnlFirstFloor.TabIndex = 4
        Me.pnlFirstFloor.Visible = False
        '
        'cmdCouch9
        '
        Me.cmdCouch9.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch9.Enabled = False
        Me.cmdCouch9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch9.Location = New System.Drawing.Point(16, 24)
        Me.cmdCouch9.Name = "cmdCouch9"
        Me.cmdCouch9.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch9.TabIndex = 79
        '
        'cmdTable18
        '
        Me.cmdTable18.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable18.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable18.Location = New System.Drawing.Point(160, 24)
        Me.cmdTable18.Name = "cmdTable18"
        Me.cmdTable18.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable18.TabIndex = 78
        Me.cmdTable18.Text = "18"
        '
        'cmdTable17
        '
        Me.cmdTable17.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable17.Location = New System.Drawing.Point(40, 24)
        Me.cmdTable17.Name = "cmdTable17"
        Me.cmdTable17.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable17.TabIndex = 77
        Me.cmdTable17.Text = "17"
        '
        'cmdCouch17
        '
        Me.cmdCouch17.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch17.Enabled = False
        Me.cmdCouch17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch17.Location = New System.Drawing.Point(400, 580)
        Me.cmdCouch17.Name = "cmdCouch17"
        Me.cmdCouch17.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch17.TabIndex = 76
        '
        'cmdCouch16
        '
        Me.cmdCouch16.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch16.Enabled = False
        Me.cmdCouch16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch16.Location = New System.Drawing.Point(280, 580)
        Me.cmdCouch16.Name = "cmdCouch16"
        Me.cmdCouch16.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch16.TabIndex = 75
        '
        'cmdCouch15
        '
        Me.cmdCouch15.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch15.Enabled = False
        Me.cmdCouch15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch15.Location = New System.Drawing.Point(160, 580)
        Me.cmdCouch15.Name = "cmdCouch15"
        Me.cmdCouch15.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch15.TabIndex = 74
        '
        'cmdCouch14
        '
        Me.cmdCouch14.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch14.Enabled = False
        Me.cmdCouch14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch14.Location = New System.Drawing.Point(40, 580)
        Me.cmdCouch14.Name = "cmdCouch14"
        Me.cmdCouch14.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch14.TabIndex = 73
        '
        'cmdTable34
        '
        Me.cmdTable34.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable34.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable34.Location = New System.Drawing.Point(400, 497)
        Me.cmdTable34.Name = "cmdTable34"
        Me.cmdTable34.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable34.TabIndex = 72
        Me.cmdTable34.Text = "34"
        '
        'cmdTable30
        '
        Me.cmdTable30.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable30.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable30.Location = New System.Drawing.Point(400, 384)
        Me.cmdTable30.Name = "cmdTable30"
        Me.cmdTable30.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable30.TabIndex = 71
        Me.cmdTable30.Text = "30"
        '
        'cmdTable26
        '
        Me.cmdTable26.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable26.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable26.Location = New System.Drawing.Point(400, 264)
        Me.cmdTable26.Name = "cmdTable26"
        Me.cmdTable26.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable26.TabIndex = 70
        Me.cmdTable26.Text = "26"
        '
        'cmdTable22
        '
        Me.cmdTable22.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable22.Location = New System.Drawing.Point(400, 144)
        Me.cmdTable22.Name = "cmdTable22"
        Me.cmdTable22.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable22.TabIndex = 69
        Me.cmdTable22.Text = "22"
        '
        'cmdCouch13
        '
        Me.cmdCouch13.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch13.Enabled = False
        Me.cmdCouch13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch13.Location = New System.Drawing.Point(16, 497)
        Me.cmdCouch13.Name = "cmdCouch13"
        Me.cmdCouch13.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch13.TabIndex = 68
        '
        'cmdTable33
        '
        Me.cmdTable33.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable33.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable33.Location = New System.Drawing.Point(280, 497)
        Me.cmdTable33.Name = "cmdTable33"
        Me.cmdTable33.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable33.TabIndex = 67
        Me.cmdTable33.Text = "33"
        '
        'cmdTable32
        '
        Me.cmdTable32.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable32.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable32.Location = New System.Drawing.Point(160, 497)
        Me.cmdTable32.Name = "cmdTable32"
        Me.cmdTable32.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable32.TabIndex = 66
        Me.cmdTable32.Text = "32"
        '
        'cmdTable31
        '
        Me.cmdTable31.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable31.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable31.Location = New System.Drawing.Point(40, 497)
        Me.cmdTable31.Name = "cmdTable31"
        Me.cmdTable31.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable31.TabIndex = 65
        Me.cmdTable31.Text = "31"
        '
        'cmdCouch12
        '
        Me.cmdCouch12.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch12.Enabled = False
        Me.cmdCouch12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch12.Location = New System.Drawing.Point(16, 384)
        Me.cmdCouch12.Name = "cmdCouch12"
        Me.cmdCouch12.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch12.TabIndex = 64
        '
        'cmdTable29
        '
        Me.cmdTable29.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable29.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable29.Location = New System.Drawing.Point(280, 384)
        Me.cmdTable29.Name = "cmdTable29"
        Me.cmdTable29.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable29.TabIndex = 63
        Me.cmdTable29.Text = "29"
        '
        'cmdTable28
        '
        Me.cmdTable28.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable28.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable28.Location = New System.Drawing.Point(160, 384)
        Me.cmdTable28.Name = "cmdTable28"
        Me.cmdTable28.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable28.TabIndex = 62
        Me.cmdTable28.Text = "28"
        '
        'cmdTable27
        '
        Me.cmdTable27.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable27.Location = New System.Drawing.Point(40, 384)
        Me.cmdTable27.Name = "cmdTable27"
        Me.cmdTable27.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable27.TabIndex = 61
        Me.cmdTable27.Text = "27"
        '
        'cmdCouch11
        '
        Me.cmdCouch11.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch11.Enabled = False
        Me.cmdCouch11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch11.Location = New System.Drawing.Point(16, 264)
        Me.cmdCouch11.Name = "cmdCouch11"
        Me.cmdCouch11.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch11.TabIndex = 60
        '
        'cmdCouch10
        '
        Me.cmdCouch10.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch10.Enabled = False
        Me.cmdCouch10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch10.Location = New System.Drawing.Point(16, 144)
        Me.cmdCouch10.Name = "cmdCouch10"
        Me.cmdCouch10.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch10.TabIndex = 59
        '
        'cmdTable25
        '
        Me.cmdTable25.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable25.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable25.Location = New System.Drawing.Point(280, 264)
        Me.cmdTable25.Name = "cmdTable25"
        Me.cmdTable25.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable25.TabIndex = 58
        Me.cmdTable25.Text = "25"
        '
        'cmdTable24
        '
        Me.cmdTable24.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable24.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable24.Location = New System.Drawing.Point(160, 264)
        Me.cmdTable24.Name = "cmdTable24"
        Me.cmdTable24.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable24.TabIndex = 57
        Me.cmdTable24.Text = "24"
        '
        'cmdTable23
        '
        Me.cmdTable23.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable23.Location = New System.Drawing.Point(40, 264)
        Me.cmdTable23.Name = "cmdTable23"
        Me.cmdTable23.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable23.TabIndex = 56
        Me.cmdTable23.Text = "23"
        '
        'cmdTable21
        '
        Me.cmdTable21.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable21.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable21.Location = New System.Drawing.Point(280, 144)
        Me.cmdTable21.Name = "cmdTable21"
        Me.cmdTable21.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable21.TabIndex = 55
        Me.cmdTable21.Text = "21"
        '
        'cmdTable20
        '
        Me.cmdTable20.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable20.Location = New System.Drawing.Point(160, 144)
        Me.cmdTable20.Name = "cmdTable20"
        Me.cmdTable20.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable20.TabIndex = 54
        Me.cmdTable20.Text = "20"
        '
        'cmdTable19
        '
        Me.cmdTable19.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable19.Location = New System.Drawing.Point(40, 144)
        Me.cmdTable19.Name = "cmdTable19"
        Me.cmdTable19.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable19.TabIndex = 53
        Me.cmdTable19.Text = "19"
        '
        'cmdInsertEmployee
        '
        Me.cmdInsertEmployee.BackColor = System.Drawing.Color.LightCyan
        Me.cmdInsertEmployee.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdInsertEmployee.Image = CType(resources.GetObject("cmdInsertEmployee.Image"), System.Drawing.Image)
        Me.cmdInsertEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdInsertEmployee.Location = New System.Drawing.Point(8, 8)
        Me.cmdInsertEmployee.Name = "cmdInsertEmployee"
        Me.cmdInsertEmployee.Size = New System.Drawing.Size(160, 75)
        Me.cmdInsertEmployee.TabIndex = 8
        Me.cmdInsertEmployee.Text = "ÅÉÓÁÃÙÃÇ ÍÅÏÕ ÕÐÁËËÇËÏÕ"
        Me.cmdInsertEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlGroundFloor
        '
        Me.pnlGroundFloor.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlGroundFloor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlGroundFloor.Controls.Add(Me.cmdBar)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch8)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch7)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch6)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch5)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable16)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable12)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable8)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable4)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch4)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable15)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable14)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable13)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch3)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable11)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable10)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable9)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch2)
        Me.pnlGroundFloor.Controls.Add(Me.cmdCouch1)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable7)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable6)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable5)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable3)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable2)
        Me.pnlGroundFloor.Controls.Add(Me.cmdTable1)
        Me.pnlGroundFloor.Location = New System.Drawing.Point(17, 40)
        Me.pnlGroundFloor.Name = "pnlGroundFloor"
        Me.pnlGroundFloor.Size = New System.Drawing.Size(496, 616)
        Me.pnlGroundFloor.TabIndex = 11
        '
        'cmdBar
        '
        Me.cmdBar.BackColor = System.Drawing.Color.DarkGray
        Me.cmdBar.Enabled = False
        Me.cmdBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBar.Location = New System.Drawing.Point(16, 16)
        Me.cmdBar.Name = "cmdBar"
        Me.cmdBar.Size = New System.Drawing.Size(296, 75)
        Me.cmdBar.TabIndex = 77
        Me.cmdBar.Text = "BAR"
        '
        'cmdCouch8
        '
        Me.cmdCouch8.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch8.Enabled = False
        Me.cmdCouch8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch8.Location = New System.Drawing.Point(400, 580)
        Me.cmdCouch8.Name = "cmdCouch8"
        Me.cmdCouch8.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch8.TabIndex = 76
        '
        'cmdCouch7
        '
        Me.cmdCouch7.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch7.Enabled = False
        Me.cmdCouch7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch7.Location = New System.Drawing.Point(280, 580)
        Me.cmdCouch7.Name = "cmdCouch7"
        Me.cmdCouch7.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch7.TabIndex = 75
        '
        'cmdCouch6
        '
        Me.cmdCouch6.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch6.Enabled = False
        Me.cmdCouch6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch6.Location = New System.Drawing.Point(160, 580)
        Me.cmdCouch6.Name = "cmdCouch6"
        Me.cmdCouch6.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch6.TabIndex = 74
        '
        'cmdCouch5
        '
        Me.cmdCouch5.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch5.Enabled = False
        Me.cmdCouch5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch5.Location = New System.Drawing.Point(40, 580)
        Me.cmdCouch5.Name = "cmdCouch5"
        Me.cmdCouch5.Size = New System.Drawing.Size(75, 16)
        Me.cmdCouch5.TabIndex = 73
        '
        'cmdTable16
        '
        Me.cmdTable16.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable16.Location = New System.Drawing.Point(400, 497)
        Me.cmdTable16.Name = "cmdTable16"
        Me.cmdTable16.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable16.TabIndex = 72
        Me.cmdTable16.Text = "16"
        '
        'cmdTable12
        '
        Me.cmdTable12.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable12.Location = New System.Drawing.Point(400, 384)
        Me.cmdTable12.Name = "cmdTable12"
        Me.cmdTable12.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable12.TabIndex = 71
        Me.cmdTable12.Text = "12"
        '
        'cmdTable8
        '
        Me.cmdTable8.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable8.Location = New System.Drawing.Point(400, 264)
        Me.cmdTable8.Name = "cmdTable8"
        Me.cmdTable8.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable8.TabIndex = 70
        Me.cmdTable8.Text = "8"
        '
        'cmdTable4
        '
        Me.cmdTable4.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable4.Location = New System.Drawing.Point(400, 144)
        Me.cmdTable4.Name = "cmdTable4"
        Me.cmdTable4.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable4.TabIndex = 69
        Me.cmdTable4.Text = "4"
        '
        'cmdCouch4
        '
        Me.cmdCouch4.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch4.Enabled = False
        Me.cmdCouch4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch4.Location = New System.Drawing.Point(16, 497)
        Me.cmdCouch4.Name = "cmdCouch4"
        Me.cmdCouch4.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch4.TabIndex = 68
        '
        'cmdTable15
        '
        Me.cmdTable15.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable15.Location = New System.Drawing.Point(280, 497)
        Me.cmdTable15.Name = "cmdTable15"
        Me.cmdTable15.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable15.TabIndex = 67
        Me.cmdTable15.Text = "15"
        '
        'cmdTable14
        '
        Me.cmdTable14.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable14.Location = New System.Drawing.Point(160, 497)
        Me.cmdTable14.Name = "cmdTable14"
        Me.cmdTable14.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable14.TabIndex = 66
        Me.cmdTable14.Text = "14"
        '
        'cmdTable13
        '
        Me.cmdTable13.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable13.Location = New System.Drawing.Point(40, 497)
        Me.cmdTable13.Name = "cmdTable13"
        Me.cmdTable13.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable13.TabIndex = 65
        Me.cmdTable13.Text = "13"
        '
        'cmdCouch3
        '
        Me.cmdCouch3.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch3.Enabled = False
        Me.cmdCouch3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch3.Location = New System.Drawing.Point(16, 384)
        Me.cmdCouch3.Name = "cmdCouch3"
        Me.cmdCouch3.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch3.TabIndex = 64
        '
        'cmdTable11
        '
        Me.cmdTable11.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable11.Location = New System.Drawing.Point(280, 384)
        Me.cmdTable11.Name = "cmdTable11"
        Me.cmdTable11.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable11.TabIndex = 63
        Me.cmdTable11.Text = "11"
        '
        'cmdTable10
        '
        Me.cmdTable10.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable10.Location = New System.Drawing.Point(160, 384)
        Me.cmdTable10.Name = "cmdTable10"
        Me.cmdTable10.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable10.TabIndex = 62
        Me.cmdTable10.Text = "10"
        '
        'cmdTable9
        '
        Me.cmdTable9.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable9.Location = New System.Drawing.Point(40, 384)
        Me.cmdTable9.Name = "cmdTable9"
        Me.cmdTable9.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable9.TabIndex = 61
        Me.cmdTable9.Text = "9"
        '
        'cmdCouch2
        '
        Me.cmdCouch2.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch2.Enabled = False
        Me.cmdCouch2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch2.Location = New System.Drawing.Point(16, 264)
        Me.cmdCouch2.Name = "cmdCouch2"
        Me.cmdCouch2.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch2.TabIndex = 60
        '
        'cmdCouch1
        '
        Me.cmdCouch1.BackColor = System.Drawing.Color.DarkGray
        Me.cmdCouch1.Enabled = False
        Me.cmdCouch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCouch1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCouch1.Location = New System.Drawing.Point(16, 144)
        Me.cmdCouch1.Name = "cmdCouch1"
        Me.cmdCouch1.Size = New System.Drawing.Size(16, 75)
        Me.cmdCouch1.TabIndex = 59
        '
        'cmdTable7
        '
        Me.cmdTable7.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable7.Location = New System.Drawing.Point(280, 264)
        Me.cmdTable7.Name = "cmdTable7"
        Me.cmdTable7.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable7.TabIndex = 58
        Me.cmdTable7.Text = "7"
        '
        'cmdTable6
        '
        Me.cmdTable6.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable6.Location = New System.Drawing.Point(160, 264)
        Me.cmdTable6.Name = "cmdTable6"
        Me.cmdTable6.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable6.TabIndex = 57
        Me.cmdTable6.Text = "6"
        '
        'cmdTable5
        '
        Me.cmdTable5.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable5.Location = New System.Drawing.Point(40, 264)
        Me.cmdTable5.Name = "cmdTable5"
        Me.cmdTable5.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable5.TabIndex = 56
        Me.cmdTable5.Text = "5"
        '
        'cmdTable3
        '
        Me.cmdTable3.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable3.Location = New System.Drawing.Point(280, 144)
        Me.cmdTable3.Name = "cmdTable3"
        Me.cmdTable3.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable3.TabIndex = 55
        Me.cmdTable3.Text = "3"
        '
        'cmdTable2
        '
        Me.cmdTable2.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable2.Location = New System.Drawing.Point(160, 144)
        Me.cmdTable2.Name = "cmdTable2"
        Me.cmdTable2.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable2.TabIndex = 54
        Me.cmdTable2.Text = "2"
        '
        'cmdTable1
        '
        Me.cmdTable1.BackColor = System.Drawing.Color.DarkGray
        Me.cmdTable1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdTable1.Location = New System.Drawing.Point(40, 144)
        Me.cmdTable1.Name = "cmdTable1"
        Me.cmdTable1.Size = New System.Drawing.Size(75, 75)
        Me.cmdTable1.TabIndex = 53
        Me.cmdTable1.Text = "1"
        '
        'cmdDeleteEmployee
        '
        Me.cmdDeleteEmployee.BackColor = System.Drawing.Color.LightCoral
        Me.cmdDeleteEmployee.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdDeleteEmployee.Image = CType(resources.GetObject("cmdDeleteEmployee.Image"), System.Drawing.Image)
        Me.cmdDeleteEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDeleteEmployee.Location = New System.Drawing.Point(184, 8)
        Me.cmdDeleteEmployee.Name = "cmdDeleteEmployee"
        Me.cmdDeleteEmployee.Size = New System.Drawing.Size(160, 75)
        Me.cmdDeleteEmployee.TabIndex = 12
        Me.cmdDeleteEmployee.Text = "ÄÉÁÃÑÁÖÇ ÕÐÁËËÇËÏÕ"
        Me.cmdDeleteEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSBM
        '
        Me.lblSBM.AutoSize = True
        Me.lblSBM.Enabled = False
        Me.lblSBM.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSBM.Location = New System.Drawing.Point(0, 0)
        Me.lblSBM.Name = "lblSBM"
        Me.lblSBM.Size = New System.Drawing.Size(326, 40)
        Me.lblSBM.TabIndex = 15
        Me.lblSBM.Text = "Snack Bar Manager©"
        '
        'cmdLongIn
        '
        Me.cmdLongIn.BackColor = System.Drawing.Color.Beige
        Me.cmdLongIn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLongIn.Image = CType(resources.GetObject("cmdLongIn.Image"), System.Drawing.Image)
        Me.cmdLongIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdLongIn.Location = New System.Drawing.Point(8, 8)
        Me.cmdLongIn.Name = "cmdLongIn"
        Me.cmdLongIn.Size = New System.Drawing.Size(160, 75)
        Me.cmdLongIn.TabIndex = 16
        Me.cmdLongIn.Text = "ÅÉÓÏÄÏÓ ÕÐÁËËÇËÏÕ"
        Me.cmdLongIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblStairs
        '
        Me.lblStairs.BackColor = System.Drawing.Color.Gainsboro
        Me.lblStairs.Enabled = False
        Me.lblStairs.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblStairs.Location = New System.Drawing.Point(341, 85)
        Me.lblStairs.Name = "lblStairs"
        Me.lblStairs.Size = New System.Drawing.Size(152, 32)
        Me.lblStairs.TabIndex = 78
        Me.lblStairs.Text = "ÓêÜëåò"
        Me.lblStairs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdLogOut
        '
        Me.cmdLogOut.BackColor = System.Drawing.Color.Beige
        Me.cmdLogOut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLogOut.Image = CType(resources.GetObject("cmdLogOut.Image"), System.Drawing.Image)
        Me.cmdLogOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdLogOut.Location = New System.Drawing.Point(184, 8)
        Me.cmdLogOut.Name = "cmdLogOut"
        Me.cmdLogOut.Size = New System.Drawing.Size(160, 75)
        Me.cmdLogOut.TabIndex = 79
        Me.cmdLogOut.Text = "ÅÎÏÄÏÓ ÕÐÁËËÇËÏÕ"
        Me.cmdLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdLock
        '
        Me.cmdLock.BackColor = System.Drawing.Color.Beige
        Me.cmdLock.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdLock.Image = CType(resources.GetObject("cmdLock.Image"), System.Drawing.Image)
        Me.cmdLock.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdLock.Location = New System.Drawing.Point(712, 8)
        Me.cmdLock.Name = "cmdLock"
        Me.cmdLock.Size = New System.Drawing.Size(160, 75)
        Me.cmdLock.TabIndex = 80
        Me.cmdLock.Text = "ÊËÅÉÄÙÌÁ ÏÈÏÍÇÓ"
        Me.cmdLock.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chkGroundFloor
        '
        Me.chkGroundFloor.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkGroundFloor.AutoCheck = False
        Me.chkGroundFloor.BackColor = System.Drawing.Color.CadetBlue
        Me.chkGroundFloor.Checked = True
        Me.chkGroundFloor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGroundFloor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkGroundFloor.ForeColor = System.Drawing.Color.White
        Me.chkGroundFloor.Location = New System.Drawing.Point(672, 264)
        Me.chkGroundFloor.Name = "chkGroundFloor"
        Me.chkGroundFloor.Size = New System.Drawing.Size(160, 75)
        Me.chkGroundFloor.TabIndex = 81
        Me.chkGroundFloor.Text = "ÉÓÏÃÅÉÏ"
        Me.chkGroundFloor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkFirstFloor
        '
        Me.chkFirstFloor.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFirstFloor.AutoCheck = False
        Me.chkFirstFloor.BackColor = System.Drawing.Color.DarkGray
        Me.chkFirstFloor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkFirstFloor.ForeColor = System.Drawing.Color.White
        Me.chkFirstFloor.Location = New System.Drawing.Point(856, 264)
        Me.chkFirstFloor.Name = "chkFirstFloor"
        Me.chkFirstFloor.Size = New System.Drawing.Size(160, 75)
        Me.chkFirstFloor.TabIndex = 82
        Me.chkFirstFloor.Text = "ÐÑÙÔÏÓ"
        Me.chkFirstFloor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdFunctions
        '
        Me.cmdFunctions.BackColor = System.Drawing.Color.Beige
        Me.cmdFunctions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdFunctions.Image = CType(resources.GetObject("cmdFunctions.Image"), System.Drawing.Image)
        Me.cmdFunctions.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdFunctions.Location = New System.Drawing.Point(536, 8)
        Me.cmdFunctions.Name = "cmdFunctions"
        Me.cmdFunctions.Size = New System.Drawing.Size(160, 75)
        Me.cmdFunctions.TabIndex = 83
        Me.cmdFunctions.Text = "ÁËËÅÓ ËÅÉÔÏÕÑÃÅÉÅÓ"
        Me.cmdFunctions.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lsvCurrentEmployees
        '
        Me.lsvCurrentEmployees.BackColor = System.Drawing.Color.White
        Me.lsvCurrentEmployees.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.presentPerson, Me.personsDuties, Me.personsId})
        Me.lsvCurrentEmployees.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lsvCurrentEmployees.FullRowSelect = True
        Me.lsvCurrentEmployees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvCurrentEmployees.Location = New System.Drawing.Point(672, 8)
        Me.lsvCurrentEmployees.MultiSelect = False
        Me.lsvCurrentEmployees.Name = "lsvCurrentEmployees"
        Me.lsvCurrentEmployees.Size = New System.Drawing.Size(344, 216)
        Me.lsvCurrentEmployees.TabIndex = 84
        Me.lsvCurrentEmployees.View = System.Windows.Forms.View.Details
        '
        'presentPerson
        '
        Me.presentPerson.Text = "ÐÁÑÏÍÔÅÓ ÕÐÁËËÇËÏÉ"
        Me.presentPerson.Width = 323
        '
        'personsDuties
        '
        Me.personsDuties.Text = "ÊÁÈÇÊÏÍÔÁ"
        Me.personsDuties.Width = 0
        '
        'personsId
        '
        Me.personsId.Text = "ÁÑÉÈÌÏÓ ÔÁÕÔÏÔÇÔÁÓ"
        Me.personsId.Width = 0
        '
        'cmdChangeManager
        '
        Me.cmdChangeManager.BackColor = System.Drawing.Color.Beige
        Me.cmdChangeManager.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdChangeManager.Image = CType(resources.GetObject("cmdChangeManager.Image"), System.Drawing.Image)
        Me.cmdChangeManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdChangeManager.Location = New System.Drawing.Point(360, 8)
        Me.cmdChangeManager.Name = "cmdChangeManager"
        Me.cmdChangeManager.Size = New System.Drawing.Size(160, 75)
        Me.cmdChangeManager.TabIndex = 85
        Me.cmdChangeManager.Text = "ÁËËÁÃÇ ÕÐÅÕÈÕÍÏÕ"
        Me.cmdChangeManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'pnlMainButtons
        '
        Me.pnlMainButtons.Controls.Add(Me.cmdLogOut)
        Me.pnlMainButtons.Controls.Add(Me.cmdExit)
        Me.pnlMainButtons.Controls.Add(Me.cmdLock)
        Me.pnlMainButtons.Controls.Add(Me.cmdFunctions)
        Me.pnlMainButtons.Controls.Add(Me.cmdLongIn)
        Me.pnlMainButtons.Controls.Add(Me.cmdChangeManager)
        Me.pnlMainButtons.Location = New System.Drawing.Point(0, 672)
        Me.pnlMainButtons.Name = "pnlMainButtons"
        Me.pnlMainButtons.Size = New System.Drawing.Size(1024, 96)
        Me.pnlMainButtons.TabIndex = 86
        '
        'pnlFunctions
        '
        Me.pnlFunctions.Controls.Add(Me.cmdBack)
        Me.pnlFunctions.Controls.Add(Me.cmdInsertEmployee)
        Me.pnlFunctions.Controls.Add(Me.cmdDeleteEmployee)
        Me.pnlFunctions.Location = New System.Drawing.Point(0, 672)
        Me.pnlFunctions.Name = "pnlFunctions"
        Me.pnlFunctions.Size = New System.Drawing.Size(1024, 96)
        Me.pnlFunctions.TabIndex = 87
        '
        'cmdBack
        '
        Me.cmdBack.BackColor = System.Drawing.Color.Chocolate
        Me.cmdBack.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdBack.ForeColor = System.Drawing.Color.White
        Me.cmdBack.Image = CType(resources.GetObject("cmdBack.Image"), System.Drawing.Image)
        Me.cmdBack.Location = New System.Drawing.Point(888, 8)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(128, 75)
        Me.cmdBack.TabIndex = 13
        Me.cmdBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'FrmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.lsvCurrentEmployees)
        Me.Controls.Add(Me.chkFirstFloor)
        Me.Controls.Add(Me.chkGroundFloor)
        Me.Controls.Add(Me.lblStairs)
        Me.Controls.Add(Me.lblSBM)
        Me.Controls.Add(Me.pnlGroundFloor)
        Me.Controls.Add(Me.pnlFirstFloor)
        Me.Controls.Add(Me.pnlMainButtons)
        Me.Controls.Add(Me.pnlFunctions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlFirstFloor.ResumeLayout(False)
        Me.pnlGroundFloor.ResumeLayout(False)
        Me.pnlMainButtons.ResumeLayout(False)
        Me.pnlFunctions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub changeManagerCashRegister(ByRef newManager As Person)
        dayCashRegister.handleMoney = managersCashRegister.getMoney
        MsgBox("Ï õðåýèõíïò ðáñáäßäåé: " + managersCashRegister.getMoneyAsString + "€")
        managersCashRegister.setNewUser(newManager)
        managersCashRegister.releaseCash()
    End Sub

    Public Sub increaseManagerCashRegister(ByVal amount)
        managersCashRegister.handleMoney = amount
    End Sub

    Public Sub setPresentManager(ByRef _manager As Person, ByRef position As Integer)
        ' The selected manager becomes the active one
        logedInManager = _manager
        ' The previous active manager is removed from the list of the managers
        managers.RemoveAt(position)
        ' The full name of the manager is added to the list view of the present employees
        Dim data As New ListViewItem(logedInManager.handleSurname + " " + logedInManager.handleName)
        data.SubItems.Add(logedInManager.handleDuty)
        data.SubItems.Add(logedInManager.handleId)
        lsvCurrentEmployees.Items.Add(data)
    End Sub

    Public Sub setPresent(ByRef tempPerson As Person, ByRef position As Integer, ByRef ownerOrEmployee As Boolean)
        ' The full name of the employee is added to the list view of the present employees
        Dim data As New ListViewItem(tempPerson.handleSurname + " " + tempPerson.handleName)
        data.SubItems.Add(tempPerson.handleDuty)
        data.SubItems.Add(tempPerson.handleId)
        lsvCurrentEmployees.Items.Add(data)
        ' If the ownerOrEmployee variable is true, then the new person is an owner 
        If ownerOrEmployee Then
            ' Removes the owner from the owners list
            sbOwners.RemoveAt(position)
            ' Adds the owner to the active owners list
            logedInOwners.Add(tempPerson)
        Else ' else the new person is an employee
            ' Removes the employee from the employees list
            employees.RemoveAt(position)
            ' Adds the employee to the active employees list
            logedInEmployees.Add(tempPerson)
        End If
    End Sub

    Public Sub exitSystem(ByRef tempPerson As Person, ByRef position As Integer, ByRef ownerOrEmployee As Boolean)
        ' The full name of the employee is deleted from the list view of the present employees
        Dim j As Integer
        For j = 0 To lsvCurrentEmployees.Items.Count - 1
            If lsvCurrentEmployees.Items.Item(j).SubItems(2).Text.Equals(tempPerson.handleId) Then
                ' When there is a match the manager is removed
                lsvCurrentEmployees.Items.RemoveAt(j)
                Exit For
            End If
        Next
        ' If the ownerOrEmployee variable is true, then the new person is an owner 
        If ownerOrEmployee Then
            ' Removes the owner from the longed in owners list
            logedInOwners.RemoveAt(position)
            ' Adds the owner to the owners list - the list of the owners that are not present
            sbOwners.Add(tempPerson)
        Else ' else the new person is an employee
            ' Removes the employee from the active employees list
            logedInEmployees.RemoveAt(position)
            ' Adds the employee to the employees list - the list of the employees that are not present
            employees.Add(tempPerson)
        End If
    End Sub

    Private Function createPerson(ByVal fileLine As String)
        Dim buffer As String
        ' A person object is consisted of 10 attributes
        Dim personAttribute(10) As String
        Dim i As Integer
        Dim j As Integer = 0
        ' Takes a string and splits it into words (the "_" character is used as a separator)
        For i = 0 To fileLine.Length - 1
            If Not fileLine.Substring(i, 1).Equals("_") Then
                ' The buffer gathers letters to create a word
                buffer = buffer + fileLine.Substring(i, 1)
            Else
                ' The buffer has a full word in it
                personAttribute(j) = buffer
                ' The next attribute can get a value
                j = j + 1
                buffer = ""
            End If
        Next
        ' The buffer holds the last attribute of the Person
        personAttribute(j) = buffer
        ' It transforms a string to an instance of the Date class
        Dim dateOfHiring As Date
        dateOfHiring = Person.stringToDate(personAttribute(7))
        ' Uses the duty string to figure out which are the duties of the employee
        Dim duties As Integer
        duties = Person.stringToDuty(personAttribute(8))
        ' Uses all the data that where gathered above to create a new instance of the person class
        Dim newPerson As New Person(personAttribute(0), personAttribute(1), personAttribute(2), personAttribute(3), personAttribute(4), personAttribute(5), personAttribute(6), dateOfHiring, duties, personAttribute(9))
        'Returns the new person
        Return newPerson
    End Function

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Logistics.initializeDay()
        Dim fileLine As String
        Dim path() As String = {"data/employees.sbm", "data/managers.sbm", "data/owners.sbm"}
        Dim fileExists As Boolean = True
        Dim tempPerson As Person
        ' Checks if the owners file exists and opens it for input
        Try
            FileOpen(1, path(2), OpenMode.Input)
        Catch ex As System.IO.IOException
            ' If the file does not exist then the system is initiallized and so the data of the owner must be registered first
            Dim owner As New FrmNewEmployee(Me, employees, managers, sbOwners)
            ' Disables the main window for safety reasons
            Me.Enabled = False
            ' Changes the title of the frame
            owner.Text = "ÅéóáãùãÞ ôùí óôïé÷åßùí ôïõ éäéïêôÞôç"
            ' Removes all duties except from owner
            Dim i As Integer
            For i = owner.cmbDuty.Items.Count - 1 To 1 Step -1
                owner.cmbDuty.Items.RemoveAt(i)
            Next
            ' Disables the Cancel button - the system must have the data of at least one owner
            owner.cmdCancel.Enabled = False
            ' Shows the window which collects info for the owner
            owner.Show()
            Exit Sub
        End Try
        ' Reads a line from the file; creates a new Person instance and adds it to the array of the owners
        Do While Not EOF(1)
            fileLine = LineInput(1)
            tempPerson = createPerson(fileLine)
            sbOwners.Add(tempPerson)
        Loop
        ' Closes the file
        FileClose(1)
        ' Checks if the managers file exists and opens it for input
        Try
            FileOpen(1, path(1), OpenMode.Input)
        Catch ex As System.IO.IOException
            ' If the file does not exist then the system is initiallized and so the data of a manager must be registered
            Dim manager As New FrmNewEmployee(Me, employees, managers, sbOwners)
            ' Disables the main window for safety reasons
            Me.Enabled = False
            ' Changes the title of the frame
            manager.Text = "ÅéóáãùãÞ ôùí óôïé÷åßùí ôïõ õðåõèýíïõ"
            ' Removes all duties except from owner and manager duties
            ' If there is no manager the system will always prompt this window
            Dim i As Integer
            For i = manager.cmbDuty.Items.Count - 1 To 2 Step -1
                manager.cmbDuty.Items.RemoveAt(i)
            Next
            ' Disables the Cancel button - the system must have the data of at least one manager
            manager.cmdCancel.Enabled = False
            ' Shows the window which collects info for the manager
            manager.Show()
            Exit Sub
        End Try
        ' All managers are loaded to the managers array
        Do While Not EOF(1)
            fileLine = LineInput(1)
            tempPerson = createPerson(fileLine)
            managers.Add(tempPerson)
        Loop
        ' Closes the file
        FileClose(1)
        ' Checks if the employees file exists and opens it for input
        Try
            FileOpen(1, path(0), OpenMode.Input)
        Catch ex As System.IO.IOException
            ' If the file does not exist then no employee can be loaded from the file
            fileExists = False
        End Try
        ' The value of the previous variable is checked-False indicates that there the file does not exist
        If fileExists Then
            ' If its true then the employees are loaded
            Do While Not EOF(1)
                fileLine = LineInput(1)
                tempPerson = createPerson(fileLine)
                employees.Add(tempPerson)
            Loop
        End If
        ' Closes the file
        FileClose(1)
        ' Creates a new instance of the class-window frmInsertPassword
        Dim checkAccess As New FrmInsertManager(Me, managers)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window for the password
        checkAccess.Show()
        Logistics.initializeDay()
    End Sub

    Private Sub chkFirstFloor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFirstFloor.Click
        ' The ground floor button gets unchecked
        chkGroundFloor.BackColor = Color.DarkGray
        chkGroundFloor.Checked = True
        chkGroundFloor.CheckState = CheckState.Unchecked
        ' The first floor button is highlighted and gets checked
        chkFirstFloor.BackColor = Color.CadetBlue
        chkFirstFloor.Checked = False
        chkFirstFloor.CheckState = CheckState.Checked
        ' The ground floor panel is send to the back-it becames invisible and is inactive
        pnlGroundFloor.SendToBack()
        pnlFirstFloor.Visible = True
    End Sub

    Private Sub chkGroundFloor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkGroundFloor.Click
        ' The first floor button gets unchecked
        chkFirstFloor.BackColor = Color.DarkGray
        chkFirstFloor.Checked = True
        chkFirstFloor.CheckState = CheckState.Unchecked
        ' The ground floor button is highlighted and gets checked
        chkGroundFloor.BackColor = Color.CadetBlue
        chkGroundFloor.Checked = False
        chkGroundFloor.CheckState = CheckState.Checked
        ' The first floor panel is send to the back-it becames invisible and is inactive
        pnlFirstFloor.SendToBack()
        pnlGroundFloor.Visible = True
    End Sub

    Public Sub terminateSystem()
        changeManagerCashRegister(logedInManager)
        FileHandler.createZReport(dayCashRegister.getMoneyAsString)
        MsgBox("Ôï ãåíéêü ôáìåßï åßíáé: " + dayCashRegister.getMoneyAsString + "€")
        ' Closes the orders window-it is hiden from the user but not closed because it is going to be the most frequently used window
        orders.Close()
        ' Terminates the program
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If lsvCurrentEmployees.Items.Count > 1 Then
            MsgBox("ÕðÜñ÷ïõí áêüìç åíåñãïß õðÜëëçëïé!")
        Else
            Dim checkPass As New FrmAskPassword(Me, logedInManager, False, Me, True)
            ' Disables the main window for safety reasons
            Me.Enabled = False
            ' Shows the window for the password
            checkPass.Show()
        End If
    End Sub

    Private Sub cmdLongIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongIn.Click
        ' Creates a new instance of the class-window frmNewItem
        Dim logIn As New FrmLogIn(Me, employees, sbOwners, cashRegisters)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window which collects info for the new Item
        logIn.Show()
    End Sub

    Private Sub cmdLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogOut.Click
        ' Creates a new instance of the class-window frmNewItem
        Dim logOut As New FrmLogOut(Me, logedInEmployees, logedInOwners, cashRegisters, managersCashRegister)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window which collects info for the new Item
        logOut.Show()
    End Sub

    Private Sub cmdChangeManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeManager.Click
        ' Used when a manager wants to log out off the system; An other manager must take his place
        ' Creates a new instance of the class-window frmChangeManager
        Dim changeManager As New FrmSwapManagers(Me, managers, logedInManager)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window for the password
        changeManager.Show()
    End Sub

    Private Sub cmdLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLock.Click
        ' Locks the screen; only the present manager can unlock it
        ' Creates a new instance of the class-window frmInsertPassword
        Dim checkAccess As New FrmAskPassword(Me, logedInManager, True, Me, False)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window for the password
        checkAccess.Show()
    End Sub

    Private Sub cmdFunctions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFunctions.Click
        ' Disables this panel and sends it to the back-this way it is deactivated
        pnlMainButtons.Enabled = False
        pnlMainButtons.SendToBack()
        ' This panel is enabled for use
        pnlFunctions.Enabled = True
    End Sub

    Private Sub cmdInsertEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertEmployee.Click
        ' Creates a new instance of the class-window frmEmployee
        Dim inputEmployee As New FrmNewEmployee(Me, employees, managers, sbOwners)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window which collects info for the new employee
        inputEmployee.Show()
    End Sub

    Private Sub cmdDeleteEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteEmployee.Click
        ' Creates a new instance of the class-window frmDeleteEmployee
        Dim deleteEmployee As New FrmDeleteEmployee(Me, employees, logedInEmployees, managers, logedInManager)
        ' Disables the main window for safety reasons
        Me.Enabled = False
        ' Shows the window which deletes the employee
        deleteEmployee.Show()
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        ' Disables this panel and sends it to the back-this way it is deactivated
        pnlFunctions.Enabled = False
        pnlFunctions.SendToBack()
        ' This panel is enabled for use
        pnlMainButtons.Enabled = True
    End Sub

    Private Sub cmdTable1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable1.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable1, 0, cashiersCount)
    End Sub

    Private Sub cmdTable2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable2.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable2, 1, cashiersCount)
    End Sub

    Private Sub cmdTable3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable3.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable3, 2, cashiersCount)
    End Sub

    Private Sub cmdTable4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable4.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable4, 3, cashiersCount)
    End Sub

    Private Sub cmdTable5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable5.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable5, 4, cashiersCount)
    End Sub

    Private Sub cmdTable6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable6.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable6, 5, cashiersCount)
    End Sub

    Private Sub cmdTable7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable7.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable7, 6, cashiersCount)
    End Sub

    Private Sub cmdTable8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable8.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable8, 7, cashiersCount)
    End Sub

    Private Sub cmdTable9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable9.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable9, 8, cashiersCount)
    End Sub

    Private Sub cmdTable10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable10.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable10, 9, cashiersCount)
    End Sub

    Private Sub cmdTable11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable11.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable11, 10, cashiersCount)
    End Sub

    Private Sub cmdTable12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable12.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable12, 11, cashiersCount)
    End Sub

    Private Sub cmdTable13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable13.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable13, 12, cashiersCount)
    End Sub

    Private Sub cmdTable14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable14.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable14, 13, cashiersCount)
    End Sub

    Private Sub cmdTable15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable15.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable15, 14, cashiersCount)
    End Sub

    Private Sub cmdTable16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable16.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable16, 15, cashiersCount)
    End Sub

    Private Sub cmdTable17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable17.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable17, 16, cashiersCount)
    End Sub

    Private Sub cmdTable18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable18.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable18, 17, cashiersCount)
    End Sub

    Private Sub cmdTable19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable19.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable19, 18, cashiersCount)
    End Sub

    Private Sub cmdTable20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable20.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable20, 19, cashiersCount)
    End Sub

    Private Sub cmdTable21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable21.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable21, 20, cashiersCount)
    End Sub

    Private Sub cmdTable22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable22.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable22, 21, cashiersCount)
    End Sub

    Private Sub cmdTable23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable23.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable23, 22, cashiersCount)
    End Sub

    Private Sub cmdTable24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable24.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable24, 23, cashiersCount)
    End Sub

    Private Sub cmdTable25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable25.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable25, 24, cashiersCount)
    End Sub

    Private Sub cmdTable26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable26.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable26, 25, cashiersCount)
    End Sub

    Private Sub cmdTable27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable27.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable27, 26, cashiersCount)
    End Sub

    Private Sub cmdTable28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable28.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable28, 27, cashiersCount)
    End Sub

    Private Sub cmdTable29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable29.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable29, 28, cashiersCount)
    End Sub

    Private Sub cmdTable30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable30.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable30, 29, cashiersCount)
    End Sub

    Private Sub cmdTable31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable31.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable31, 30, cashiersCount)
    End Sub

    Private Sub cmdTable32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable32.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable32, 31, cashiersCount)
    End Sub

    Private Sub cmdTable33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable33.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable33, 32, cashiersCount)
    End Sub

    Private Sub cmdTable34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable34.Click
        ' Shows the order frame for this table
        orders.loadOrderForTable(cmdTable34, 33, cashiersCount)
    End Sub
End Class