using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour
{

		public WaterSimple waterPlane;
		private bool rotateControl ;
		private Color fogColore;
		public float heighWater;
		// Use this for initialization
		void Start ()
		{ //0.73f, 0.142f, 0.255f, 0.0f
				fogColore = new Color (0.2851f, 0.5546f, 1.0f, 0.0f);
				rotateControl = false;

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (transform.position.y <= heighWater && rotateControl == false) {
						waterPlane.transform.Rotate (180.0f, 0, 0);

						RenderSettings.fogDensity = 0.009f;
						RenderSettings.fogColor = fogColore;
						RenderSettings.fog = true;
					
						rotateControl = true;
				}
	
		}
}
