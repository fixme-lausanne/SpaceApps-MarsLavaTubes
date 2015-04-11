using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SurvivalEngine : MonoBehaviour {

	public int cycle_len;
	public int day;
	public int population;

	// resources
	public int energy;
	public int water;
	public int ore;
	public int food;

	// conso
	public int lifesupport;
	public int propulsion;

	// UI texts
	public Text txt_energy;
	public Text txt_water;
	public Text txt_ore;
	public Text txt_food;
	public Text txt_lifesupport;
	public Text txt_propulsion;
	public Text txt_day;
	public Text txt_pop;

	void Start () {
		cycle_len 	= 5;
		energy	 	= 100;
		water	 	= 100;
		ore		 	= 500;
		food 		= 100;
		lifesupport = 100;
		propulsion 	= 100;
		population	= 10;
	}

	void Update () {
		if (Time.fixedTime % cycle_len == 0) {
			day += 1;
			consumeResources();
		}

		// UI Update
		txt_pop.text = "Population="+population;
		txt_day.text = "CurrentDay="+day;
		txt_energy.text = "Energy="+energy;
		txt_water.text = "Water="+water;
		txt_ore.text = "Ore="+ore;
		txt_food.text = "Food="+food;
		txt_lifesupport.text = "LifeSupport="+lifesupport;
		txt_propulsion.text = "Propulsion="+propulsion;
	}

	void consumeResources() {
	}

	void gainResouce(){
	}
}
