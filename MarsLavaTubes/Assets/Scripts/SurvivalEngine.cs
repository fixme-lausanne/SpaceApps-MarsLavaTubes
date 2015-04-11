using UnityEngine;
using System.Collections;

public class SurvivalEngine : MonoBehaviour {

	public int cycle_len;
	public int day;

	// resources
	public int energy;
	public int water;
	public int ore;
	public int food;

	// conso
	public int lifesupport;
	public int propulsion;

	void Start () {
		cycle_len 	= 10;
		energy	 	= 100;
		water	 	= 100;
		ore		 	= 500;
		lifesupport = 100;
		propulsion 	= 100;
	}

	void Update () {
		if (Time.fixedTime % cycle_len == 0) {
			day += 1;
		}
	}
}
