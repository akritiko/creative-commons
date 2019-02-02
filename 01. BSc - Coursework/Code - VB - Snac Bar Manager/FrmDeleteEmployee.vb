Public Class FrmDeleteEmployee
    Inherits System.Windows.Forms.Form

    Private mainWin As FrmMain

    Private newPerson As Person
    Private allPersons As New ArrayList
    Private employees As ArrayList
    Private presentEmployees As ArrayList
    Private managers As ArrayList
    Private presentManager As Person

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _employeesList, ByRef _presentEmployees, ByRef _managersList, ByRef _presentManager)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
        employees = _employeesList
        presentEmployees = _presentEmployees
        managers = _managersList
        presentManager = _presentManager
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
    Friend WithEvents lsvPersons As System.Windows.Forms.ListView
    Friend WithEvents lblDuties As System.Windows.Forms.Label
    Friend WithEvents cmbDuties As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents personsSurname As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsName As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsId As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lsvPersons = New System.Windows.Forms.ListView
        Me.personsSurname = New System.Windows.Forms.ColumnHeader
        Me.personsName = New System.Windows.Forms.ColumnHeader
        Me.personsId = New System.Windows.Forms.ColumnHeader
        Me.lblDuties = New System.Windows.Forms.Label
        Me.cmbDuties = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(8, 296)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(160, 56)
        Me.cmdOK.TabIndex = 63
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'lsvPersons
        '
        Me.lsvPersons.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.personsSurname, Me.personsName, Me.personsId})
        Me.lsvPersons.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lsvPersons.FullRowSelect = True
        Me.lsvPersons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvPersons.HideSelection = False
        Me.lsvPersons.Location = New System.Drawing.Point(184, 24)
        Me.lsvPersons.MultiSelect = False
        Me.lsvPersons.Name = "lsvPersons"
        Me.lsvPersons.Size = New System.Drawing.Size(400, 400)
        Me.lsvPersons.TabIndex = 62
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
        'lblDuties
        '
        Me.lblDuties.AutoSize = True
        Me.lblDuties.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDuties.ForeColor = System.Drawing.Color.White
        Me.lblDuties.Location = New System.Drawing.Point(8, 8)
        Me.lblDuties.Name = "lblDuties"
        Me.lblDuties.Size = New System.Drawing.Size(84, 17)
        Me.lblDuties.TabIndex = 61
        Me.lblDuties.Text = " ¡»« œÕ‘¡"
        '
        'cmbDuties
        '
        Me.cmbDuties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDuties.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.cmbDuties.Items.AddRange(New Object() {"’–≈’»’Õœ”", "”≈—¬…‘œ—œ”", "”≈÷", "Ã–¡—Ã¡Õ", "¬œ«»œ”"})
        Me.cmbDuties.Location = New System.Drawing.Point(8, 24)
        Me.cmbDuties.Name = "cmbDuties"
        Me.cmbDuties.Size = New System.Drawing.Size(152, 32)
        Me.cmbDuties.TabIndex = 60
        Me.cmbDuties.TabStop = False
        Me.cmbDuties.Tag = ""
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(8, 368)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(160, 56)
        Me.cmdCancel.TabIndex = 59
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'FrmDeleteEmployee
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Sienna
        Me.ClientSize = New System.Drawing.Size(594, 438)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbDuties)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lsvPersons)
        Me.Controls.Add(Me.lblDuties)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(208, 164)
        Me.Name = "FrmDeleteEmployee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ƒÈ·„Ò·ˆﬁ ı·ÎÎﬁÎÔı"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub closeFrm()
        ' Reactivates the parent window and closes this frame
        mainWin.Enabled = True
        Me.Close()
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

    Private Sub rewriteToFile(ByRef list, ByVal path)
        FileOpen(1, path, OpenMode.Output)
        Dim i As Integer
        For i = 0 To list.Count - 1
            PrintLine(1, list(i).ToString)
        Next
        FileClose(1)
    End Sub

    Private Sub cmbDuties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDuties.SelectedIndexChanged
        Dim selectedEmp As Person
        Select Case cmbDuties.SelectedIndex
            Case 0
                writeToListView(managers, Person.Duties.’–≈’»’Õœ”)
            Case 1
                writeToListView(employees, Person.Duties.”≈—¬…‘œ—œ”)
            Case 2
                writeToListView(employees, Person.Duties.”≈÷)
            Case 3
                writeToListView(employees, Person.Duties.Ã–¡—Ã¡Õ)
            Case 4
                writeToListView(employees, Person.Duties.¬œ«»œ”)
        End Select
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Checks if there is an employee selected
        If lsvPersons.SelectedItems.Count.Equals(0) Then
            MsgBox("ƒÂÌ ›˜ÂÈ ÂÈÎÂ„Âﬂ ı‹ÎÎÁÎÔÚ")
        Else
            Dim i As Integer
            For i = 0 To allPersons.Count - 1
                newPerson = allPersons.Item(i)
                If newPerson.handleId.Equals(lsvPersons.FocusedItem.SubItems(2).Text) Then
                    Dim position As Integer = lsvPersons.FocusedItem.Index
                    If newPerson.handleDuty.Equals(Person.Duties.’–≈’»’Õœ”) Then
                        managers.RemoveAt(position)
                        rewriteToFile(managers, "data/managers.sbm")
                        Dim tempList As New ArrayList(1)
                        tempList.Add(presentManager)
                        rewriteToFile(tempList, "data/managers.sbm")
                    Else
                        employees.RemoveAt(position)
                        rewriteToFile(employees, "data/employees.sbm")
                        rewriteToFile(presentEmployees, "data/employees.sbm")
                    End If
                    Exit For
                End If
            Next
            closeFrm()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' Closes the frame without any changes
        closeFrm()
    End Sub
End Class