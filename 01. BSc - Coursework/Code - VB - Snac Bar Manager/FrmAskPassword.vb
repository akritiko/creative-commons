Public Class FrmAskPassword
    Inherits System.Windows.Forms.Form

    Private parentWin
    Private keyboard As New FrmKeyboard
    Private isLocked As Boolean

    Private checkPerson As Person
    Private isInExit As Boolean
    Private updateWin As FrmMain

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _checkPerson, ByRef _isLocked, ByRef _updateWin, ByRef _isInExit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        parentWin = parent
        checkPerson = _checkPerson
        isLocked = _isLocked
        updateWin = _updateWin
        isInExit = _isInExit
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
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtManager As System.Windows.Forms.TextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtManager = New System.Windows.Forms.TextBox
        Me.lblFullName = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(8, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(320, 29)
        Me.txtPassword.TabIndex = 49
        Me.txtPassword.TabStop = False
        Me.txtPassword.Text = ""
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(112, 120)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(104, 48)
        Me.cmdOK.TabIndex = 48
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'txtManager
        '
        Me.txtManager.AcceptsReturn = True
        Me.txtManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtManager.Location = New System.Drawing.Point(8, 24)
        Me.txtManager.Name = "txtManager"
        Me.txtManager.Size = New System.Drawing.Size(320, 29)
        Me.txtManager.TabIndex = 50
        Me.txtManager.TabStop = False
        Me.txtManager.Text = ""
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblFullName.ForeColor = System.Drawing.Color.Black
        Me.lblFullName.Location = New System.Drawing.Point(8, 8)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(129, 17)
        Me.lblFullName.TabIndex = 70
        Me.lblFullName.Text = "œÕœÃ¡‘≈–ŸÕ’Ãœ "
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(8, 64)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(65, 17)
        Me.lblPassword.TabIndex = 69
        Me.lblPassword.Text = " Ÿƒ… œ” "
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(224, 120)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(104, 48)
        Me.cmdCancel.TabIndex = 71
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'FrmAskPassword
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtManager)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(340, 253)
        Me.Name = "FrmAskPassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "≈ÈÛ‹„ÂÙÂ Í˘‰ÈÍ¸ „È· Ì· ÓÂÍÎÂÈ‰˛ÛÂÈ ÙÔ Û˝ÛÙÁÏ·"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub closeFrm()
        ' Closes the window and makes the parent window visible
        parentWin.Enabled = True
        keyboard.Close()
        Me.Close()
    End Sub

    Private Sub frmLocked_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isLocked Then
            cmdCancel.Visible = False
            lblFullName.Text = "œÕœÃ¡‘≈–ŸÕ’Ãœ ’–≈’»’Õœ’"
            lblPassword.Text = " Ÿƒ… œ” Õ≈œ’ ’–≈’»’Õœ’"
        End If
        ' Shows the surname and the name of the manager
        txtManager.Text = checkPerson.handleSurname + " " + checkPerson.handleName
        txtManager.Enabled = False
        ' Enables the keyboad for input
        keyboard.setTxt(txtPassword)
        keyboard.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        ' Shows the keyboard necessary for the input of the password
        keyboard.Show()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Checks if the password given is the one of the manager
        If txtPassword.Text.Equals(checkPerson.handlePassword()) Then
            If isInExit Then
                closeFrm()
                parentWin.terminateSystem()
            Else
                If Not isLocked Then
                    parentWin.logInTheSystem()
                    updateWin.cashiersCount = updateWin.cashiersCount + 1
                End If
            End If
            closeFrm()
        Else
            MsgBox("À‹ÌË·ÛÏ›ÌÁ ÂÈÛ·„˘„ﬁ Í˘‰ÈÍÔ˝! ƒÔÍÈÏ‹ÛÙÂ Ó·Ì‹...")
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' Closes the window without saving the password
        closeFrm()
    End Sub
End Class