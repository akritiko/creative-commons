Public Class frmDeleteItem
    Inherits System.Windows.Forms.Form

    Private mainWin As frmMain
    Private keyboard As New frmKeyboard
    Private items As ArrayList

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef parent, ByRef _itemsList)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mainWin = parent
        items = _itemsList
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.IndianRed
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(928, 384)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 48)
        Me.cmdCancel.TabIndex = 53
        Me.cmdCancel.Text = "ΑΚΥΡΟ"
        '
        'frmDeleteItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Sienna
        Me.ClientSize = New System.Drawing.Size(1018, 438)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmDeleteItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Διαγραφή είδους"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub resetAll()
        ' Resets all textboxes

        'txtSurname.BackColor = Color.Beige
        'txtName.BackColor = Color.Beige
        'txtAddress.BackColor = Color.Beige
        'txtPhone.BackColor = Color.Beige
        'txtAma.BackColor = Color.Beige
        'txtAfm.BackColor = Color.Beige
        'txtID.BackColor = Color.Beige

        ' Reset keyboard
        keyboard.emptyBuffer()
        keyboard.Enabled = False
        keyboard.pnlLetters.Enabled = False
        keyboard.pnlNumbers.Enabled = False
    End Sub

    Private Sub frmDeleteItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resetAll()
        ' Shows the keyboard that is needed for any input
        keyboard.Show()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        mainWin.Enabled = True
        keyboard.Close()
        Me.Close()
    End Sub
End Class
