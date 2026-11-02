using System.Net;
using System.Net.Sockets;
using System.Text;

//using Socket udpSocket =
//    new Socket(
//        AddressFamily.InterNetwork,
//        SocketType.Dgram,
//        ProtocolType.Udp);

//string sendingMessage = "Hello UDP Protocol!";
//byte[] sendingBuffer = Encoding.UTF8.GetBytes(sendingMessage);

//IPEndPoint serverEndPoint = new(IPAddress.Loopback, 5000);
//int sendingSize = await udpSocket.SendToAsync(sendingBuffer, serverEndPoint);

using UdpClient udpClient = new UdpClient();

string message = "Hello From Udp Client!";
byte[] buffer = Encoding.UTF8.GetBytes(message);

IPEndPoint remoteEndPoint = new(IPAddress.Loopback, 5000);
udpClient.Connect(remoteEndPoint);

int sendingData = await udpClient.SendAsync(buffer);
Console.WriteLine($"Sending {sendingData} bytes");
