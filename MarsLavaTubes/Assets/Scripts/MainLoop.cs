using UnityEngine;
using System.Collections;

public class MainLoop : MonoBehaviour
{
	
	float camSpeed = 10;
	float scrollSpeed = 500;
	public GameObject mCamera;
	public GameObject mRoverInit;
	public GameObject mTarget;

	void Update ()
	{

		// Camera position
		float forwardSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * camSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * Time.deltaTime * camSpeed;
		float zoomSpeed = Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		mCamera.transform.position += new Vector3 (forwardSpeed, -zoomSpeed, -sideSpeed);
	
		if (Input.GetKeyDown (KeyCode.R)) {

			GameObject rover = Instantiate (mRoverInit);
			roverInit roverCmp = rover.GetComponent<roverInit> ();
			roverCmp.target = mTarget;
		}
	}
	
}
