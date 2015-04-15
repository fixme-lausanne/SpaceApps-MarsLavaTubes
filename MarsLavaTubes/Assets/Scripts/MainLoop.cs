﻿using UnityEngine;
using System.Collections;

public class MainLoop : MonoBehaviour
{
	
	int terrainSize;
	int featureNumber;
	float scrollSpeed;
	float camSpeed;
	public GameObject mCamera;
	public GameObject mRoverInit;
	public GameObject mTarget;
	public GameObject mSpawnPoint;
	public GameObject mMapPoint;
	public GameObject mCenter;
	public GameObject mSun;

	void Start ()
	{
		terrainSize = 15;
		featureNumber = 30;
		scrollSpeed = 500;
		camSpeed = 10;
		GeneratePoints ();
	}

	void Update ()
	{
		// Sun rotation
		mSun.transform.Rotate (new Vector3 (0.5f, 0, 0));

		// Camera position
		float forwardSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * camSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * Time.deltaTime * camSpeed;
		float zoomSpeed = Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		mCamera.transform.position += new Vector3 (forwardSpeed, -zoomSpeed, -sideSpeed);
	
		if (Input.GetKeyDown (KeyCode.R)) {

			GameObject rover = Instantiate (mRoverInit, mSpawnPoint.transform.position, mSpawnPoint.transform.rotation) as GameObject;
			roverInit roverCmp = rover.GetComponent<roverInit> ();
			roverCmp.target = mTarget;
		}
	}

	void GeneratePoints ()
	{
		Vector2 randomPoint;
		int randomHeight;
		float randomRotation;
		for (int i=0; i<featureNumber; i++) {
			randomPoint = Random.insideUnitCircle * terrainSize;
			randomRotation = Random.Range (0f, 180f);
			randomHeight = Random.Range (0, 5);
			Instantiate (mMapPoint, mCenter.transform.position + new Vector3 (randomPoint.x, randomHeight, randomPoint.y), Quaternion.Euler (new Vector3 (-90, randomRotation, 0)));
		}
	}
	
}
