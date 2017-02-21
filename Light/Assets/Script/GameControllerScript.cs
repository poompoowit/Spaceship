using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	private int score;
	private int time;
	private int maxtime;
	private int hitpoint;
	private int maxhitpoint;
	private bool gameover;

	// Use this for initialization
	void Start () {
		score = 0;
		maxtime = 200;
		gameover = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
	}

	public void gameOver ()
	{
		gameover = true;
	}

	public void playSound ()
	{
		this.gameObject.GetComponent<AudioSource> ().Play ();
	}

	public void setmaxhp (int hp)
	{
		maxhitpoint = hp;
	}

	public void sethp (int hp)
	{
		hitpoint = hp;
	}

	void OnGUI () {
		if (Time.time >= maxtime) {
			gameover = true;
		}
		if (!gameover) {
			time = (int)Time.time;
			GUI.Label (new Rect (10, 300, 200, 100), "Total Time  : " + time.ToString () + " / " + maxtime.ToString () +
				"\nHitpoint : " + hitpoint.ToString () + " / " + maxhitpoint.ToString () +
				"\nScore : " + score.ToString ());
		} else {
			Time.timeScale=0;
			GUI.Window (0, new Rect (0, 0, 600, 600), OverMenu, "Game Over");
		}
	}

	void OverMenu(int windowOver) {
		if (hitpoint > 0) {
			time = 200;
		}
		GUI.Label ( new Rect(100,100,200,200), "<size=20>Total Time  : " + time.ToString () + "\nScore: " + score + "</size>");
		if (GUI.Button ( new Rect(200,200,50,50), "Quit"))
			Application.Quit();
	}
}
