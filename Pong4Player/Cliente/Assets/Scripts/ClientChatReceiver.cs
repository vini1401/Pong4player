using UnityEngine;
using UnityEngine.UI;

public class ClientChatReceiver : MonoBehaviour
{
    public Text chatText;

    public void OnMessageReceived(string msg)
    {
        if (!msg.StartsWith("CHAT|")) return;

        string[] parts = msg.Split('|');
        string playerId = parts[1];
        string message = parts[2];

        chatText.text += $"\nP{playerId}: {message}";
    }
}
