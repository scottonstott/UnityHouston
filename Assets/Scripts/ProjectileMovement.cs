using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public float force = 50f;
	bool hasAlreadyLaunched = false;

	void FixedUpdate ()
	{
		if (!hasAlreadyLaunched) 
		{
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.AddForce (transform.forward * force, ForceMode.Impulse);
			hasAlreadyLaunched = true;
		}

	}

}
