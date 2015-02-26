using UnityEngine;
using System.Collections;

public class TouchControllerBonus : MonoBehaviour {

	private PlayerMovement pm;

	void Start () {
		pm = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}

	void FixedUpdate () {
		for (int i = 0; i < Input.touchCount; i++) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				pm.Attack0();
			}
		}
	}
}
