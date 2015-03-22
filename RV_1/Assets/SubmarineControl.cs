using UnityEngine;
using System.Collections;

public class SubmarineControl : MonoBehaviour
{
		public float nivelAgua, alturaFlotacion;
		public Vector3 buoyancyCentreOffset;
		public float bounceDamp;
		private float velocidad = 10.0f;
		private Vector3 moveDirection;

		void FixedUpdate ()
		{
				
				moveDirection = new Vector3 (velocidad * Input.GetAxis ("Horizontal"), 0.0f, velocidad * Input.GetAxis ("Vertical"));


				Vector3 actionPoint = transform.position + transform.TransformDirection (buoyancyCentreOffset);
				float forceFactor = 1f - ((actionPoint.y - nivelAgua) / alturaFlotacion);
		
				if (forceFactor > 0f) {
						Vector3 uplift = -Physics.gravity * (forceFactor - rigidbody.velocity.y * bounceDamp);
						rigidbody.AddForceAtPosition (uplift, actionPoint);
				}

				rigidbody.AddRelativeForce (moveDirection);

		}
}
