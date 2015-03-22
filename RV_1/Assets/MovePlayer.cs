using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    private Camera camera;

    void OnStart()
    {

        camera = new Camera();
    }

    void Update()
    {
        camera = Camera.main;
        Vector3 poscam = camera.transform.position;
        transform.position = poscam;
    
    }
}
