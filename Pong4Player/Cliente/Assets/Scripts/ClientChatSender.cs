using UnityEngine;
using TMPro;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ClientChatSender : MonoBehaviour
{
    public TMP_InputField chatInput;
    public int myId;

    UdpClient client;
    IPEndPoint serverEP;

    void Start()
    {
        client = new UdpClient();
        serverEP = new IPEndPoint(IPAddress.Loopback, 5001);
    }

    public void SendMessage()
    {
        if (string.IsNullOrEmpty(chatInput.text)) return;

        string msg = $"CHAT:{myId}:{chatInput.text}";
        byte[] data = Encoding.UTF8.GetBytes(msg);

        client.Send(data, data.Length, serverEP);
        chatInput.text = "";
    }
}
