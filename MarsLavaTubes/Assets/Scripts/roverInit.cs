using UnityEngine;
using System.Collections;


public class roverInit : MonoBehaviourWithSelection {

	public GameObject target;
	public NavMeshAgent agentNav;

	// Use this for initialization
	void Awake () {
		print ("Exploration rover ready !");
		agentNav = GetComponent<NavMeshAgent> ();
		agentNav.speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			agentNav.SetDestination (target.transform.position);
		}	
	}

	// Update is called once per frame
	void Start () {
		if (target != null) {
			print ("Rover Target is "+target.name);
		}	
	}
	
	// On collision with something
	void OnCollisionEnter(Collision collision) {

		if (collision.collider.gameObject.name != "map")
		{
			print ("rover collision !"+collision.collider.gameObject.name);
		}

		if ((collision.collider.gameObject.name == "map_point_target") ||
		    (collision.collider.gameObject.name == "map_point_cratere") ||
		    (collision.collider.gameObject.name == "map_point_artefact"))
			{
				print ("get ressources !");
				//todo get the ressources
				target = GameObject.Find ("command_center");
			}
			else if (collision.collider.gameObject.name == "command_center")
			{
				print ("get ressources and destroy !");
				Object.Destroy(this.gameObject);
			}
	}

	public new void OnSelection(GameObject oldSelectionName) {

		print ("rover selected, ancien objet : "+oldSelectionName);
	}

	public new void OnDeSelection(GameObject newSelectionName) {
		print ("rover deselected, new objet : "+newSelectionName);
	}
}
