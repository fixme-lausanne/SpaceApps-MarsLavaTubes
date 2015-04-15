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
	public GameObject mBlocker;
	float scrollSpeed;
	float camSpeed;

	void Start ()
	{
		camSpeed = 10;
	}

	void Update ()
	{
		float distanceToMap = 0;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			distanceToMap = hit.distance;
		}

		// Camera position
		float forwardSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * camSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * Time.deltaTime * camSpeed;
		float zoomSpeed = Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		if (distanceToMap <= 1f && zoomSpeed > 0) {
			zoomSpeed = 0;
		}
		if (distanceToMap >= 64f && zoomSpeed < 0) {
			zoomSpeed = 0;
		}
		transform.position += new Vector3 (forwardSpeed, -zoomSpeed, -sideSpeed);

		// Camera rotation
		int rotx;
		if (distanceToMap > 50f) {
			camSpeed = 80;
			scrollSpeed = 4800;
			rotx = 90;
		} else if (distanceToMap > 40f) {
			camSpeed = 70;
			scrollSpeed = 3500;
			rotx = 84;
		} else if (distanceToMap > 30f) {
			camSpeed = 60;
			scrollSpeed = 2400;
			rotx = 75;
		} else if (distanceToMap > 20f) {
			camSpeed = 50;
			scrollSpeed = 1600;
			rotx = 64;
		} else if (distanceToMap > 15f) {
			camSpeed = 40;
			scrollSpeed = 1200;
			rotx = 60;
		} else if (distanceToMap > 10f) {
			camSpeed = 30;
			scrollSpeed = 900;
			rotx = 54;
		} else if (distanceToMap > 5f) {
			camSpeed = 20;
			scrollSpeed = 600;
			rotx = 45;
		} else if (distanceToMap > 2f) {
			camSpeed = 10;
			scrollSpeed = 300;
			rotx = 34;
		} else {
			camSpeed = 5;
			scrollSpeed = 100;
			rotx = 30;
		}
		//transform.LookAt(new Vector3 (rotx, 90, 0));
		transform.rotation = Quaternion.Euler (new Vector3 (rotx, 90, 0));


	}

	void OnTriggerEnter (Collider col)
	{
		print ("Camera hit " + col.name);
	}
}
