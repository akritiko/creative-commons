'This form asks for the password of a person that is going to be hired and the system needs to determine it for him.
Public Class FrmVerifyPassword
    Inherits System.Windows.Forms.Form

    'Attributes

    'Declares a pointer to the parent form.
    Private inputEmployee As FrmNewEmployee
    Private password As String

    'Code generated automatically. It designs the form. It also contains the constructor of the form.
#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef pass)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        inputEmployee = parent
        password = pass
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
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtVerPass As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblVerPass As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblVerPass = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtVerPass = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtPass
        '
        Me.txtPass.AcceptsReturn = True
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPass.Location = New System.Drawing.Point(8, 24)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(320, 29)
        Me.txtPass.TabIndex = 37
        Me.txtPass.TabStop = False
        Me.txtPass.Text = ""
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(344, 24)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(96, 40)
        Me.cmdOK.TabIndex = 41
        Me.cmdOK.Text = "OK"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPass.ForeColor = System.Drawing.Color.White
        Me.lblPass.Location = New System.Drawing.Point(8, 8)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(128, 17)
        Me.lblPass.TabIndex = 47
        Me.lblPass.Text = "ΕΙΣΑΓΩΓΗ ΚΩΔΙΚΟΥ"
        '
        'lblVerPass
        '
        Me.lblVerPass.AutoSize = True
        Me.lblVerPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblVerPass.ForeColor = System.Drawing.Color.White
        Me.lblVerPass.Location = New System.Drawing.Point(8, 64)
        Me.lblVerPass.Name = "lblVerPass"
        Me.lblVerPass.Size = New System.Drawing.Size(151, 17)
        Me.lblVerPass.TabIndex = 48
        Me.lblVerPass.Text = "ΕΠΙΒΕΒΑΙΩΣΗ ΚΩΔΙΚΟΥ"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(344, 72)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 40)
        Me.cmdCancel.TabIndex = 49
        Me.cmdCancel.Text = "ΑΚΥΡΟ"
        '
        'txtVerPass
        '
        Me.txtVerPass.AcceptsReturn = True
        Me.txtVerPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtVerPass.Location = New System.Drawing.Point(8, 80)
        Me.txtVerPass.Name = "txtVerPass"
        Me.txtVerPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtVerPass.Size = New System.Drawing.Size(320, 29)
        Me.txtVerPass.TabIndex = 50
        Me.txtVerPass.TabStop = False
        Me.txtVerPass.Text = ""
        '
        'FrmVerifyPassword
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(450, 128)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtVerPass)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.lblVerPass)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(270, 240)
        Me.Name = "FrmVerifyPassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Εισαγωγή προσωπικού κωδικού"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Methods

    Private Sub closeFrm()
        inputEmployee.keyboard.Hide()
        inputEmployee.keyboard.emptyBuffer()
        'Closes the window
        Me.Close()
        'Reactivates the parent form
        inputEmployee.WindowState = FormWindowState.Normal
    End Sub

    'The methods bellow handle events of the controls that the form contains.

    Private Sub FrmVerifyPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inputEmployee.keyboard.Show()
    End Sub

    Private Sub txtPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.Click
        'Activates only the necessary panels of the keyboard
        inputEmployee.keyboard.Enabled = True
        inputEmployee.keyboard.pnlNumbers.Enabled = True
        inputEmployee.keyboard.pnlLetters.Enabled = True
        'The input of the keyboard is directed to this textbox
        inputEmployee.keyboard.setTxt(txtPass)
    End Sub

    Private Sub txtVerPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVerPass.Click
        'Activates only the necessary panels of the keyboard
        inputEmployee.keyboard.Enabled = True
        inputEmployee.keyboard.pnlNumbers.Enabled = True
        inputEmployee.keyboard.pnlLetters.Enabled = True
        'The input of the keyboard is directed to this textbox
        inputEmployee.keyboard.setTxt(txtVerPass)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Checks if the given password has 4 digits and if it has
        If txtPass.TextLength >= 4 Then
            'Checks if the given passwords are the same
            If txtPass.Text.Equals(txtVerPass.Text) Then
                inputEmployee.setPassword(txtPass.Text)
                closeFrm()
            Else
                'If the given passwords are different, the appropriate message is printed.
                MsgBox("Οι κωδικοί που εισάγατε είναι διαφορετικοί! Δοκιμάστε ξανά...")
                '... and the textboxes are cleared.
                txtPass.Text = ""
                txtVerPass.Text = ""
            End If
        Else
            'if the password has less than 4 digits the appropriate message is printed.
            MsgBox("Ο κωδικός πρέπει να αποτελείται από 4 ψηφία")
            '... and the textboxes are cleared.
            txtPass.Text = ""
            txtVerPass.Text = ""
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'The form closes without returning a password to the parent form.
        inputEmployee.setPassword("")
        inputEmployee.setNoDuty()
        closeFrm()
    End Sub
End Class