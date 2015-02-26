using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float sideForce = 2.0f;
	public float upForce = 2.0f;
	public GameObject fireball;
	public GameObject blueFireball;
	public GameObject greenFireball;

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

	public void Attack1() {

		Vector3 pos = transform.position;
		pos.x += 1.6f * transform.localScale.x;
		Instantiate (fireball, pos, transform.rotation);
	}

	public void Attack2() {
		
		Vector3 pos = transform.position;
		pos.x += 1.6f * transform.localScale.x;
		Instantiate (blueFireball, pos, transform.rotation);
	}

	public void Attack3() {
		
		Vector3 pos = transform.position;
		pos.x += 1.6f * transform.localScale.x;
		Instantiate (greenFireball, pos, transform.rotation);
	}

	public void Flip(Vector3 touchPos) {

		Vector3 scale = transform.localScale;
		float diff = touchPos.x - transform.position.x;
		// If the touch is to the right and the scale is positive
		if ((diff > 0) && (scale.x > 0))
						return;
		// If the touch is to the left and the scale is negative
		if ((diff < 0) && (scale.x < 0))
			return;

		scale.x *= -1;
		transform.localScale = scale;
	
	}
}
