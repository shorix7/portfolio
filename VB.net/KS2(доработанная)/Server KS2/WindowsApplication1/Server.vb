Imports System.Net.Sockets
Public Class Server
    Public Delegate Sub StatusInvoker(ByVal t As String)
    Private Port As Integer = 13000
    Private ServerName As String
    Private ServerListener As TcpListener
    Private ClientList As New Hashtable
    Public Event OnRead(ByVal _client As handleClient, ByVal _data As String)
    Public Event Disconnect(ByVal _client As handleClient, ByVal _reson As String)
    Public Event Connect(ByVal _client As handleClient)
    Public Event Message(ByVal Text As String)
    Private Flag As Byte
    Public Sub New(ByVal _Port As Integer, ByVal _Name As String, ByVal _flag As Byte)
        Port = _Port
        ServerName = _Name
        Flag = _flag
    End Sub
    Private Sub Client_onRead(ByVal client As handleClient, ByVal data As String)
        RaiseEvent OnRead(client, data)
    End Sub
    Public ReadOnly Property User_List() As Hashtable
        Get
            Return ClientList
        End Get
    End Property
    Public Sub start()
        Dim server_Thread As Threading.Thread = New Threading.Thread(AddressOf StartServ)
        server_Thread.Start()
    End Sub
    Private Sub StartServ()
        Dim client As TcpClient
        Dim count As Integer
        Try
            ServerListener = New TcpListener(Port)
            ServerListener.Start()
            msg("=========Сервер " & ServerName & " запущен...==========")
            While True
                count += 1
                client = ServerListener.AcceptTcpClient
                Dim TempClient As New handleClient(client, count)
                TempClient.StartClient(Me)
                ClientList.Add(TempClient.ID, TempClient)
                RaiseEvent Connect(TempClient)
            End While
        Catch ex As Exception
            msg("=========Ошибка Сервера" & ServerName & "Причина: " & ex.Message)
        End Try
    End Sub
    Public Sub msg(ByVal t As String)
        Try
            RaiseEvent Message(t)
        Catch ex As Exception
            MsgBox(ex.Message,, "Ошибка сервера")
        End Try
    End Sub
    Public Sub Stop_Server()
        Dim Item As DictionaryEntry
        Dim List As Hashtable = ClientList
        For Each Item In List
            CType(Item.Value, handleClient).CloseClient()
        Next
        ServerListener.Stop()
    End Sub
    Private Sub Client_Disconnect(ByVal client As handleClient, ByVal reson As String)
        ClientList.Remove(client.ID)
        RaiseEvent Disconnect(client, reson)
    End Sub
    Public Sub SendUser(ByVal client As handleClient, ByVal data As String)
        Dim tcp As TcpClient = client.TCP
        Dim stream As NetworkStream = tcp.GetStream
        Dim mess() As Byte = Text.Encoding.UTF8.GetBytes(data)
        stream.Write(mess, 0, mess.Length)
        stream.Flush()
    End Sub
    Public Sub SendAll(ByVal data As String)
        Dim Item As DictionaryEntry
        Dim List As Hashtable = ClientList
        For Each Item In List
            SendUser(CType(Item.Value, handleClient), data)
        Next
    End Sub









    Public Class handleClient
        Public Event OnRead(ByVal _client As handleClient, ByVal _data As String)
        Public Event Disconnect(ByVal _client As handleClient, ByVal _reson As String)
        Private mgID As Guid = Guid.NewGuid
        Private ClientSocket As TcpClient
        Private Stream As NetworkStream
        Private clNomer As String
        Private myIP As String

        Public Sub New(ByVal inClientSocket As TcpClient, ByVal count As Integer)
            ClientSocket = inClientSocket
            Stream = ClientSocket.GetStream
            clNomer = count
        End Sub
        Public ReadOnly Property IP
            Get
                If myIP = "" Then myIP = ClientSocket.Client.RemoteEndPoint.ToString
                Return myIP
            End Get
        End Property
        Public ReadOnly Property ID() As String
            Get
                Return mgID.ToString
            End Get
        End Property
        Public ReadOnly Property Number() As String
            Get
                Return clNomer.ToString
            End Get
        End Property
        Public ReadOnly Property TCP() As TcpClient
            Get
                Return ClientSocket
            End Get
        End Property
        Public Sub CloseClient()
            Stream.Close()
            ClientSocket.Close()
        End Sub
        Public Sub StartClient(ByVal _serv As Server)
            Dim ClientThread As Threading.Thread = New Threading.Thread(AddressOf DoListen)
            ClientThread.Start()
            AddHandler OnRead, AddressOf _serv.Client_onRead
            AddHandler Disconnect, AddressOf _serv.Client_Disconnect
        End Sub
        Private Sub DoListen()
            Dim bytes(1048576) As Byte
            Dim data As String
            Dim i As Int32
            Try
                i = Stream.Read(bytes, 0, bytes.Length)
                While (i <> 0)
                    data = Text.Encoding.UTF8.GetString(bytes, 0, i)
                    RaiseEvent OnRead(Me, data)
                    i = Stream.Read(bytes, 0, bytes.Length)
                End While
                CloseClient()
                RaiseEvent Disconnect(Me, "Клиент решил отключиться от сервера.")
            Catch ex As Exception
                CloseClient()
                RaiseEvent Disconnect(Me, "Проблема соединения: " & ex.Message)
            End Try
        End Sub
    End Class
End Class
