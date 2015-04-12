using UnityEngine;
using System.Collections;

public class MonoBehaviourWithSelection :MonoBehaviour
{
	public MonoBehaviourWithSelection ()
	{

	}

	public void OnSelection(GameObject oldSelection) {
		
		print (this.name+" selected, ancien objet : "+oldSelection.name);
	}
	
	public void OnDeSelection(GameObject newSelection) {
		print (this.name+" deselected, new objet : "+newSelection.name);
	}
}

