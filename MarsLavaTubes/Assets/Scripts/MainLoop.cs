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

public class MainLoop : MonoBehaviour
{
	
	int terrainSize;
	int featureNumber;
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
		GeneratePoints ();
	}

	void Update ()
	{
		// Sun rotation
		mSun.transform.Rotate (new Vector3 (0.5f, 0, 0));
	
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
