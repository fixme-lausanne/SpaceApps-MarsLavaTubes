using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SurvivalEngine : MonoBehaviour
{
	// General
	public int cycle_len;
	public int day;
	public int population;
	public int lifesupport;
	public int propulsion;

	// resources
	public int power; // kW/h
	public int water; // Liter
	public int food; // MegaJoule
	public int oxygen; // kg
	public int ore; // kg

	// conso
	int conso_human_water;
	int conso_human_food;
	int conso_human_power;
	int conso_human_oxygen;
	int conso_prod_food_power;
	int conso_prod_food_water;

	// production
	int prod_power;
	int prod_oxygen;
	int prod_mining;
	int prod_food;

	// UI texts
	public Text txt_power;
	public Text txt_oxygen;
	public Text txt_water;
	public Text txt_food;
	public Text txt_ore;
	public Text txt_lifesupport;
	public Text txt_propulsion;
	public Text txt_day;
	public Text txt_pop;
	public Text txt_message;

	void Start ()
	{
		cycle_len = 5;
		population = 10;

		power = 1000;
		water = 10000;
		food = 10000;
		oxygen = 10000;
		ore = 0;

		conso_human_water = 4;
		conso_human_food = 10;
		conso_human_power = 5;
		conso_human_oxygen = 1;
		conso_prod_food_water = 100; // with recycling
		conso_prod_food_power = 1;

		prod_mining = 0;
		prod_power = 500; // solar
		prod_oxygen = 10;
		prod_food = 1;
		
		lifesupport = 0;
		propulsion = 0;
	}

	void Update ()
	{
		if (Time.fixedTime % cycle_len == 0) {
			day += 1;
			ConsumeLifeSupportPerDay ();
			ProduceResource ();
			ConsumeProduction();
		}

		// UI Update
		txt_pop.text = "Population=" + population;
		txt_day.text = "CurrentDay=" + day;
		txt_power.text = "Power=" + power;
		txt_water.text = "Water=" + water;
		txt_food.text = "Food=" + food;
		txt_oxygen.text = "Oxygen=" + oxygen;
		txt_ore.text = "Ore=" + ore;
		txt_lifesupport.text = "LifeSupport=" + lifesupport;
		txt_propulsion.text = "Propulsion=" + propulsion;
	}

	void ConsumeLifeSupportPerDay ()
	{
		txt_message.text = "";
		power -= conso_human_power * population;
		if (power < 0) {
			power = 0;
			txt_message.text += "\nOut of power !";
		}
		water -= conso_human_water * population;
		if (water < 0) {
			water = 0;
			txt_message.text += "\nOut of water !";
		}
		food -= conso_human_food * population;
		if (food < 0) {
			food = 0;
			txt_message.text += "\nOut of food !";
		}
		oxygen -= conso_human_oxygen * population;
		if (oxygen < 0) {
			oxygen = 0;
			txt_message.text += "\nOut of oxygen !";
		}
	}

	void ConsumeProduction(){
		water -= conso_prod_food_water;
		power -= conso_prod_food_power;
	}

	void ProduceResource ()
	{
		oxygen += prod_oxygen;
		power += prod_power;
		food += prod_food;
	}
}
