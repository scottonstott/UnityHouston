using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour {

	public GameObject prefab;
	public CameraAim aimComponent;

	public float fireDelta = 0.5f;
	private float nextFire = 0.5f;
	private float myTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire)
			{
				Ray aimRay = aimComponent.GetAimRay();

				Quaternion aimRotation = Quaternion.LookRotation(aimRay.direction);
		
				Instantiate(prefab, transform.position, aimRotation);

				nextFire = myTime + fireDelta;
				nextFire = nextFire - myTime;
				myTime = 0.0f;


			}


	}
}
