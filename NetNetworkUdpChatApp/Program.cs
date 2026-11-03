using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress localAddress = IPAddress.Loopback;
IPAddress remoteAddress = IPAddress.Loopback;

Console.Write("Input name: ");
string? name = Console.ReadLine();

Console.Write("Input receive port: ");
if (!Int32.TryParse(Console.ReadLine(), out int localPort)) return;

Console.Write("Input sended port: ");
if (!Int32.TryParse(Console.ReadLine(), out int remotePort)) return;

Console.WriteLine();

Task.Run(ReceiveMessageAsync);

await SendMessageAsync();


async Task ReceiveMessageAsync()
{
    using UdpClient receiver = new UdpClient(localPort);

    while(true)
    {
        var receiveData = await receiver.ReceiveAsync();
        var message = Encoding.UTF8.GetString(receiveData.Buffer);

        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = color;
    }
}

async Task SendMessageAsync()
{
    using UdpClient sender = new UdpClient();
    Console.WriteLine("For sending meagges: input text message and Enter!");

    while(true)
    {
        var message = Console.ReadLine();
        if(String.IsNullOrEmpty(message)) continue;

        if (message == "exit") break;

        message = $"{name}: {message}";
        byte[] buffer = Encoding.UTF8.GetBytes(message);

        await sender.SendAsync(buffer, new IPEndPoint(remoteAddress, remotePort));
    }
}