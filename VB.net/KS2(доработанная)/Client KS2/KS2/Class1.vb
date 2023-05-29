Imports System.Net.Sockets
Public Class Class_Client
    Public Delegate Sub StatusInvoker(ByVal t As String)
    Dim ClientTCP As TcpClient
    Dim Stream As NetworkStream
    Dim Connection As Boolean = False
    Public Event OnRead(ByVal _data As String)
    Public Event Disconnected(ByVal _reson As String)
    Public Event Message(ByVal Text As String)
    Dim s As Object

    Public Function Connect(ByVal server As String, ByVal port As Integer, ascw As String) As Boolean
        If Connection = False Then
            Try
                ClientTCP = New TcpClient(server, port)
                Stream = ClientTCP.GetStream
                Dim CLient_Thread As Threading.Thread = New Threading.Thread(AddressOf DoListen)
                CLient_Thread.Start()
                Connection = True
                Return True
            Catch ex As Exception
                msg(ex.Message)
                Return False
            End Try
        Else
            Return False
        End If
    End Function
    Public Sub Disconnect(Optional ByVal s As String = "")
        If Connection = False Then
            Stream.Close()
            ClientTCP.Close()
            If s = "" Then
                RaiseEvent Disconnected("Отключен")
            Else
                RaiseEvent Disconnected(s)
            End If
        End If
    End Sub
    Public Function Send(ByVal data As String) As Boolean
        If Connection Then
            Try
                Dim DataByte() As Byte = Text.Encoding.UTF8.GetBytes(data)
                Stream.Write(DataByte, 0, DataByte.Length)
                Stream.Flush()
                Return True
            Catch ex As Exception
                msg(ex.Message)
                Disconnect("Проблема при отправке.")
                Return False
            End Try
        Else
            Return False
        End If
    End Function
    Public Sub msg(ByVal t As String)
        Try
            RaiseEvent Message(t)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DoListen()
        Dim bytes(1048576) As Byte
        Dim data As String
        Dim i As Int32
        Try
            i = Stream.Read(bytes, 0, bytes.Length)
            While (i <> 0)
                data = Text.Encoding.UTF8.GetString(bytes, 0, i)
                RaiseEvent OnRead(data)
                i = Stream.Read(bytes, 0, bytes.Length)
            End While
            Disconnect()
        Catch ex As Exception
            Disconnect(ex.Message)
        End Try
    End Sub
End Class

