/*
Copyright 2015 FIXME Hackerspace

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
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
