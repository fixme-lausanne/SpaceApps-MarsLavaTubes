using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	public GameObject mTarget;
	public GameObject mRoverInit;
	public float camSpeed = 20;
	public float scrollSpeed = 500;
	public GameObject lastObject;

	// Use this for initialization
	void Start () {
	}
	
	// Upd ate is called once per frame
	void Update () {

		float forwardSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * camSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * Time.deltaTime * camSpeed;
		float zoomSpeed = Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		transform.position += new Vector3 (sideSpeed, forwardSpeed, -zoomSpeed);

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo = new RaycastHit();
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

			// first use
			if (lastObject == null)
			{
				print("lastObject est null");
				lastObject = hitInfo.collider.transform.root.gameObject;
			}

			print ("OnSelection "+ lastObject.name );
			print ("OnDeSelection "+ hitInfo.collider.transform.root.gameObject.name );
			hitInfo.collider.transform.root.SendMessage("OnSelection", lastObject );
			lastObject.SendMessage("OnDeSelection", hitInfo.collider.transform.root.gameObject);
			lastObject = hitInfo.collider.transform.root.gameObject;
		} 

		if (Input.GetKeyDown(KeyCode.R)) 
		{
			if (lastObject != null)
			{
			print ("New Rover to "+lastObject.name);
			GameObject roverExplo = Instantiate (mRoverInit);
			roverInit rover = roverExplo.GetComponent<roverInit>() ;
			rover.target = lastObject;
			}
		}
	}

}
