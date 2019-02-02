Public Class FrmSwapManagers
    Inherits System.Windows.Forms.Form

    Private mainWin As FrmMain
    Private keyboard As New FrmKeyboard

    Private managers As ArrayList
    Private presentManager As Person
    Private newPerson As Person

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _managersList, ByRef _presentManager)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
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
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents lsvManagers As System.Windows.Forms.ListView
    Friend WithEvents txtPresentManager As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblPresentManager As System.Windows.Forms.Label
    Friend WithEvents lblManagers As System.Windows.Forms.Label
    Friend WithEvents personsSurname As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsName As System.Windows.Forms.ColumnHeader
    Friend WithEvents personsId As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lsvManagers = New System.Windows.Forms.ListView
        Me.personsSurname = New System.Windows.Forms.ColumnHeader
        Me.personsName = New System.Windows.Forms.ColumnHeader
        Me.personsId = New System.Windows.Forms.ColumnHeader
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtPresentManager = New System.Windows.Forms.TextBox
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblPresentManager = New System.Windows.Forms.Label
        Me.lblManagers = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.White
        Me.cmdOK.Location = New System.Drawing.Point(424, 160)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(144, 56)
        Me.cmdOK.TabIndex = 63
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "OK"
        '
        'lsvManagers
        '
        Me.lsvManagers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.personsSurname, Me.personsName, Me.personsId})
        Me.lsvManagers.Font = New System.Drawing.Font("Courier New", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lsvManagers.FullRowSelect = True
        Me.lsvManagers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvManagers.HideSelection = False
        Me.lsvManagers.Location = New System.Drawing.Point(8, 80)
        Me.lsvManagers.MultiSelect = False
        Me.lsvManagers.Name = "lsvManagers"
        Me.lsvManagers.Size = New System.Drawing.Size(400, 248)
        Me.lsvManagers.TabIndex = 62
        Me.lsvManagers.View = System.Windows.Forms.View.Details
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
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(424, 232)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(144, 56)
        Me.cmdCancel.TabIndex = 59
        Me.cmdCancel.Text = "¡ ’—œ"
        '
        'txtPresentManager
        '
        Me.txtPresentManager.Enabled = False
        Me.txtPresentManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPresentManager.Location = New System.Drawing.Point(8, 24)
        Me.txtPresentManager.MaxLength = 7
        Me.txtPresentManager.Name = "txtPresentManager"
        Me.txtPresentManager.Size = New System.Drawing.Size(400, 29)
        Me.txtPresentManager.TabIndex = 64
        Me.txtPresentManager.TabStop = False
        Me.txtPresentManager.Text = ""
        '
        'txtPass
        '
        Me.txtPass.AcceptsReturn = True
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPass.Location = New System.Drawing.Point(8, 360)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(400, 29)
        Me.txtPass.TabIndex = 65
        Me.txtPass.TabStop = False
        Me.txtPass.Text = ""
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(8, 344)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(301, 17)
        Me.lblPassword.TabIndex = 66
        Me.lblPassword.Text = "≈…”¡√≈‘≈ ‘œÕ  Ÿƒ… œ ‘œ’ Õ≈œ’ ’–≈’»’Õœ’"
        '
        'lblPresentManager
        '
        Me.lblPresentManager.AutoSize = True
        Me.lblPresentManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPresentManager.ForeColor = System.Drawing.Color.Black
        Me.lblPresentManager.Location = New System.Drawing.Point(8, 8)
        Me.lblPresentManager.Name = "lblPresentManager"
        Me.lblPresentManager.Size = New System.Drawing.Size(148, 17)
        Me.lblPresentManager.TabIndex = 67
        Me.lblPresentManager.Text = "≈Õ≈—√œ” ’–≈’»’Õœ”"
        '
        'lblManagers
        '
        Me.lblManagers.AutoSize = True
        Me.lblManagers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblManagers.ForeColor = System.Drawing.Color.Black
        Me.lblManagers.Location = New System.Drawing.Point(8, 64)
        Me.lblManagers.Name = "lblManagers"
        Me.lblManagers.Size = New System.Drawing.Size(80, 17)
        Me.lblManagers.TabIndex = 68
        Me.lblManagers.Text = "’–≈’»’Õœ…"
        '
        'FrmSwapManagers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Sienna
        Me.ClientSize = New System.Drawing.Size(578, 438)
        Me.ControlBox = False
        Me.Controls.Add(Me.lsvManagers)
        Me.Controls.Add(Me.lblManagers)
        Me.Controls.Add(Me.txtPresentManager)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.lblPresentManager)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(220, 0)
        Me.Name = "FrmSwapManagers"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "¡ÎÎ·„ﬁ ıÂıË˝ÌÔı"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub writeToListView(ByRef list, ByRef duty)
        ' Writes all the persons of the list in the list view
        Dim tempPerson As Person
        lsvManagers.Items.Clear()
        Dim i As Integer
        For i = 0 To list.Count - 1
            tempPerson = list.Item(i)
            If tempPerson.handleDuty.Equals(duty) Then
                Dim personData As New ListViewItem(tempPerson.handleSurname.ToString)
                personData.SubItems.Add(tempPerson.handleName.ToString)
                personData.SubItems.Add(tempPerson.handleId.ToString)
                lsvManagers.Items.Add(personData)
            End If
        Next
    End Sub

    Private Sub closeFrm()
        ' Closes the frame and reactivates the parent window
        keyboard.Close()
        mainWin.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmChangeManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPass.Enabled = False
        txtPresentManager.Text = presentManager.handleSurname + " " + presentManager.handleName
        writeToListView(managers, Person.Duties.’–≈’»’Õœ”)
    End Sub

    Private Sub verifyPassword()
        If txtPass.Text.Equals(newPerson.handlePassword) Then
            ' Searches for the manager in the list view of the present employees-managers-owners
            Dim j As Integer
            For j = 0 To mainWin.lsvCurrentEmployees.Items.Count - 1
                If mainWin.lsvCurrentEmployees.Items.Item(j).SubItems(1).Text.Equals("1") Then
                    ' When there is a match the manager is removed
                    mainWin.lsvCurrentEmployees.Items.RemoveAt(j)
                    Exit For
                End If
            Next
            ' The new manager is added to the list view
            managers.Add(presentManager)
            ' ...and becomes the active one
            Dim position As Integer = lsvManagers.FocusedItem.Index
            mainWin.setPresentManager(newPerson, position)
            mainWin.changeManagerCashRegister(newPerson)
            closeFrm()
        Else
            MsgBox("À‹ÌË·ÛÏ›ÌÁ ÂÈÛ·„˘„ﬁ Í˘‰ÈÍÔ˝! ƒÔÍÈÏ‹ÛÙÂ Ó·Ì‹...")
            txtPass.Text = ""
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        ' Checks if there is a manager selected
        If lsvManagers.SelectedItems.Count.Equals(0) Then
            MsgBox("ƒÂÌ ›˜ÂÈ ÂÈÎÂ„Âﬂ ıÂ˝ËıÌÔÚ")
        Else
            Dim i As Integer
            For i = 0 To managers.Count - 1
                newPerson = managers.Item(i)
                ' Checks if the password given is the one of the selected manager
                If newPerson.handleId.Equals(lsvManagers.FocusedItem.SubItems(2).Text) Then
                    verifyPassword()
                    ' If there is a match, the search is finished
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ' Closes this window whithout any changes
        closeFrm()
    End Sub

    Private Sub lsvManagers_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvManagers.Enter
        txtPass.Enabled = True
        keyboard.Enabled = True
        keyboard.pnlLetters.Enabled = True
        keyboard.pnlNumbers.Enabled = True
        keyboard.setTxt(txtPass)
        keyboard.Show()
    End Sub
End Class