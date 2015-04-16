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

public class CameraControl : MonoBehaviour
{
	public GameObject mMap;
	public AnimationCurve animRotation;
	public AnimationCurve animSpeed;
	float scrollSpeed;
	float camSpeed;

	void Start ()
	{
	}

	void Update ()
	{
		float distanceToGround = 0;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			distanceToGround = hit.distance;
		}
		
		// Camera speed
		camSpeed = animSpeed.Evaluate (distanceToGround);
		scrollSpeed = camSpeed*10;

		// Camera position
		float forwardSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * camSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * Time.deltaTime * camSpeed;
		float zoomSpeed = Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		transform.position += new Vector3 (forwardSpeed, -zoomSpeed, -sideSpeed);

		// Camera orientation
		float rotx = animRotation.Evaluate (distanceToGround);
		Quaternion newrot = Quaternion.Euler (rotx, 90, 0);
		transform.rotation = Quaternion.Slerp (transform.rotation, newrot, distanceToGround);
	}
}
