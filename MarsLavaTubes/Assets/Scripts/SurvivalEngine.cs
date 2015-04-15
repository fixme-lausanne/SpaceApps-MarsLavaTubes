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

	// Survival
	int surv_human_oxygen;
	int surv_human_food;
	int surv_human_water;
	int surv_depleted_oxygen;
	int surv_depleted_food;
	int surv_depleted_water;
	bool populationDecreasing;
	
	// production
	int prod_power;
	int prod_oxygen;
	int prod_food;
	//int prod_mining;

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
		oxygen = 1000;
		ore = 0;

		conso_human_water = 4;
		conso_human_food = 10;
		conso_human_power = 5;
		conso_human_oxygen = 2;
		conso_prod_food_water = 100; // with recycling
		conso_prod_food_power = 1;

		//Survival
		surv_human_oxygen = 1;
		surv_human_food = 7;
		surv_human_water = 3;
		surv_depleted_oxygen = 0;
		surv_depleted_food = 0;
		surv_depleted_water = 0;

		//prod_mining = 0;
		prod_power = 500; // solar
		prod_oxygen = 1;
		prod_food = 1;
		
		lifesupport = 0;
		propulsion = 0;
	}

	void Update ()
	{
		//Day passes
		if (Time.fixedTime % cycle_len == 0) {
			day += 1;

			ConsumeLifeSupport ();
			ConsumeProduction ();
			ProduceResource ();
			HumanSuvivival ();
			GameOver ();
		}
		CheckDepletion ();

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

	void CheckDepletion ()
	{
		txt_message.text = "";
		if (power <= 0) {
			power = 0;
			txt_message.text += "\nOut of power !";
		}
		if (water <= 0) {
			water = 0;
			txt_message.text += "\nOut of water !";
		}
		if (food <= 0) {
			food = 0;
			txt_message.text += "\nOut of food !";
		}
		if (oxygen <= 0) {
			oxygen = 0;
			txt_message.text += "\nOut of oxygen !";
		}
		if (populationDecreasing) {
			txt_message.text += "\nPopulation is decreasing !";
		}
	}

	void ConsumeLifeSupport ()
	{
		power -= conso_human_power * population;
		water -= conso_human_water * population;
		food -= conso_human_food * population;
		oxygen -= conso_human_oxygen * population;
	}

	void ConsumeProduction ()
	{
		if (power > 0) {
			water -= conso_prod_food_water;
			power -= conso_prod_food_power;
		}
	}

	void ProduceResource ()
	{
		power += prod_power;
		if (water > 0 && power > 0) {
			oxygen += prod_oxygen;
			food += prod_food;
		}
	}

	void HumanSuvivival ()
	{
		// Count days without resources
		if (food <= 0) {
			surv_depleted_food += 1;
		} else {
			surv_depleted_food = 0;
		}
		if (oxygen <= 0) {
			surv_depleted_oxygen += 1;
		} else {
			surv_depleted_oxygen = 0;
		}
		if (water <= 0) {
			surv_depleted_water += 1;
		} else {
			surv_depleted_water = 0;
		}
		//Decrease population
		populationDecreasing = false;
		if (surv_depleted_food >= surv_human_food) {
			population -= 1;
			populationDecreasing = true;
		}
		if (surv_depleted_oxygen >= surv_human_oxygen) {
			population -= 1;
			populationDecreasing = true;
		}
		if (surv_depleted_water >= surv_human_water) {
			population -= 1;
			populationDecreasing = true;
		}
	}

	void GameOver ()
	{
		if (population <= 0) {
			Application.LoadLevel ("GameOver");
		}
	}
}
