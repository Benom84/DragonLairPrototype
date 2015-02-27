using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float verSpeed = 2.0f;
	public float horSpeed = 2.0f;
	public int damage = 1;
	public bool debugMode = true;


	// Update is called once per frame
	void Awake () {

		// Get the player direction
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		float scaleX = player.transform.localScale.x;
		float playerXSpeed = player.rigidbody2D.velocity.x;
		float fireBallXSpeed = (horSpeed + ((playerXSpeed > 0) ? playerXSpeed : 0)) * scaleX;

		rigidbody2D.velocity = new Vector2 (fireBallXSpeed, -verSpeed);
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Enemy") {
			if (debugMode) Debug.Log("Fireball Hit Enemy");
			col.gameObject.GetComponent<Enemy>().Hit(damage);
		
		}
		if ((col.gameObject.tag != "Player") && (col.gameObject.tag != "Attack"))
			DestroyObject (gameObject);

	}
}
