using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float verSpeed = 2.0f;
	public float horSpeed = 2.0f;
	public bool debugMode = true;


	// Update is called once per frame
	void Awake () {

		// Get the player direction
		float scalex = GameObject.FindGameObjectWithTag ("Player").transform.localScale.x;

		rigidbody2D.velocity = new Vector2 (horSpeed * scalex, -verSpeed);
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Enemy") {
			// Add hit after enemy script
			if (debugMode) Debug.Log("Fireball Hit Enemy");
		
		}
		if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Attack"))
			DestroyObject (gameObject);

	}
}
