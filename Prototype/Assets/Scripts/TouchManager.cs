using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public float maxPressTime = 0.3f;
	public GUIText guiText;
	
	private PlayerMovement pm;
	private bool debugMode = true;
	private float lastPressTime = 0f;
	private int pressCount = 0;
	private GameObject[] buttons;
	private bool attackPressed = false;
	private bool buttonPressed = false;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {

		pm = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement>();
		buttons = GameObject.FindGameObjectsWithTag ("Button");
		levelManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelManager>();

	}
	
	void FixedUpdate () {

		if (levelManager.gameEnded)
						return;

		// If an attack was triggered
		if (attackPressed) {

			// If the time from the last press exceeds the time limit, or the press count is max, reset it.
			if ((Time.time > lastPressTime + maxPressTime) || (pressCount == 3)) {

				if (pressCount == 1)
					pm.Attack1 ();
				if (pressCount == 2)
					pm.Attack2 ();
				if (pressCount == 3)
					pm.Attack3 ();

				// Init counters
				attackPressed = false;
				pressCount = 0;

			}
		}
		guiText.text = "pressCount = " + pressCount + " PressTime = " + Mathf.Max (maxPressTime + lastPressTime - Time.time, 0);
		
		for (int i = 0; i < Input.touchCount; i++) {
			
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			
			// If the current touch just began
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				foreach (GameObject button in buttons) {
					if (button.collider2D == Physics2D.OverlapPoint (touchPos)) {
						buttonPressed = true;
						button.GetComponent<MovementButton> ().ButtonPress ();
					}
				}
				// If it is not a button press, it is an attack press
				if (!buttonPressed) {
					// We will add to the counter, the attack will be by the time
					lastPressTime = Time.time;
					attackPressed = true;
					pressCount++;
					pm.Flip (wp);
				}
			}

			buttonPressed = false;
		}

#if UNITY_EDITOR
		if (Input.GetMouseButtonDown (0)) {

			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			foreach (GameObject button in buttons) {
				if (button.collider2D == Physics2D.OverlapPoint (touchPos)) {
					buttonPressed = true;
					button.GetComponent<MovementButton> ().ButtonPress ();
				}
			}
			// If it is not a button press, it is an attack press
			if (!buttonPressed) {
				// We will add to the counter, the attack will be by the time
				lastPressTime = Time.time;
				attackPressed = true;
				pressCount++;
				pm.Flip (wp);
			}
		}
		
		buttonPressed = false;
#endif
	}
}
