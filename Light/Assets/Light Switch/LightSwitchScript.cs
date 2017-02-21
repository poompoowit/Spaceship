using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour {

	public GameObject LightObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), LightObject.GetComponent<Light>().enabled?"Turn OFF":"Trun ON")) {
			Debug.Log (Time.time);
			LightObject.GetComponent<Light>().enabled = !LightObject.GetComponent<Light> ().enabled;
		}
	}
}