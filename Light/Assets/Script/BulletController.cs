using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public GameObject myBullet;
	float t;
	public int startSize = 2;
	public int minSize = 1;
	public int maxSize = 4;
	public float speed = 2.0f;

	private Vector3 targetScale;
	private Vector3 baseScale;
	private int currScale;
	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer>();
		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		rend.material.color = newColor;
		t = 0;
		baseScale = transform.localScale;
		transform.localScale = baseScale * startSize;
		currScale = startSize;
		targetScale = baseScale * startSize;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * 10);
		transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);
		ChangeSize (true);
		if (this.gameObject.transform.position.y >= 20f) {
			Destroy (this.gameObject);
		}
	}

	public void ChangeSize(bool bigger) {

		if (bigger)
			currScale++;
		else
			currScale--;

		currScale = Mathf.Clamp (currScale, minSize, maxSize+1);

		targetScale = baseScale * currScale;
	}
}
