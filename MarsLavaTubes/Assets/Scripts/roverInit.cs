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

public class roverInit : MonoBehaviourWithSelection
{

	public MainLoop mainLoop;
	public GameObject target;
	public NavMeshAgent agentNav;

	void Awake ()
	{
		print ("Exploration rover ready !");
		agentNav = GetComponent<NavMeshAgent> ();
		//agentNav.speed = 0.1f;
	}

	void Start ()
	{
		if (target != null) {
			print ("Rover Target is " + target.name);
		}	
	}

	void Update ()
	{
		if (target != null) {
			agentNav.SetDestination (target.transform.position);
		}
	}
	
	// On collision with something
	void OnCollisionEnter (Collision collision)
	{

		if (collision.collider.gameObject.name != "map_collision_mesh") {
			print ("rover collision !" + collision.collider.gameObject.name);
		}

		if ((collision.collider.gameObject.name == "map_point_target") ||
			(collision.collider.gameObject.name == "map_point_crater") ||
			(collision.collider.gameObject.name == "map_point_artefact")) {
			print ("get ressources !");
			//todo get the ressources
			target = GameObject.Find ("command_center");
		} else if (collision.collider.gameObject.name == "Command_center_Collision_mesh_001") {
			print ("get ressources and destroy !");
			mainLoop.currentRoverNb += 1;
			Object.Destroy (this.gameObject);
		}
	}

	public new void OnSelection (GameObject oldSelectionName)
	{

		print ("rover selected, ancien objet : " + oldSelectionName);
	}

	public new void OnDeSelection (GameObject newSelectionName)
	{
		print ("rover deselected, new objet : " + newSelectionName);
	}
}
