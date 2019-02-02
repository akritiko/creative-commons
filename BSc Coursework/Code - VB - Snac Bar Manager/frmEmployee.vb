Public Class frmEmployee
    Inherits System.Windows.Forms.Form

    Private mainWin As frmMain
    Public keyboard As New frmKeyboard
    Private Employees As ArrayList
    Private password As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _EmployeesList)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
        Employees = _EmployeesList
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
    Friend WithEvents txtAma As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents dtpHiring As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmbDuty As System.Windows.Forms.ComboBox
    Friend WithEvents lblDuties As System.Windows.Forms.Label
    Friend WithEvents lblHiring As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtAfm As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtAma = New System.Windows.Forms.TextBox
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtSurname = New System.Windows.Forms.TextBox
        Me.dtpHiring = New System.Windows.Forms.DateTimePicker
        Me.lblDuties = New System.Windows.Forms.Label
        Me.cmbDuty = New System.Windows.Forms.ComboBox
        Me.lblHiring = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtAfm = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(392, 200)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 48)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'txtAma
        '
        Me.txtAma.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAma.Location = New System.Drawing.Point(352, 8)
        Me.txtAma.MaxLength = 7
        Me.txtAma.Name = "txtAma"
        Me.txtAma.Size = New System.Drawing.Size(256, 29)
        Me.txtAma.TabIndex = 30
        Me.txtAma.TabStop = False
        Me.txtAma.Text = "¡.Ã.¡."
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(8, 152)
        Me.txtPhone.MaxLength = 10
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(320, 29)
        Me.txtPhone.TabIndex = 29
        Me.txtPhone.TabStop = False
        Me.txtPhone.Text = "¡—…»Ãœ” ‘«À."
        Me.txtPhone.WordWrap = False
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(8, 104)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(320, 29)
        Me.txtAddress.TabIndex = 28
        Me.txtAddress.TabStop = False
        Me.txtAddress.Text = "ƒ…≈’»’Õ”«"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(8, 56)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(320, 29)
        Me.txtName.TabIndex = 26
        Me.txtName.TabStop = False
        Me.txtName.Text = "œÕœÃ¡"
        '
        'txtSurname
        '
        Me.txtSurname.AcceptsReturn = True
        Me.txtSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSurname.Location = New System.Drawing.Point(8, 8)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(320, 29)
        Me.txtSurname.TabIndex = 33
        Me.txtSurname.TabStop = False
        Me.txtSurname.Text = "≈–ŸÕ’Ãœ"
        '
        'dtpHiring
        '
        Me.dtpHiring.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.dtpHiring.CalendarForeColor = System.Drawing.Color.Black
        Me.dtpHiring.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtpHiring.CustomFormat = "dd/MM/yyyy"
        Me.dtpHiring.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.dtpHiring.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHiring.Location = New System.Drawing.Point(352, 152)
        Me.dtpHiring.Name = "dtpHiring"
        Me.dtpHiring.Size = New System.Drawing.Size(256, 29)
        Me.dtpHiring.TabIndex = 42
        Me.dtpHiring.TabStop = False
        '
        'lblDuties
        '
        Me.lblDuties.AutoSize = True
        Me.lblDuties.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDuties.ForeColor = System.Drawing.Color.White
        Me.lblDuties.Location = New System.Drawing.Point(8, 184)
        Me.lblDuties.Name = "lblDuties"
        Me.lblDuties.Size = New System.Drawing.Size(84, 17)
        Me.lblDuties.TabIndex = 44
        Me.lblDuties.Text = " ¡»« œÕ‘¡"
        '
        'cmbDuty
        '
        Me.cmbDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDuty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cmbDuty.Items.AddRange(New Object() {"…ƒ…œ ‘«‘«”", "’–≈’»’Õœ”", "”≈—¬…‘œ—œ”", "”≈÷", "Ã–¡—Ã¡Õ", "¡ÀÀœ…"})
        Me.cmbDuty.Location = New System.Drawing.Point(8, 208)
        Me.cmbDuty.Name = "cmbDuty"
        Me.cmbDuty.Size = New System.Drawing.Size(320, 32)
        Me.cmbDuty.TabIndex = 45
        Me.cmbDuty.TabStop = False
        Me.cmbDuty.Tag = ""
        '
        'lblHiring
        '
        Me.lblHiring.AutoSize = True
        Me.lblHiring.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblHiring.ForeColor = System.Drawing.Color.White
        Me.lblHiring.Location = New System.Drawing.Point(352, 136)
        Me.lblHiring.Name = "lblHiring"
        Me.lblHiring.Size = New System.Drawing.Size(176, 17)
        Me.lblHiring.TabIndex = 46
        Me.lblHiring.Text = "«Ã≈—œÃ«Õ…¡ –—œ”À«ÿ«”"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(488, 200)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 48)
        Me.cmdCancel.TabIndex = 50
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'txtAfm
        '
        Me.txtAfm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAfm.Location = New System.Drawing.Point(352, 56)
        Me.txtAfm.MaxLength = 9
        Me.txtAfm.Name = "txtAfm"
        Me.txtAfm.Size = New System.Drawing.Size(256, 29)
        Me.txtAfm.TabIndex = 51
        Me.txtAfm.TabStop = False
        Me.txtAfm.Text = "¡.÷.Ã."
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtID.Location = New System.Drawing.Point(352, 104)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(256, 29)
        Me.txtID.TabIndex = 52
        Me.txtID.TabStop = False
        Me.txtID.Text = "¡—…»Ãœ” ‘¡’‘œ‘«‘¡”"
        '
        'frmEmployee
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(618, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtAfm)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmbDuty)
        Me.Controls.Add(Me.dtpHiring)
        Me.Controls.Add(Me.txtAma)
        Me.Controls.Add(Me.lblHiring)
        Me.Controls.Add(Me.lblDuties)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(200, 110)
        Me.Name = "frmEmployee"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "≈ÈÛ·„˘„ﬁ ÛÙÔÈ˜Âﬂ˘Ì Ì›Ôı ı·ÎÎﬁÎÔı"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub setPassword(ByVal _pass)
        ' Sets the password
        password = _pass
    End Sub

    Public Sub setNoDuty()
        ' Used when we want to reinitiallize the duty field
        cmbDuty.SelectedIndex = -1
    End Sub

    Private Sub writeToFile(ByRef newEmployee)
        ' Used to save the employee to the employee file
        Dim mystream As System.IO.Stream()
        Dim file As New System.IO.StreamWriter("employees.sbm", True)
        file.WriteLine(newEmployee.ToString)
        file.Close()
    End Sub

    Private Sub clearAll()
        ' Resets all textboxes
        txtSurname.BackColor = Color.Beige
        txtName.BackColor = Color.Beige
        txtAddress.BackColor = Color.Beige
        txtPhone.BackColor = Color.Beige
        txtAma.BackColor = Color.Beige
        txtAfm.BackColor = Color.Beige
        txtID.BackColor = Color.Beige
        ' Reset keyboard
        keyboard.emptyBuffer()
        keyboard.Enabled = False
        keyboard.pnlLetters.Enabled = False
        keyboard.pnlNumbers.Enabled = False
    End Sub

    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Resets all textboxes
        clearAll()
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtSurname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurname.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtSurname.BackColor = Color.White

        If txtSurname.Text.Equals("≈–ŸÕ’Ãœ") Then
            txtSurname.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtSurname)
    End Sub

    Private Sub txtName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtName.BackColor = Color.White

        If txtName.Text.Equals("œÕœÃ¡") Then
            txtName.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtName)
    End Sub

    Private Sub txtAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddress.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtAddress.BackColor = Color.White

        If txtAddress.Text.Equals("ƒ…≈’»’Õ”«") Then
            txtAddress.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtAddress)
    End Sub

    Private Sub txtPhone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtPhone.BackColor = Color.White

        If txtPhone.Text.Equals("¡—…»Ãœ” ‘«À.") Then
            txtPhone.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtPhone)
    End Sub

    Private Sub txtAma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAma.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtAma.BackColor = Color.White

        If txtAma.Text.Equals("¡.Ã.¡.") Then
            txtAma.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtAma)
    End Sub

    Private Sub txtAfm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAfm.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtAfm.BackColor = Color.White

        If txtAfm.Text.Equals("¡.÷.Ã.") Then
            txtAfm.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtAfm)
    End Sub

    Private Sub txtID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.Click
        ' Resets all textboxes
        clearAll()
        ' Highlightes the textbox because this is the active one
        txtID.BackColor = Color.White

        If txtID.Text.Equals("¡—…»Ãœ” ‘¡’‘œ‘«‘¡”") Then
            txtID.Text = ""
        End If
        ' Activates only the necessary panels of the keyboard
        keyboard.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtID)
    End Sub

    Private Sub dtpHiring_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHiring.Click
        ' Resets all textboxes
        clearAll()
    End Sub

    Private Sub cmbDuty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDuty.Click
        ' Resets all textboxes
        clearAll()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Checks if all the necessary data have been gathered
        Dim validation As Boolean

        validation = txtSurname.Modified And txtName.Modified And txtAddress.Modified And txtPhone.Modified And txtAma.Modified And txtAfm.Modified And txtID.Modified And Not cmbDuty.SelectedIndex.Equals(-1) And Not password.Equals("")

        If validation Then
            ' All data needed are filled in and the new employee can be registered
            Dim newEmployee As New Person(txtSurname.Text, txtName.Text, txtAddress.Text, txtPhone.Text, txtID.Text, txtAfm.Text, txtAma.Text, dtpHiring.Text, cmbDuty.SelectedIndex, password)
            ' The new employee is added to the employee list
            Employees.Add(newEmployee)
            ' The employee is registered to the employee file
            writeToFile(newEmployee)
            ' Activates the main window and closes this window
            mainWin.Enabled = True
            keyboard.Enabled = False
            keyboard.Hide()
            Me.Close()
        Else
            ' Data is missing
            MsgBox("‘· ÛÙÔÈ˜Âﬂ· Ôı ÂÈÛ·„‹„·ÙÂ ‰ÂÌ ÂﬂÌ·È ÎﬁÒÁ!")
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' Activates the main window and closes this window without saving any data
        mainWin.Enabled = True
        keyboard.Enabled = False
        keyboard.Hide()
        Me.Close()
    End Sub

    Private Sub cmbDuty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDuty.SelectedIndexChanged
        ' If the employee is Shef, Barman or other no password is needed
        If cmbDuty.SelectedIndex.Equals(0) Or cmbDuty.SelectedIndex.Equals(1) Or cmbDuty.SelectedIndex.Equals(2) Then
            ' Resets all textboxes
            clearAll()
            ' Creates a new instance of the class-window frmPassword
            Dim inputPassword As New frmPassword(Me, password)
            ' Shows the window which gets the password
            inputPassword.Show()
            ' Disables the parent window for safety reasons
            Me.WindowState = FormWindowState.Minimized
        Else
            password = " "
        End If
    End Sub
End Class