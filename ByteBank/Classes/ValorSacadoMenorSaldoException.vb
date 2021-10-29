Namespace Classes

    Public Class ValorSacadoMenorSaldoException
        Inherits OperacaoFinanceiraException

#Region "PROPRIEDADES"

        Public ReadOnly Property ValorSacado As Double
        Public ReadOnly Property Saldo As Double

#End Region

#Region "CONSTRUTORES"

        Sub New()

        End Sub

        Sub New(message As String)
            MyBase.New(message)

        End Sub

        Sub New(_ValorSacado As Double, _Saldo As Double, message As String)
            Me.New(message)
            ValorSacado = _ValorSacado
            Saldo = _Saldo

        End Sub

        Sub New(Message As String, excecaoInterna As Exception)
            MyBase.New(Message, excecaoInterna)

        End Sub

#End Region

    End Class

End Namespace