Public Class FrmLogOut
    Inherits System.Windows.Forms.Form

    Private mainWin As FrmMain

    Private employees As ArrayList
    Private owners As ArrayList
    Private selectedPerson As Person
    Private allPersons As New ArrayList
    Private personPosition As New ArrayList
    Private cashRegisters As ArrayList
    Private managerCash As Cash

    Private isOwner As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef _mainWin, ByRef _employeesList, ByRef _ownersList, ByRef _cash, ByRef manCash)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = _mainWin
        employees = _employeesList
        owners = _ownersList
        cashRegisters = _cash
        managerCash = manCash
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
    Friend WithEvents lsvPersons As System.Windows.Forms.ListView
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents personsSurname As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsName As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsId As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lsvPersons = New System.Windows.Forms.ListView
        Me.personsSurname = New System.Windows.Forms.ColumnHeader
        Me.personsName = New System.Windows.Forms.ColumnHeader
        Me.personsId = New System.Windows.Forms.ColumnHeader
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lsvPersons
        '
        Me.lsvPersons.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.personsSurname, Me.personsName, Me.personsId})
        Me.lsvPersons.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lsvPersons.FullRowSelect = True
        Me.lsvPersons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvPersons.HideSelection = False
        Me.lsvPersons.Location = New System.Drawing.Point(8, 8)
        Me.lsvPersons.MultiSelect = False
        Me.lsvPersons.Name = "lsvPersons"
        Me.lsvPersons.Size = New System.Drawing.Size(400, 400)
        Me.lsvPersons.TabIndex = 63
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
        Me.cmdOK.Location = New System.Drawing.Point(416, 280)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(160, 56)
        Me.cmdOK.TabIndex = 67
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(416, 352)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(160, 56)
        Me.cmdCancel.TabIndex = 64
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'FrmLogOut
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(584, 414)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lsvPersons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(216, 160)
        Me.Name = "FrmLogOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "∏ÓÔ‰ÔÚ ı·ÎÎﬁÎÔı"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub closeFrm()
        ' Reactivates the parent window
        mainWin.Enabled = True
        Me.Close()
    End Sub

    Private Sub writeToListView(ByRef list, ByRef duty)
        ' Writes all the persons of the list in the list view
        Dim tempPerson As Person
        Dim i As Integer
        For i = 0 To list.Count - 1
            tempPerson = list.Item(i)
            allPersons.Add(tempPerson)
            personPosition.Add(i)
            If tempPerson.handleDuty.Equals(duty) Then
                Dim personData As New ListViewItem(tempPerson.handleSurname.ToString)
                personData.SubItems.Add(tempPerson.handleName.ToString)
                personData.SubItems.Add(tempPerson.handleId.ToString)
                lsvPersons.Items.Add(personData)
            End If
        Next
    End Sub

    Private Sub frmLogOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        writeToListView(owners, Person.Duties.…ƒ…œ ‘«‘«”)
        writeToListView(employees, Person.Duties.”≈—¬…‘œ—œ”)
        writeToListView(employees, Person.Duties.¬œ«»œ”)
        writeToListView(employees, Person.Duties.Ã–¡—Ã¡Õ)
        writeToListView(employees, Person.Duties.”≈÷)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Checks if there is a person selected
        If lsvPersons.SelectedItems.Count.Equals(0) Then
            MsgBox("ƒÂÌ ›˜ÂÈ ÂÈÎÂ„Âﬂ Í‹ÔÈÔ ‹ÙÔÏÔ!")
        Else
            Dim i As Integer
            For i = 0 To allPersons.Count - 1
                selectedPerson = allPersons.Item(i)
                ' Checks if the password given is the one of the selected person
                If selectedPerson.handleId.Equals(lsvPersons.FocusedItem.SubItems(2).Text) Then
                    If selectedPerson.handleDuty.Equals(Person.Duties.…ƒ…œ ‘«‘«”) Then
                        isOwner = True
                    Else
                        isOwner = False
                        If selectedPerson.handleDuty.Equals(Person.Duties.”≈—¬…‘œ—œ”) Then
                            mainWin.cashiersCount = mainWin.cashiersCount - 1
                            If cashRegisters.Item(0).getUser Is selectedPerson Then
                                cashRegisters.Item(0).handleMoney = New PrecisionOfTwo(30.0)
                                MsgBox("œ ÛÂÒ‚ÈÙ¸ÒÔÚ ·Ò·‰ﬂ‰ÂÈ: " + cashRegisters.Item(0).getMoneyAsString() + "Ä")
                                mainWin.increaseManagerCashRegister(cashRegisters.Item(0).handleMoney)
                                cashRegisters.Item(0).releaseCash()
                            Else
                                cashRegisters.Item(1).handleMoney = New PrecisionOfTwo(30.0)
                                mainWin.increaseManagerCashRegister(cashRegisters.Item(1).handleMoney)
                                MsgBox("œ ÛÂÒ‚ÈÙ¸ÒÔÚ ·Ò·‰ﬂ‰ÂÈ: " + cashRegisters.Item(1).getMoneyAsString() + "Ä")
                                cashRegisters.Item(1).releaseCash()
                            End If
                        End If
                    End If

                    ' If there is a match, the person is loged out
                    mainWin.exitSystem(selectedPerson, personPosition.Item(i), isOwner)
                    ' ... and the search is finished
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
