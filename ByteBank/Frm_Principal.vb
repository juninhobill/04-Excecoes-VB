Imports ByteBank.Classe

Public Class Frm_Principal
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Projeto ByteBank"
        Lbl_Principal.Text = "Projeto ByteBank"
        Lbl_Denominador.Text = "Digite o Denominador"
        Lbl_Agencia.Text = "Agencia"
        Lbl_Conta.Text = "Conta"

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

    Private Sub Video03ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Video03ToolStripMenuItem.Click

        Dim denominador As Integer = Val(Txt_Denominador.Text)

        Try
            TestarDivisao2(denominador)

        Catch ex As InvalidCastException
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
            MsgBox("Existe um erro de conversão de um Double para um String na divisão.")

        Catch ex As OverflowException
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
            MsgBox("Não é possível efetuar a divisão por zero.")

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace)
            MsgBox("Houve um erro ao executar a divisão.")

        End Try

    End Sub

    Sub TestarDivisao2(Valor As Integer)


        Dim Resultado As Integer = efetuadivisao2(10, Valor)

        MsgBox("Erro de divisão ocorreu mas estou continuando o programa.")

        If Valor = 5 Then
            Dim conta As New ContaCorrente(277, 213123)
            MsgBox(conta.titular.nome)
        End If

        MsgBox("O valor da divisão entre 10 e " + Valor.ToString + " é de: " + Resultado)

    End Sub

    Function efetuadivisao2(Numerador As Integer, Denominador As Integer) As Integer

        Try
            Return Numerador / Denominador

        Catch ex As OverflowException
            MsgBox("Tentamos dividir o número " + Numerador.ToString + " por: " + Denominador.ToString)

            Throw

        End Try


    End Function

    Private Sub Video04ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Video04ToolStripMenuItem.Click

        Try

            Dim vAgencia As Integer = Val(Txt_Agencia.Text)
            Dim vConta As Integer = Val(Txt_Conta.Text)

            Dim conta As New ContaCorrente(vAgencia, vConta)

            MsgBox("O código da agência e conta são: " + conta.agencia.ToString + " - " + conta.numero.ToString)

        Catch ex As ArgumentException

            MsgBox(ex.Message)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try





    End Sub
End Class
