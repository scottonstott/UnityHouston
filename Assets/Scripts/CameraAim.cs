using UnityEngine;
using System.Collections;

public class CameraAim : MonoBehaviour {

	public GameObject player;
	private Ray aimRay;

	public Ray GetAimRay()
	{
		Camera ourCamera = GetComponent<Camera> ();
		Ray aimRay = ourCamera.ScreenPointToRay (Input.mousePosition);

		//this code shoots the projectile at the player
		//aimRay.direction = player.transform.position - transform.position;
		//aimRay.origin = transform.position;


		//Ray aimRay = ourCamera.ScreenPointToRay (Input.mousePosition);
		//Debug.DrawRay (aimRay.origin, aimRay.direction * 100f, Color.red, 10f);
		return aimRay;

	}



}
