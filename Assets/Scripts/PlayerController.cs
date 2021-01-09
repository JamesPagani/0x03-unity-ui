using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//Movement speed and Rigidbody reference.
	public float speed;
	public Rigidbody body;

	//Score and health.
	private int score;
	public int health = 5;

	void Start ()
    {
		//In this codebase we don't handle negative values OR zero values.
		if (speed <= 0)
			speed = 500;
    }

	void Update ()
    {
		//Restart if you run out of health.
		if (health == 0)
        {
			Debug.Log("Game Over!");
			SceneManager.LoadScene("maze");
        }
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

	void OnTriggerEnter (Collider other)
    {
		//Scoring points by picking coins.
		if (other.gameObject.tag == "Pickup")
        {
			score++;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		//Losing life by rolling into a trap.
		if (other.gameObject.tag == "Trap")
        {
			health--;
			Debug.Log("Health: " + health);
        }
		//Reaching the goal!
		if (other.gameObject.tag == "Goal")
        {
			Debug.Log("You win!");
        }
    }
}
