Public Class FrmLogIn
    Inherits System.Windows.Forms.Form

    Private mainWin As FrmMain

    Private newPerson As Person
    Private allPersons As New ArrayList
    Private employees As ArrayList
    Private owners As ArrayList
    Private isOwner As Boolean
    Private position As Integer
    Private cashRegisters As ArrayList
   
#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _employeesList, ByRef _ownersList, ByRef _cashRegs)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
        employees = _employeesList
        owners = _ownersList
        cashRegisters = _cashRegs

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
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblDuties As System.Windows.Forms.Label
    Friend WithEvents cmbDuties As System.Windows.Forms.ComboBox
    Friend WithEvents lsvPersons As System.Windows.Forms.ListView
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents personsSurname As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsName As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsId As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmbDuties = New System.Windows.Forms.ComboBox
        Me.lblDuties = New System.Windows.Forms.Label
        Me.lsvPersons = New System.Windows.Forms.ListView
        Me.personsSurname = New System.Windows.Forms.ColumnHeader
        Me.personsName = New System.Windows.Forms.ColumnHeader
        Me.personsId = New System.Windows.Forms.ColumnHeader
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(16, 336)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(160, 56)
        Me.cmdCancel.TabIndex = 54
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'cmbDuties
        '
        Me.cmbDuties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDuties.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cmbDuties.Items.AddRange(New Object() {"…ƒ…œ ‘«‘«”", "”≈—¬…‘œ—œ”", "”≈÷", "Ã–¡—Ã¡Õ", "¬œ«»œ”"})
        Me.cmbDuties.Location = New System.Drawing.Point(8, 24)
        Me.cmbDuties.Name = "cmbDuties"
        Me.cmbDuties.Size = New System.Drawing.Size(152, 32)
        Me.cmbDuties.TabIndex = 55
        Me.cmbDuties.TabStop = False
        Me.cmbDuties.Tag = ""
        '
        'lblDuties
        '
        Me.lblDuties.AutoSize = True
        Me.lblDuties.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDuties.ForeColor = System.Drawing.Color.Black
        Me.lblDuties.Location = New System.Drawing.Point(8, 8)
        Me.lblDuties.Name = "lblDuties"
        Me.lblDuties.Size = New System.Drawing.Size(84, 17)
        Me.lblDuties.TabIndex = 56
        Me.lblDuties.Text = " ¡»« œÕ‘¡"
        '
        'lsvPersons
        '
        Me.lsvPersons.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.personsSurname, Me.personsName, Me.personsId})
        Me.lsvPersons.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lsvPersons.FullRowSelect = True
        Me.lsvPersons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvPersons.HideSelection = False
        Me.lsvPersons.Location = New System.Drawing.Point(192, 24)
        Me.lsvPersons.MultiSelect = False
        Me.lsvPersons.Name = "lsvPersons"
        Me.lsvPersons.Size = New System.Drawing.Size(400, 368)
        Me.lsvPersons.TabIndex = 57
        Me.lsvPersons.View = System.Windows.Forms.View.Details
        '
        'personsSurname
        '
        Me.personsSurname.Text = "≈–ŸÕ’Ãœ"
        Me.personsSurname.Width = 215
        '
        'personsName
        '
        Me.personsName.Text = "œÕœÃ¡"
        Me.personsName.Width = 163
        '
        'personsId
        '
        Me.personsId.Text = "¡—…»Ãœ” ‘¡’‘œ‘«‘¡”"
        Me.personsId.Width = 0
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(16, 264)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(160, 56)
        Me.cmdOK.TabIndex = 58
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'FrmLogIn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbDuties)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lsvPersons)
        Me.Controls.Add(Me.lblDuties)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(208, 164)
        Me.Name = "FrmLogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "≈ﬂÛÔ‰ÔÚ ı·ÎÎﬁÎÔı"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function checkCash(ByVal user As Person)
        Dim isAvailable As Boolean = True

        If cashRegisters.Item(0).isAvailable Then
            cashRegisters.Item(0).setNewUser(user)

        ElseIf cashRegisters.Item(1).isAvailable Then
            cashRegisters.Item(1).setNewUser(user)

        Else
            MsgBox("ƒÂÌ ı‹Ò˜ÂÈ ‰È·Ë›ÛÈÏÔ ÍÂÌ¸ Ù·ÏÂﬂÔ! »· Ò›ÂÈ Ì· ÍÎÂﬂÛÂÈ Í‹ÔÈÔ Ù·ÏÂﬂÔ...")
            isAvailable = False
        End If
        Return isAvailable
    End Function

    Private Sub checkPassword(ByRef newPerson As Person)
        Dim checkAccess As New FrmAskPassword(Me, newPerson, False, mainWin, False)
        ' Disables this window for safety reasons
        Me.Enabled = False
        ' Shows the window for the password
        checkAccess.Show()
    End Sub

    Private Sub closeFrm()
        ' Reactivates the parent window
        mainWin.Enabled = True
        Me.Close()
    End Sub

    Public Sub logInTheSystem()
        ' The person is added to the list view of the present employees
        mainWin.setPresent(newPerson, position, isOwner)
        ' The frame is closed
        closeFrm()
    End Sub

    Private Sub writeToListView(ByRef list, ByRef duty)
        ' Writes all the persons of the list in the list view
        Dim tempPerson As Person
        allPersons.Clear()
        lsvPersons.Items.Clear()
        Dim i As Integer
        For i = 0 To list.Count - 1
            tempPerson = list.Item(i)
            allPersons.Add(tempPerson)
            If tempPerson.handleDuty.Equals(duty) Then
                Dim personData As New ListViewItem(tempPerson.handleSurname.ToString)
                personData.SubItems.Add(tempPerson.handleName.ToString)
                personData.SubItems.Add(tempPerson.handleId.ToString)
                lsvPersons.Items.Add(personData)
            End If
        Next
    End Sub

    Private Sub cmbDuties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDuties.SelectedIndexChanged
        Select Case cmbDuties.SelectedIndex
            Case 0
                writeToListView(owners, Person.Duties.…ƒ…œ ‘«‘«”)
                isOwner = True
            Case 1
                writeToListView(employees, Person.Duties.”≈—¬…‘œ—œ”)
                isOwner = False
            Case 2
                writeToListView(employees, Person.Duties.”≈÷)
                isOwner = False
            Case 3
                writeToListView(employees, Person.Duties.Ã–¡—Ã¡Õ)
                isOwner = False
            Case 4
                writeToListView(employees, Person.Duties.¬œ«»œ”)
                isOwner = False
        End Select
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Checks if there is an person selected
        If lsvPersons.SelectedItems.Count.Equals(0) Then
            MsgBox("ƒÂÌ ›˜ÂÈ ÂÈÎÂ„Âﬂ ı‹ÎÎÁÎÔÚ")
        Else
            Dim i As Integer
            For i = 0 To allPersons.Count - 1
                newPerson = allPersons.Item(i)
                If newPerson.handleId.Equals(lsvPersons.FocusedItem.SubItems(2).Text) Then
                    ' Indcates the slot that the person is registered in the allPersons list
                    position = i
                    ' If a password is needed, a new instance of the class-window frmInsertPassword is created
                    If newPerson.handleDuty.Equals(Person.Duties.…ƒ…œ ‘«‘«”) Then
                        checkPassword(newPerson)
                    ElseIf newPerson.handleDuty.Equals(Person.Duties.”≈—¬…‘œ—œ”) Then
                        If checkCash(newPerson) Then
                            checkPassword(newPerson)
                        Else
                            closeFrm()
                        End If
                    Else
                        logInTheSystem()
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' Closes the frame without any changes
        closeFrm()
    End Sub
End Class