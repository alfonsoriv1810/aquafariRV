using UnityEngine;
using System.Collections;

public class VehicleSerialization : MonoBehaviour {




    private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {

        if (stream.isWriting)
        {
            Vector3 pos = transform.position;
           
            stream.Serialize(ref pos);

        }
        else
        {
            Vector3 pos = transform.position;
          
            stream.Serialize(ref pos);
            transform.position = pos;

        }

    }
}
