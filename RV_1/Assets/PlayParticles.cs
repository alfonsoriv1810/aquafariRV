using UnityEngine;
using System.Collections;

public class PlayParticles : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        if (networkView.isMine)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                networkView.RPC("DoExploder", RPCMode.All, new object[] { 15 });
            }
            else if (Input.GetKeyDown(KeyCode.Return))
                networkView.RPC("DoExploder", RPCMode.All, new object[] { 1500 });
        }

        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Client is not allowed to particle madness");
            }
            else if (Input.GetKeyDown(KeyCode.Return))
                Debug.Log("Client is not allowed to particle madness");
        }
            
        
	}


    [RPC]
    public void DoExploder(int count)
    {
        particleSystem.Emit(count);
    
    }
}
