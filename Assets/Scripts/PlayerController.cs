using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Movement speed and Rigidbody reference.
	public float speed;
	public Rigidbody body;

	//Score and health.
	private int score;
	public Text scoreText;
	public int health = 5;
	public Text healthText;
	public Image winloseBG;
	public Text winloseText;

	void Start ()
    {
		//In this codebase we don't handle negative values OR zero values.
		if (speed <= 0)
			speed = 500;
    }

	IEnumerator LoadScene(float seconds)
    {
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");
    }

	void Update ()
    {
		//Restart if you run out of health.
		if (health == 0)
        {
			winloseBG.gameObject.SetActive(true);
			winloseText.text = "Game Over!";
			winloseText.color = Color.white;
			winloseBG.color = Color.red;
			//Debug.Log("Game Over!");
			StartCoroutine(LoadScene(3));
        }
		if (Input.GetKeyDown("escape"))
			SceneManager.LoadScene("menu");
    }
	
	void FixedUpdate ()
    {
		//Player movement (written counter-clockwise).
		if (Input.GetKey("up") || Input.GetKey("w"))
			body.AddForce(0, 0, speed * Time.deltaTime);
		if (Input.GetKey("left") || Input.GetKey("a"))
			body.AddForce(-speed * Time.deltaTime, 0, 0);
		if (Input.GetKey("down") || Input.GetKey("s"))
			body.AddForce(0, 0, -speed * Time.deltaTime);
		if (Input.GetKey("right") || Input.GetKey("d"))
			body.AddForce(speed * Time.deltaTime, 0, 0);
	}

	//Update the player score
	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	//Update the player's health
	void SetHealthText()
    {
		healthText.text = "Health: " + health;
    }

	void OnTriggerEnter (Collider other)
    {
		//Scoring points by picking coins.
		if (other.gameObject.tag == "Pickup")
        {
			score++;
			SetScoreText();
			//Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		//Losing life by rolling into a trap.
		if (other.gameObject.tag == "Trap")
        {
			health--;
			SetHealthText();
			//Debug.Log("Health: " + health);
        }
		//Reaching the goal!
		if (other.gameObject.tag == "Goal")
        {
			winloseBG.gameObject.SetActive(true);
			winloseText.text = "You Win!";
			winloseText.color = Color.black;
			winloseBG.color = Color.green;
			//Debug.Log("You win!");
			StartCoroutine(LoadScene(3));
        }
    }


}
