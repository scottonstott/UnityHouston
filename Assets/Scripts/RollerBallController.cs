using UnityEngine;
using System.Collections;

public class RollerBallController : MonoBehaviour {

	//public float movePower { get; set; }
	[SerializeField] private float movePower = 10f;

	public GameObject afterburner;

	private ParticleSystem afterburnerPS;
	private float maxAngularVelocity = 25f;
	private Transform cam;
	private Rigidbody rb;
	private Vector3 move;
	private bool j;


	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = maxAngularVelocity;

		afterburnerPS = afterburner.GetComponent<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		j = Input.GetButton ("Jump");
	
		move = (v * cam.forward + h * cam.right);

		// zeros out the y direction
		move.y = 0f;

		if (move.magnitude > 0f) 
		{
			afterburner.transform.rotation = Quaternion.LookRotation (move * -1.0f);
		}

		if (Input.GetButton ("Fire2") && (move.magnitude != 0f)) 
		{
			afterburnerPS.Play ();
			move *= 5.0f;
		} else 
		{
			afterburnerPS.Stop ();
		}
	}

	void FixedUpdate()
	{
		Move (move, j);
	}

	void Move(Vector3 moveDirection, bool jump)
	{
		rb.AddForce (moveDirection * movePower);
		if (Physics.Raycast (transform.position, Vector3.down, 1f) && jump)
		{
				rb.AddForce(Vector3.up, ForceMode.Impulse);
		}

	}

		

}
