using UnityEngine;
using System.Collections;

public class command_Center : MonoBehaviour {

	public GameObject mRoverInit;
	private bool instanceInit;


	// Use this for initialization
	void Start () {
		instanceInit = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	// On collision with something
	void OnCollisionEnter(Collision collision) {
/*
		foreach (ContactPoint contact in collision.contacts) {
			print ("Contact ");
			if ((contact.Equals (GameObject.Find ("map"))) && 
*/
		if(instanceInit == false)
		{
			print ("Contact Mars !");
			GameObject roverInit = Instantiate (mRoverInit);
			instanceInit = true;
		}
	}
}
