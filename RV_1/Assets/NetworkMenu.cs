using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour {
   
    public string connectionIP = "127.0.0.1";
    public int portNumber = 8632;
    public PlayerAdd player = null;
    public static bool connected = false;

    private void OnConnectedToServer()
    {
        connected = true;
        player.OnPlayerConnected();

    //a client just conected
    }

    private void OnServerInitialized()
    {
        connected = true;
        player.OnServerConnected();

    //the server has initializaed
    }

    private void OnDisconnectedFromServer()
    {
        //conection lost or disconnected
        connected = false;
    
    }

    private void OnGUI()
    {



        if (!connected)
        {
            connectionIP = GUILayout.TextField(connectionIP);
            int.TryParse(GUILayout.TextField(portNumber.ToString()), out portNumber);

            if (GUILayout.Button("Connect"))

                Network.Connect(connectionIP, portNumber);

            if (GUILayout.Button("Host"))
                Network.InitializeServer(1, portNumber, false);

        }
        else
        {
            GUILayout.Label("Conections:" + Network.connections.Length.ToString());

        }
            

        

        
    
    } 
}
