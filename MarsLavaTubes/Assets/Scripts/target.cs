using UnityEngine;
using System.Collections;

public class target : MonoBehaviourWithSelection {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public new void OnSelection(GameObject oldSelection) {
	if (oldSelection != null) {
		print ("target selected, ancien objet : "+oldSelection.name);

		if (oldSelection.name == "rover_exploration(Clone)") {
				roverInit rover = oldSelection.GetComponent<roverInit>() ;
				rover.target = GameObject.Find (this.name);
			}
		}
	}

}
