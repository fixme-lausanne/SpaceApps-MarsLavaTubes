using UnityEngine;
using System.Collections;

public class roverInit : MonoBehaviour {

	float speed;
	public GameObject target;
	// Use this for initialization
	void Start () {
		print ("Exploration rover ready !");
		target = GameObject.Find ("map_point_target");
		speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

	}

	// On collision with something
	void OnCollisionEnter(Collision collision) {

		print ("rover collision !"+collision.collider.gameObject.name);
		if (collision.collider.gameObject.name == "map_point_target")
			{
			target = GameObject.Find ("command_center");
			print ("get ressources !");
			}
			else if (collision.collider.gameObject.name == "Command_center_Collision_mesh_001")
			{
			print ("get ressources and destroy !");
			Object.Destroy(GameObject.Find("rover_init(Clone)"));
			}
	}
}
