using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sideForce = 2.0f;
	public float upForce = 2.0f;
	public GameObject fireball;
	public GameObject blueFireball;

	private bool debugMode = true;

	public void MoveUp() {

		if (debugMode) Debug.Log ("MoveUp was called");
		Vector2 speed = rigidbody2D.velocity;
		speed.y += upForce;
		rigidbody2D.velocity = speed;


	}

	public void MoveLeft() {

		if (debugMode) Debug.Log ("MoveLeft was called");
		Vector2 speed = rigidbody2D.velocity;
		speed.x -= sideForce;
		rigidbody2D.velocity = speed;
	
	}

	public void MoveRight() {

		if (debugMode) Debug.Log ("MoveRight was called");
		Vector2 speed = rigidbody2D.velocity;
		speed.x += sideForce;
		rigidbody2D.velocity = speed;

	}

	public void Attack0() {

		Vector3 pos = transform.position;
		pos.x += 1.6f;
		Instantiate (fireball, pos, transform.rotation);
	}

	public void Attack1() {
		
		Vector3 pos = transform.position;
		pos.x += 1.6f;
		Instantiate (blueFireball, pos, transform.rotation);
	}

	public void Attack2() {
		
		Vector3 pos = transform.position;
		pos.x += 1.6f;
		Instantiate (fireball, pos, transform.rotation);
	}
}
