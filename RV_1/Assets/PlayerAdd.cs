using UnityEngine;
using System.Collections;

public class PlayerAdd : MonoBehaviour {


    public GameObject player = null;
    public Camera camarina;
	private Vector3 posicionObjeto;
    public static int playerID;

    private int connectionCounter = 0;



	// Update is called once per frame
	void Update () {

        //Instantiate(prefab, posicionObjeto, Quaternion.identity);


        //if (NetworkMenu.connected)
        //{

        //    Network.Instantiate(player, posicionObjeto, Quaternion.identity, 0);
        //    player.transform.position = camarina.transform.position;
        //}
	
	}

    public void OnPlayerConnected()
    {

        networkView.RPC("addPlayer", RPCMode.All, new object[] { Network.connections.Length });
    }

    public void OnServerConnected()
    {

        addServer();
    }

    [RPC]
    void addPlayer (int pID)
    {
        Vector3 poscam = camarina.transform.position;
        playerID = pID + 1;
        posicionObjeto = poscam;
        posicionObjeto.y += 15;
        posicionObjeto.z += 10;

        
            Network.Instantiate(player, posicionObjeto, Quaternion.identity, 0);
       
          
         //  player.transform.position = camarina.transform.position;

    }



    void addServer()
    {

        Vector3 poscam = camarina.transform.position;
        playerID = 0;
        posicionObjeto.y += 15;
      


        Network.Instantiate(player, posicionObjeto, Quaternion.identity, 0);
        

        // player.transform.position = camarina.transform.position;

    }


}
