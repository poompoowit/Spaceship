using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private float myspeed;
	private int hp;
	private int cost;
	private int speedup;
	private GameControllerScript controller;

	// Use this for initialization
	void Start () {
		GameObject GameControllerObj = GameObject.FindWithTag ("GameController");
		if (GameControllerObj!= null)
		{
			controller = GameControllerObj.GetComponent <GameControllerScript>();
		}
		if (GameControllerObj == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		speedup = ((int)Time.time) / 20 + 1;
		myspeed = Random.Range (1f, 3f)*speedup;
		hp = ((int) Time.time)/10+1;
		cost = hp * 10; 
	}

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.down * Time.deltaTime * myspeed* myspeed/2);

		if (this.gameObject.transform.position.y <= -5f) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer != 10) {
			this.gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (other.gameObject);
			hp--;
			Renderer rend = GetComponent<Renderer>();
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			rend.material.color = newColor;
		} else {
			controller.AddScore (-100*hp);
			controller.playSound();
			Destroy (this.gameObject);
		}
		if (hp <= 0) {
			controller.playSound();
			controller.AddScore (cost);
			Destroy (this.gameObject);
		}
	}
}
