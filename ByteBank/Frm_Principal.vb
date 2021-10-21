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

    Private Sub Video02ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Video02ToolStripMenuItem.Click

        Dim denominador As Integer = Val(Txt_Denominador.Text)
        Dim resposta As Integer = TestarDivisao(denominador)
        If resposta = -1 Then
            MsgBox("Não é possível fazer a divisão porque o Denominador é igual a zero!")
        ElseIf resposta = -2 Then
            MsgBox("Não é possível fazer a divisão porque o Denominador é maior que o Numerador!")
        Else
            MsgBox("O valor da divisão entre 10 e " + denominador.ToString + " é de: " + resposta.ToString)
        End If

    End Sub

    Function TestarDivisao(Valor As Integer) As Integer
        Dim Resultado As Integer = efetuadivisao(10, Valor)

        If Resultado = -1 Then
            Return -1
        ElseIf Resultado = -2 Then
            Return -2
        End If
        Return Resultado

    End Function

    Function efetuadivisao(Numerador As Integer, Denominador As Integer) As Integer

        If Denominador = 0 Then
            Return -1
        End If

        If Denominador > Numerador Then
            Return -2
        End If

        Return Numerador / Denominador

    End Function

    Private Sub Frm_Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Video03ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Video03ToolStripMenuItem.Click

        Dim denominador As Integer = Val(Txt_Denominador.Text)

        Try
            TestarDivisao2(denominador)
        Catch ex As InvalidCastException
            MsgBox("Existe um erro ao tentar escrever a mensagem da divisão.")
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
        End Try

    End Sub

    Sub TestarDivisao2(Valor As Integer)

        Try
            Dim Resultado As Integer = efetuadivisao2(10, Valor)
            MsgBox("O valor da divisão entre 10 e " + Valor.ToString + " é de: " + Resultado)
        Catch ex As OverflowException
            MsgBox("Não é possível efetuar a divisão por zero.")
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
        End Try

    End Sub

    Function efetuadivisao2(Numerador As Integer, Denominador As Integer) As Integer

        Return Numerador / Denominador

    End Function

End Class
