using UnityEngine;
using System.Collections;

public class roverInit : MonoBehaviourWithSelection
{

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
