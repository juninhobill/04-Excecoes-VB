Public Class Frm_Principal
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Principal"
        Lbl_Principal.Text = "Principal"

    End Sub

    Private Sub Lbl_Principal_Click(sender As Object, e As EventArgs) Handles Lbl_Principal.Click

    End Sub

    Private Sub CopairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopairToolStripMenuItem.Click

        MsgBox("Escolhi a opção copiar!")

    End Sub
End Class
