using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour {

	public GameObject myEnemy;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy (1f));
	}

	// Update is called once per frame
	void Update () {
		//Instantiate (myEnemy, this.gameObject.transform.position, Quaternion.identity);

	}

	IEnumerator SpawnEnemy(float waitTime) {
		float x = Random.Range (0f, Time.time/10);
		while (x >= 0) {
			transform.position = new Vector3(Random.Range(-5f, 5f) , 4.5f, 5f);
			//Debug.Log (this.transform.position);
			Instantiate (myEnemy, this.gameObject.transform.position, Quaternion.identity);
			x--;
		}
		yield return new WaitForSeconds(waitTime);
		StartCoroutine (SpawnEnemy (1f));
	}
}