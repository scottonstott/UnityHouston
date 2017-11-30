using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CameraSwitch : MonoBehaviour {

	public GameObject[] objects;
	public Text buttonText;

	private int CurrentActiveObject = 0;

	// Use this for initialization
	void Start () {
		buttonText.text = objects[CurrentActiveObject].name;
	}
		
	public void NextCamera()
	{
		int nextActiveObject = CurrentActiveObject + 1 >= objects.Length ? 0 : CurrentActiveObject + 1;

		for (int i = 0; i < objects.Length; i++) 
		{
			objects [i].SetActive (i == nextActiveObject);
		}

		CurrentActiveObject = nextActiveObject;

		buttonText.text = objects[CurrentActiveObject].name;

	}

}
