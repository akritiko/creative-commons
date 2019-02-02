'Used to record a new person into the system. 

Public Class FrmNewEmployee
    Inherits System.Windows.Forms.Form

    'Attributes 

    Private mainWin As frmMain
    Public keyboard As New frmKeyboard
    Private password As String = ""

    Private employees As ArrayList
    Private managers As ArrayList
    Private owners As ArrayList

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _employeesList, ByRef _managersList, ByRef _ownersList)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
        employees = _employeesList
        managers = _managersList
        owners = _ownersList
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
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblAma As System.Windows.Forms.Label
    Friend WithEvents lblAfm As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
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
        Me.lblSurname = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblAddress = New System.Windows.Forms.Label
        Me.lblPhone = New System.Windows.Forms.Label
        Me.lblAma = New System.Windows.Forms.Label
        Me.lblAfm = New System.Windows.Forms.Label
        Me.lblId = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(352, 232)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(120, 48)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'txtAma
        '
        Me.txtAma.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAma.Location = New System.Drawing.Point(352, 24)
        Me.txtAma.MaxLength = 7
        Me.txtAma.Name = "txtAma"
        Me.txtAma.Size = New System.Drawing.Size(256, 29)
        Me.txtAma.TabIndex = 30
        Me.txtAma.TabStop = False
        Me.txtAma.Text = ""
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(8, 192)
        Me.txtPhone.MaxLength = 10
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(320, 29)
        Me.txtPhone.TabIndex = 29
        Me.txtPhone.TabStop = False
        Me.txtPhone.Text = ""
        Me.txtPhone.WordWrap = False
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(8, 136)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(320, 29)
        Me.txtAddress.TabIndex = 28
        Me.txtAddress.TabStop = False
        Me.txtAddress.Text = ""
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(8, 80)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(320, 29)
        Me.txtName.TabIndex = 26
        Me.txtName.TabStop = False
        Me.txtName.Text = ""
        '
        'txtSurname
        '
        Me.txtSurname.AcceptsReturn = True
        Me.txtSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSurname.Location = New System.Drawing.Point(8, 24)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(320, 29)
        Me.txtSurname.TabIndex = 33
        Me.txtSurname.TabStop = False
        Me.txtSurname.Text = ""
        '
        'dtpHiring
        '
        Me.dtpHiring.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.dtpHiring.CalendarForeColor = System.Drawing.Color.Black
        Me.dtpHiring.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtpHiring.CustomFormat = "dd/MM/yyyy"
        Me.dtpHiring.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.dtpHiring.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHiring.Location = New System.Drawing.Point(352, 192)
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
        Me.lblDuties.Location = New System.Drawing.Point(8, 232)
        Me.lblDuties.Name = "lblDuties"
        Me.lblDuties.Size = New System.Drawing.Size(84, 17)
        Me.lblDuties.TabIndex = 44
        Me.lblDuties.Text = " ¡»« œÕ‘¡"
        '
        'cmbDuty
        '
        Me.cmbDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDuty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cmbDuty.Items.AddRange(New Object() {"…ƒ…œ ‘«‘«”", "’–≈’»’Õœ”", "”≈—¬…‘œ—œ”", "”≈÷", "Ã–¡—Ã¡Õ", "¬œ«»œ”"})
        Me.cmbDuty.Location = New System.Drawing.Point(8, 248)
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
        Me.lblHiring.Location = New System.Drawing.Point(352, 176)
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
        Me.cmdCancel.Location = New System.Drawing.Point(488, 232)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(120, 48)
        Me.cmdCancel.TabIndex = 50
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'txtAfm
        '
        Me.txtAfm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAfm.Location = New System.Drawing.Point(352, 80)
        Me.txtAfm.MaxLength = 9
        Me.txtAfm.Name = "txtAfm"
        Me.txtAfm.Size = New System.Drawing.Size(256, 29)
        Me.txtAfm.TabIndex = 51
        Me.txtAfm.TabStop = False
        Me.txtAfm.Text = ""
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtID.Location = New System.Drawing.Point(352, 136)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(256, 29)
        Me.txtID.TabIndex = 52
        Me.txtID.TabStop = False
        Me.txtID.Text = ""
        '
        'lblSurname
        '
        Me.lblSurname.AutoSize = True
        Me.lblSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSurname.ForeColor = System.Drawing.Color.White
        Me.lblSurname.Location = New System.Drawing.Point(8, 8)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(70, 17)
        Me.lblSurname.TabIndex = 53
        Me.lblSurname.Text = "≈–ŸÕ’Ãœ"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(8, 64)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(52, 17)
        Me.lblName.TabIndex = 54
        Me.lblName.Text = "œÕœÃ¡"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.White
        Me.lblAddress.Location = New System.Drawing.Point(8, 120)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(78, 17)
        Me.lblAddress.TabIndex = 55
        Me.lblAddress.Text = "ƒ…≈’»’Õ”«"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPhone.ForeColor = System.Drawing.Color.White
        Me.lblPhone.Location = New System.Drawing.Point(8, 176)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(155, 17)
        Me.lblPhone.TabIndex = 56
        Me.lblPhone.Text = "¡—…»Ãœ” ‘«À≈÷ŸÕœ’  "
        '
        'lblAma
        '
        Me.lblAma.AutoSize = True
        Me.lblAma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAma.ForeColor = System.Drawing.Color.White
        Me.lblAma.Location = New System.Drawing.Point(352, 8)
        Me.lblAma.Name = "lblAma"
        Me.lblAma.Size = New System.Drawing.Size(43, 17)
        Me.lblAma.TabIndex = 57
        Me.lblAma.Text = "¡.Ã.¡."
        '
        'lblAfm
        '
        Me.lblAfm.AutoSize = True
        Me.lblAfm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAfm.ForeColor = System.Drawing.Color.White
        Me.lblAfm.Location = New System.Drawing.Point(352, 64)
        Me.lblAfm.Name = "lblAfm"
        Me.lblAfm.Size = New System.Drawing.Size(45, 17)
        Me.lblAfm.TabIndex = 58
        Me.lblAfm.Text = "¡.÷.Ã."
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.White
        Me.lblId.Location = New System.Drawing.Point(352, 120)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(150, 17)
        Me.lblId.TabIndex = 59
        Me.lblId.Text = "¡—…»Ãœ” ‘¡’‘œ‘«‘¡”"
        '
        'FrmNewEmployee
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(618, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtpHiring)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtAfm)
        Me.Controls.Add(Me.txtAma)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblAfm)
        Me.Controls.Add(Me.lblAma)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmbDuty)
        Me.Controls.Add(Me.lblHiring)
        Me.Controls.Add(Me.lblDuties)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(200, 140)
        Me.Name = "FrmNewEmployee"
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

    Private Sub writeToFile(ByRef newEmployee, ByVal path)
        ' Used to save the employee to the employee (or manager) file
        FileOpen(1, path, OpenMode.Append)
        PrintLine(1, newEmployee.ToString)
        FileClose(1)
    End Sub

    Private Sub resetkeyboard()
        ' Reset keyboard
        keyboard.emptyBuffer()
        keyboard.pnlLetters.Enabled = False
        keyboard.pnlNumbers.Enabled = False
        keyboard.Hide()
    End Sub

    Private Sub closeFrm()
        ' Activates the main window and closes this window
        mainWin.Enabled = True
        keyboard.Close()
        Me.Close()
    End Sub

    Private Sub FrmNewEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        keyboard.Enabled = True
    End Sub

    Private Sub txtSurname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurname.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtSurname)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtName)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddress.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlNumbers.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtAddress)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtPhone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtPhone)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtAma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAma.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtAma)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtAfm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAfm.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtAfm)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub txtID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.Click
        ' Resets the keyboard
        resetkeyboard()
        ' Activates only the necessary panels of the keyboard
        keyboard.pnlNumbers.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.setTxt(txtID)
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub dtpHiring_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHiring.Click
        ' Resets the keyboard
        resetkeyboard()
    End Sub

    Private Sub cmbDuty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDuty.Click
        ' Resets the keyboard
        resetkeyboard()
    End Sub

    Private Sub cmbDuty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDuty.SelectedIndexChanged
        ' If the employee is Shef, Barman or other no password is needed
        If cmbDuty.SelectedIndex.Equals(0) Or cmbDuty.SelectedIndex.Equals(1) Or cmbDuty.SelectedIndex.Equals(2) Then
            ' Resets the keyboard
            resetkeyboard()
            ' Creates a new instance of the class-window frmPassword
            Dim inputPassword As New FrmVerifyPassword(Me, password)
            ' Shows the window which gets the password
            inputPassword.Show()
            ' Disables the parent window for safety reasons
            Me.WindowState = FormWindowState.Minimized
        Else
            password = " "
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' These are the paths of the three files
        Dim path() As String = {"data/employees.sbm", "data/managers.sbm", "data/owners.sbm"}
        ' Checks if all the necessary data have been gathered
        If txtSurname.Modified And txtName.Modified And txtAddress.Modified And txtPhone.Modified And txtAma.Modified And txtAfm.Modified And txtID.Modified And Not cmbDuty.SelectedIndex.Equals(-1) And Not password.Equals("") Then
            ' All data needed are filled in and the new employee can be registered
            Dim newPerson As New Person(txtSurname.Text, txtName.Text, txtAddress.Text, txtPhone.Text, txtID.Text, txtAfm.Text, txtAma.Text, dtpHiring.Text, cmbDuty.SelectedIndex, password)
            ' Checks if the Person is a manager or an owner
            If cmbDuty.SelectedIndex.Equals(0) Then
                owners.Add(newPerson)
                mainWin.setPresent(newPerson, 0, True)
                ' The person is registered to the employee file
                writeToFile(newPerson, path(2))
            ElseIf cmbDuty.SelectedIndex.Equals(1) Then
                ' The new person is added to the manager list
                managers.Add(newPerson)
                ' The person is registered to the employee file
                writeToFile(newPerson, path(1))
            Else
                ' The new employee is added to the employee list
                employees.Add(newPerson)
                ' The employee is registered to the employee file
                writeToFile(newPerson, path(0))
            End If
            ' Closes this frame
            closeFrm()
        Else
            ' Data is missing
            MsgBox("‘· ÛÙÔÈ˜Âﬂ· Ôı ÂÈÛ·„‹„·ÙÂ ‰ÂÌ ÂﬂÌ·È ÎﬁÒÁ!")
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' Closes this frame without saving any data
        closeFrm()
    End Sub
End Class