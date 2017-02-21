using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	public GameObject myBullet;
	private int hp;
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
		transform.position = new Vector3(Random.Range(-5f, 5f) , -4f, 5f);
		hp = 3;
		controller.setmaxhp (hp);
		controller.sethp (hp);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Horizontal") != 0 ) {
			this.gameObject.transform.Translate (Input.GetAxis ("Horizontal") * Vector3.right * Time.deltaTime *5f);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			Instantiate (myBullet,this.gameObject.transform.position,Quaternion.identity);
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}

	void OnTriggerEnter (Collider other) {
		hp--;
		controller.sethp (hp);
		if (hp <= 0) {
			controller.gameOver ();
			Destroy (this.gameObject);
		}
	}
}
