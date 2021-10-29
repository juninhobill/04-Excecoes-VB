Imports System.IO

Namespace Classes

    Public Class LeitordeArquivo
        Implements IDisposable

#Region "PROPRIEDADES"

        Public Property status As String
        Public ReadOnly Property nomeArquivo As String
        Public Property conteudoArquivo As String

#End Region

#Region "CONSTRUTORES"

        Public Sub New(_Arquivo As String)
            nomeArquivo = _Arquivo

            'Throw New FileNotFoundException()
            Console.WriteLine("ABRINDO ARQUIVO")
            status = "ABERTO"
            conteudoArquivo = ""

        End Sub

#End Region

#Region "MÉTODOS"

        Public Sub LeituraLinha()

            'Throw New IOException

            Console.WriteLine("LENDO LINHA")
            conteudoArquivo += "Leitura de Linha ... " + vbCrLf
            status = "ABERTO"

        End Sub

        Public Sub FecharArquivo()

            Console.WriteLine("FECHANDO ARQUIVO")
            status = "FECHADO"

        End Sub

        Sub Dispose() Implements IDisposable.Dispose
            FecharArquivo()
        End Sub

#End Region

    End Class

End Namespace

