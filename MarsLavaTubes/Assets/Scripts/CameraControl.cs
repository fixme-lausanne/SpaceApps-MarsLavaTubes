using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	void OnTriggerEnter (Collider col)
	{
		print ("Camera hit " + col.name);
	}
}
