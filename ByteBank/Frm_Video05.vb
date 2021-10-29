Imports ByteBank.Classe
Imports ByteBank.Classes

Public Class Frm_Video05
    Dim conta As New ContaCorrente(237, 144422)
    Dim conta2 As New ContaCorrente(237, 144909)
    Dim vStack As String = ""
    Dim vControle As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Formulário do Vídeo 05"
        Lbl_Video05.Text = "Formulário do Vídeo 05"
        Btm_Fechar.Text = "Fechar"
        Grp_Movimentacao.Text = "Movimentação da conta"
        Lbl_Movimentacao.Text = "Digite o valor"
        Btm_Saque.Text = "Sacar"
        Lbl_ContaCorrente.Text = "Conta: " + conta.agencia.ToString + " - " + conta.numero.ToString
        Lbl_Saldo.Text = "Saldo da conta = " + conta.saldo.ToString
        Btm_Transferir.Text = "Transferir"
        Lbl_ContaCorrente2.Text = "Conta: " + conta2.agencia.ToString + " - " + conta2.numero.ToString
        Lbl_Saldo2.Text = "Saldo da conta2 = " + conta2.saldo.ToString
        Btm_Stack.Text = "Ver último StackTrace"
        Txt_Stack.Visible = False
        Lbl_SaquesErrados.Text = "Número de Saques Errados: " + conta.NumeroSaquesErrados.ToString
        Lbl_TransferErrados.Text = "Número de Transferencias Erradas: " + conta.NumeroTransferenciasErradas.ToString

    End Sub

    Private Sub Btm_Fechar_Click(sender As Object, e As EventArgs) Handles Btm_Fechar.Click

        Me.Close()

    End Sub

    Private Sub Lbl_Movimentacao_Click(sender As Object, e As EventArgs) Handles Lbl_Movimentacao.Click

    End Sub

    Private Sub Btm_Saque_Click(sender As Object, e As EventArgs) Handles Btm_Saque.Click

        Try
            vStack = ""
            Dim valorSacar As Double = Val(Txt_Valor.Text)
            conta.Sacar(valorSacar, "sacado")
            Lbl_Saldo.Text = "Saldo da conta = " + conta.saldo.ToString

        Catch ex As ValorSacadoMenorSaldoException
            Lbl_SaquesErrados.Text = "Número de Saques Errados: " + conta.NumeroSaquesErrados.ToString
            vStack = ex.StackTrace
            MsgBox("Ocorreu um erro ValorSacadoMenorSaldoException: " + ex.Message + " Valor Saque de " _
                   + ex.ValorSacado.ToString + ". Saldo de: " + ex.Saldo.ToString)

        Catch ex As ArgumentException
            Lbl_SaquesErrados.Text = "Número de Saques Errados: " + conta.NumeroSaquesErrados.ToString
            vStack = ex.StackTrace
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        Catch ex As Exception
            vStack = ex.StackTrace
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        End Try

    End Sub

    Private Sub Btm_Transferir_Click(sender As Object, e As EventArgs) Handles Btm_Transferir.Click

        Try
            vStack = ""
            Dim valorTransferencia As Double = Val(Txt_Valor.Text)
            conta.Transferir(valorTransferencia, conta2)
            Lbl_Saldo.Text = "Saldo da conta = " + conta.saldo.ToString
            Lbl_Saldo2.Text = "Saldo da conta2 = " + conta2.saldo.ToString

        Catch ex As OperacaoFinanceiraException
            Lbl_TransferErrados.Text = "Número de Transferencias Erradas: " + conta.NumeroTransferenciasErradas.ToString
            vStack = ex.StackTrace
            vStack += ex.InnerException.StackTrace
            MsgBox("Ocorreu um erro OperacaoFinanceiraException: " + ex.Message)

        Catch ex As ValorSacadoMenorSaldoException
            Lbl_TransferErrados.Text = "Número de Transferencias Erradas: " + conta.NumeroTransferenciasErradas.ToString
            vStack = ex.StackTrace
            MsgBox("Ocorreu um erro ValorSacadoMenorSaldoException: " + ex.Message + " Valor da Transferencia de " _
                   + ex.ValorSacado.ToString + ". Saldo de: " + ex.Saldo.ToString)

        Catch ex As ArgumentException
            Lbl_TransferErrados.Text = "Número de Transferencias Erradas: " + conta.NumeroTransferenciasErradas.ToString
            vStack = ex.StackTrace
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        Catch ex As Exception

            vStack = ex.StackTrace + vbCrLf
            vStack += ex.InnerException.StackTrace

            MsgBox("Ocorreu um erro Exception: " + ex.Message + " . Erro original interno: " + ex.InnerException.Message)

        End Try

    End Sub

    Private Sub Btm_Stack_Click(sender As Object, e As EventArgs) Handles Btm_Stack.Click

        If vControle = False Then

            vControle = True
            Txt_Stack.Visible = True

        Else

            vControle = False
            Txt_Stack.Visible = False

        End If
        Txt_Stack.Text = vStack

    End Sub

End Class