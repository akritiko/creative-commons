Public Class FrmInsertManager
    Inherits System.Windows.Forms.Form

    Private keyboard As New FrmKeyboard
    Private mainWin As FrmMain

    Private managers As ArrayList
    Private tempPerson As Person

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _managers)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
        managers = _managers
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
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents cmbManagers As System.Windows.Forms.ComboBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmbManagers = New System.Windows.Forms.ComboBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblFullName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Enabled = False
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(128, 120)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 48)
        Me.cmdOK.TabIndex = 32
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'cmbManagers
        '
        Me.cmbManagers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManagers.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cmbManagers.Location = New System.Drawing.Point(8, 24)
        Me.cmbManagers.Name = "cmbManagers"
        Me.cmbManagers.Size = New System.Drawing.Size(320, 32)
        Me.cmbManagers.TabIndex = 46
        Me.cmbManagers.TabStop = False
        Me.cmbManagers.Tag = ""
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.Enabled = False
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(8, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(320, 29)
        Me.txtPassword.TabIndex = 47
        Me.txtPassword.TabStop = False
        Me.txtPassword.Text = ""
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(8, 64)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(185, 17)
        Me.lblPassword.TabIndex = 67
        Me.lblPassword.Text = " Ÿƒ… œ” Õ≈œ’ ’–≈’»’Õœ’"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblFullName.ForeColor = System.Drawing.Color.Black
        Me.lblFullName.Location = New System.Drawing.Point(8, 8)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(210, 17)
        Me.lblFullName.TabIndex = 68
        Me.lblFullName.Text = "œÕœÃ¡‘≈–ŸÕ’Ãœ ’–≈’»’Õœ’"
        '
        'FrmInsertManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(338, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbManagers)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(340, 253)
        Me.Name = "FrmInsertManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "–·Ò·Í·Î˛ ÂÈÛ‹„ÂÙÂ ÙÔÌ ıÂ˝ËıÌÔ"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmInsertPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' The combo box will show only the surnames of the managers
        Dim i As Integer
        For i = 0 To managers.Count - 1
            tempPerson = managers.Item(i)
            cmbManagers.Items.Add(tempPerson.handleSurname() + " " + tempPerson.handleName)
        Next
    End Sub

    Private Sub cmbManagers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbManagers.SelectedIndexChanged
        ' After the manager is selected a password can be given
        txtPassword.Enabled = True

        cmdOK.Enabled = True
        ' The selected manager becomes the active one
        Dim position As Integer
        position = cmbManagers.SelectedIndex
        tempPerson = managers.Item(position)
        ' Enables the keyboad for input
        keyboard.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtPassword)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Checks if the password given is the managers password
        If txtPassword.Text.Equals(tempPerson.handlePassword()) Then
            ''''''''''''''''''''''''''''''''''''
            MsgBox("¡Õœ…√Ã¡ √≈Õ… œ’ ‘¡Ã≈…œ’...")
            ''''''''''''''''''''''''''''''''''''

            Dim position As Integer = cmbManagers.SelectedIndex
            mainWin.setPresentManager(tempPerson, position)
            mainWin.Enabled = True
            keyboard.Close()
            Me.Close()
        Else
            MsgBox("À‹ÌË·ÛÏ›ÌÁ ÂÈÛ·„˘„ﬁ Í˘‰ÈÍÔ˝! ƒÔÍÈÏ‹ÛÙÂ Ó·Ì‹...")
            txtPassword.Text = ""
        End If
    End Sub
End Class