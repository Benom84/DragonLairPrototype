using UnityEngine;
using System.Collections;

public class MovementButton : MonoBehaviour {

	public enum Button{Up,Left,Right,Attack};
	public Button button;
	public float maxPressTime = 1f;
	public GUIText guiText;

	private PlayerMovement pm;
	private bool debugMode = true;
	private float lastPressTime = 1f;
	private int pressCount = 0;



	private void Start () {

		pm = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement>();
	}

	private void FixedUpdate () {


		// If the time from the last press exceeds the time limit, or the press count is max, reset it.
		if ((Time.time > lastPressTime + maxPressTime) ||  (pressCount == 3))
						pressCount = 0;

		if (button == Button.Attack)
			guiText.text = "pressCount = " + pressCount + " PressTime = " + Mathf.Max (maxPressTime + lastPressTime - Time.time, 0);

		for (int i = 0; i < Input.touchCount; i++)
		{

			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);

			// If the current touch just began
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				if (collider2D == Physics2D.OverlapPoint(touchPos))
				{
					if (button == Button.Up) {
						if (debugMode) Debug.Log("Detected Up Touch");
						pm.MoveUp();
					}
					if (button == Button.Left) {
						if (debugMode) Debug.Log("Detected Left Touch");
						pm.MoveLeft();
					}
					if (button == Button.Right) {
						if (debugMode) Debug.Log("Detected Right Touch");
						pm.MoveRight();
					}
					if (button == Button.Attack) {
						if (debugMode) Debug.Log("Detected Attack Touch");
						lastPressTime = Time.time;
						if (pressCount == 0) pm.Attack0();
						if (pressCount == 1) pm.Attack1();
						if (pressCount == 2) pm.Attack2();
						pressCount++;


					}
				}
			}
		}
	}
	/*
	private void OnMouseDown() {
		if ((Time.time < lastPressTime + maxPressTime) ||  (pressCount == 3))
			pressCount = 0;

		if (button == Button.Up) {
			if (debugMode) Debug.Log("Detected Up Touch");
			pm.MoveUp();
		}
		if (button == Button.Left) {
			if (debugMode) Debug.Log("Detected Left Touch");
			pm.MoveLeft();
		}
		if (button == Button.Right) {
			if (debugMode) Debug.Log("Detected Right Touch");
			pm.MoveRight();
		}
		if (button == Button.Attack) {
			if (debugMode) Debug.Log("Detected Attack Touch");
			lastPressTime = Time.time;
			if (pressCount == 0) pm.Attack0();
			if (pressCount == 1) pm.Attack1();
			if (pressCount == 2) pm.Attack2();
			pressCount++;
		}
	}
	*/
}
