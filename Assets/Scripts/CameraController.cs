using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Selecting the player and setting up a camera offset.
	public GameObject player;
	private Vector3 offset;
	
	void Start ()
    {
		offset = transform.position - player.transform.position;
	}

	//Follow the player's movements.
	void LateUpdate () {
		transform.position = player.transform.position + offset;

	}
}
