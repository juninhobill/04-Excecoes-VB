Imports ByteBank.Classe
Imports ByteBank.Classes

Public Class Frm_Video05
    Dim conta As New ContaCorrente(237, 144422)
    Dim conta2 As New ContaCorrente(237, 144909)
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

    End Sub

    Private Sub Btm_Fechar_Click(sender As Object, e As EventArgs) Handles Btm_Fechar.Click

        Me.Close()

    End Sub

    Private Sub Lbl_Movimentacao_Click(sender As Object, e As EventArgs) Handles Lbl_Movimentacao.Click

    End Sub

    Private Sub Btm_Saque_Click(sender As Object, e As EventArgs) Handles Btm_Saque.Click

        Try
            Dim valorSacar As Double = Val(Txt_Valor.Text)
            conta.Sacar(valorSacar, "sacado")
            Lbl_Saldo.Text = "Saldo da conta = " + conta.saldo.ToString

        Catch ex As ValorSacadoMenorSaldoException

            MsgBox("Ocorreu um erro ValorSacadoMenorSaldoException: " + ex.Message + " Valor Saque de " _
                   + ex.ValorSacado.ToString + ". Saldo de: " + ex.Saldo.ToString)

        Catch ex As ArgumentException
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        Catch ex As Exception
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        End Try

    End Sub

    Private Sub Btm_Transferir_Click(sender As Object, e As EventArgs) Handles Btm_Transferir.Click

        Try
            Dim valorTransferencia As Double = Val(Txt_Valor.Text)
            conta.Transferir(valorTransferencia, conta2)
            Lbl_Saldo.Text = "Saldo da conta = " + conta.saldo.ToString
            Lbl_Saldo2.Text = "Saldo da conta2 = " + conta2.saldo.ToString

        Catch ex As ValorSacadoMenorSaldoException

            MsgBox("Ocorreu um erro ValorSacadoMenorSaldoException: " + ex.Message + " Valor da Transferencia de " _
                   + ex.ValorSacado.ToString + ". Saldo de: " + ex.Saldo.ToString)

        Catch ex As ArgumentException
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        Catch ex As Exception
            MsgBox("Ocorreu um erro Exception: " + ex.Message)

        End Try

    End Sub
End Class