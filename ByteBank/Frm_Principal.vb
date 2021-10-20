Imports ByteBank.Classe

Public Class Frm_Principal
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Projeto ByteBank"
        Lbl_Principal.Text = "Projeto ByteBank"

    End Sub

    Private Sub Video01ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Video01ToolStripMenuItem.Click

        Dim conta As New ContaCorrente(252, 11733)
        MsgBox("O número de contas correntes criadas são de: " + ContaCorrente.TotalDeContasCriadas.ToString)
        MsgBox("O valor da taxa de operações está em: " + ContaCorrente.TaxaOperacao.ToString)

    End Sub
End Class
