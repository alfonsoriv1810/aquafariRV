using UnityEngine;
using System.Collections;

public class ControlCubo : MonoBehaviour {

    private float velocidad = 10.0f;
    private Vector3 moveDirection;

    public Camera camerina;

    private Vector3 cameraPos;

    void serverMove()
    {

        if (Network.isServer)
        {
            moveDirection = new Vector3(velocidad * Input.GetAxis("Horizontal"), 0.0f, velocidad * Input.GetAxis("Vertical"));
            rigidbody.AddRelativeForce(moveDirection);

        }
    }
   

    void FixedUpdate()
    {

        serverMove();
       // cameraPos= this.transform.position;
       // cameraPos.y += 15.0f;
        //camerina.transform.position = cameraPos;
    }

    void Update()
    {
        cameraPos = this.transform.position;
        cameraPos.y += 15.0f;
        camerina.transform.position = cameraPos;
    }


    private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {

        if (stream.isWriting)
        {
            Vector3 pos = transform.position;
            Vector3 campos = camerina.transform.position;
          //  stream.Serialize(ref health);
            stream.Serialize(ref pos);
            stream.Serialize(ref campos);

        }
        else
        {
            Vector3 pos = transform.position;
             Vector3 campos = camerina.transform.position;
           // stream.Serialize(ref health);
            stream.Serialize(ref pos);
            transform.position = pos;
            stream.Serialize(ref campos);
            camerina.transform.position=campos;

        }

    }
}
