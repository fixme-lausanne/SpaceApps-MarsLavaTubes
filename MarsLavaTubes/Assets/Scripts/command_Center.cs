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
