using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {
	
	void Awake (){
		Screen.SetResolution(1280, 720, false);
	}

	public void LoadGame(){
		Application.LoadLevel (1);
	}
}
