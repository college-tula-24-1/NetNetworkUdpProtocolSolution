using System.Net;
using System.Net.Sockets;
using System.Text;

//using Socket udpSocket = 
//    new Socket(
//        AddressFamily.InterNetwork, 
//        SocketType.Dgram,
//        ProtocolType.Udp);

////IPAddress.Parse("127.0.0.1");
//IPEndPoint endPoint = new(IPAddress.Loopback, 5000);

//udpSocket.Bind(endPoint);
//Console.WriteLine("UDP Listener started...");

//IPEndPoint remoteEndPoint = new(IPAddress.Any, 0);

//byte[] buffer = new byte[1024];

//var receiveSize = await udpSocket.ReceiveFromAsync(buffer, remoteEndPoint);
//string message = Encoding.UTF8.GetString(buffer, 0, receiveSize.ReceivedBytes);

//Console.WriteLine($"Message from remote: {message}");

UdpClient udpClient = new UdpClient(5000);
Console.WriteLine("UDP Server started");

var receiveData = await udpClient.ReceiveAsync();
string message = Encoding.UTF8.GetString(receiveData.Buffer);

Console.WriteLine($"Message frome remote: {message}");