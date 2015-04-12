using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {

	private GameObject currentSelection;
	private Light oldLight;
	private HashSet<GameObject> selectables;

	void Start () {
		selectables = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag ("SelectableUnit"));
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, 100)) {

				if (hit.collider.transform == null)
					return;

				if (currentSelection != null) {
					DestroyImmediate(currentSelection.GetComponent<Light>());

					if (oldLight != null) {
						Light replacementLight = currentSelection.AddComponent<Light>();
						System.Reflection.FieldInfo[] fields = oldLight.GetType().GetFields();
						foreach (System.Reflection.FieldInfo field in fields)
						{
							field.SetValue(replacementLight, field.GetValue(oldLight));
						}
					}
				}

				// Handle the cases where the Collider is either on the main structure or on a child
				GameObject collided = hit.collider.transform.parent != null ? hit.collider.transform.parent.gameObject : hit.collider.transform.gameObject;
				

				if (selectables.Contains(collided)) {
					oldLight = collided.GetComponent<Light>();
					DestroyImmediate(collided.GetComponent<Light>());
					Light lightSrc = collided.AddComponent<Light>();
					lightSrc.color = new Color (0f,0.5f,1f,1f);
					lightSrc.intensity = 8f;
					currentSelection = collided;
				}
			}
		}
	}
}
