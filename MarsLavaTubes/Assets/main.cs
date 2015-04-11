using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	public GameObject mTarget;
	public float camSpeed = 10;
	public float scrollSpeed = 500;

	// Use this for initialization
	void Start () {
	}
	
	// Upd ate is called once per frame
	void Update () {
		print ("tests caméra");
		float forwardSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * camSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * Time.deltaTime * camSpeed;
		float zoomSpeed = Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		transform.position -= new Vector3 (sideSpeed, forwardSpeed, zoomSpeed);
	}


}
