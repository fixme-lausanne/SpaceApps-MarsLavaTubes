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

public class command_Center : MonoBehaviourWithSelection {

	public GameObject mRoverInit;
	private bool instanceInit;
	private GUILayer test;
	public NavMeshAgent agentNav;

	// Use this for initialization
	void Start () {
		instanceInit = false;
	}
	
	// Update is called once per frame
	void Update() {
	}

	// On collision with something
	void OnCollisionEnter(Collision collision) {

		if(instanceInit == false)
		{
			print ("Contact Mars !");
			//GameObject overExplo = Instantiate (mRoverInit);

			roverInit rover = mRoverInit.GetComponent<roverInit>() ;
			rover.target = GameObject.Find ("map_point_target");
			instanceInit = true;
		}
	}

	public new void OnSelection(GameObject oldSelection) {
		
		print ("Command center selected, ancien objet : "+oldSelection.name);
		
		if (oldSelection != null) {
			if (oldSelection.name == "rover_exploration(Clone)") {
				roverInit rover = oldSelection.GetComponent<roverInit>() ;
				rover.target = GameObject.Find (this.name);
			}
		}
	}
}
