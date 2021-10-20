Imports ByteBank.Classes

Namespace Classe

    Public Class ContaCorrente

#Region "PROPRIEDADES"

        Public Property titular As Cliente
        Public Property numero As Integer

        Private Shared m_TaxaOperacao As Integer
        Public Shared ReadOnly Property TaxaOperacao As Integer
            Get
                Return m_TaxaOperacao
            End Get
        End Property

        Private Shared m_TotalDeContasCriadas As Integer
        Public Shared ReadOnly Property TotalDeContasCriadas As Integer
            Get
                Return m_TotalDeContasCriadas
            End Get
        End Property

        Private m_agencia As Integer
        Public Property agencia As Integer
            Get
                Return m_agencia
            End Get
            Set(value As Integer)
                If value <= 0 Then
                    m_agencia = 0
                Else
                    m_agencia = value
                End If
            End Set
        End Property

        Private m_saldo As Double = 100
        Public Property saldo As Double
            Get
                Return m_saldo
            End Get
            Set(value As Double)
                If value <= 0 Then
                    m_saldo = 0
                Else
                    m_saldo = value
                End If
            End Set
        End Property

#End Region

#Region "CONSTRUTORES"
        Public Sub New(_Agencia As Integer, _numero As Integer)

            m_agencia = agencia
            numero = numero

            m_TaxaOperacao = 30 / m_TotalDeContasCriadas

            m_TotalDeContasCriadas += 1

        End Sub


#End Region

#Region "MÉTODOS"

        Public Function Sacar(ValorSacado As Double) As Boolean
            Dim vRetorno As Boolean
            If m_saldo < ValorSacado Then
                vRetorno = False
            Else
                vRetorno = True
                m_saldo -= ValorSacado
            End If
            Return ValorSacado

        End Function

        Public Sub Depositar(ValorDepositado As Double)
            m_saldo += ValorDepositado
        End Sub

        Public Function Transferir(ValorTransferencia As Double, ContaDestino As ContaCorrente) As Boolean

            Dim vRetorno As Boolean
            If m_saldo < ValorTransferencia Then
                vRetorno = False
            Else
                m_saldo -= ValorTransferencia
                ContaDestino.Depositar(ValorTransferencia)
                vRetorno = True
            End If
            Return vRetorno

        End Function

#End Region

    End Class

End Namespace