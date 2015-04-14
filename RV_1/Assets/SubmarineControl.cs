using UnityEngine;
using System.Collections;

public class SubmarineControl : MonoBehaviour
{
		public float nivelAgua, alturaFlotacion;
		public Vector3 buoyancyCentreOffset;
		public float bounceDamp;
		private float velocidad = 10.0f;
		private Vector3 moveDirection;

        public AudioSource audio1;
        public AudioSource audio2;
        public AudioSource audio3;

        private float massSubmarino;
        public float engineV;
        public float engineH;

        public float timeholdSpace, timedownSpace;
        private float timeStep = 1.0f;

        private bool readySpace = false;
        private bool readyshift = false;

        public int incrementar = 0;

        void Start()
        {
            massSubmarino = 1.0f;

          

        }

       


        void motorGain()//Funcion que calcula la intensidad del sonido del motor del submarino
        {
            engineV = Input.GetAxis("Vertical") / 2 ;
            engineH = Input.GetAxis("Horizontal") / 2 ;
            if (engineV < 0)
                engineV = - engineV - 0.2f;
         
               
            if (engineH < 0)
                engineH = -engineH ;



        
                audio1.pitch = engineV + 1;
                audio1.volume = engineV + 0.5f;



                audio2.pitch = engineH + 0.8f ;
                    audio2.volume = engineH + 0.5f;

               
                

             }



        

        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, -0.20f, 0.0f);
               
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, 0.20f, 0.0f);
               
            }

            motorGain();
            holdSpace();
            holdShift();
            
            
        }

        void OnCollisionEnter(Collision collision)
        {
           
            //if (collision.relativeVelocity.magnitude > 2)
                audio3.Play();

        }

        IEnumerator countSpace()
        {
            
            while (true)
            {
                yield return new WaitForSeconds(1);
                //incrementar++;
               // Debug.Log("tik tok");

                if (rigidbody.mass <= 10)
                {
                    massSubmarino += 0.1f;
                }

            }
            
        }

        IEnumerator countShift()
        {

            while (true)
            {
                yield return new WaitForSeconds(1.5f);
                //incrementar++;
                // Debug.Log("tik tok");

                if (rigidbody.mass >= 1.0f)
                {
                    massSubmarino -= 0.1f;
                }

            }

        }



       
    
        void holdSpace()
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && readySpace == false)
            {
                readySpace = true;
                StartCoroutine(countSpace());
            }


            if (Input.GetKeyUp(KeyCode.Space))
            {
                readySpace = false;
                StopAllCoroutines();
            }

            
        }

        void holdShift()
        {

            if (Input.GetKeyDown(KeyCode.LeftShift) && readyshift == false)
            {
                readyshift = true;
                StartCoroutine(countShift());
            }


            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                readyshift = false;
                StopAllCoroutines();
            }


        }


		void FixedUpdate ()
		{
				
				//moveDirection = new Vector3 (velocidad * Input.GetAxis ("Horizontal"), 0.0f, velocidad * Input.GetAxis ("Vertical"));
                moveDirection = new Vector3(0.0f, 0.0f,  velocidad * massSubmarino * Input.GetAxis("Vertical"));


				Vector3 actionPoint = transform.position + transform.TransformDirection (buoyancyCentreOffset);
				float forceFactor = 1f - ((actionPoint.y - nivelAgua) / alturaFlotacion);
		
				if (forceFactor > 0f) {
						Vector3 uplift = -Physics.gravity * (forceFactor - rigidbody.velocity.y * bounceDamp);
						rigidbody.AddForceAtPosition (uplift, actionPoint);
                       

				}

				rigidbody.AddRelativeForce (moveDirection);
               // rigidbody.velocity = moveDirection;

                if (Input.GetKeyDown(KeyCode.Space))
                {

                    timeholdSpace = Time.time;
                    //if (rigidbody.mass <= 10)
                    //// rigidbody.mass += 0.1f;
                    //{
                        

                    //    massSubmarino += 0.1f;

                    //}

                    }

                //if (Input.GetKeyDown(KeyCode.LeftControl))
                //{
                    
                  

                //    if (rigidbody.mass >= 1)
                //        //rigidbody.mass -= 0.1f;
                //        massSubmarino -= 0.1f;
                //}

                rigidbody.mass = massSubmarino;

                //if (Input.GetKeyDown(KeyCode.LeftShift))
                //{
                //    rigidbody.drag = 10.0f;
                //}
                //if (Input.GetKeyUp(KeyCode.LeftShift))
                //{
                //    rigidbody.drag = 1.0f;
                //}
		}


       
}
