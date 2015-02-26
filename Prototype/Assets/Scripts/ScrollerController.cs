using UnityEngine;
using System.Collections;

public class ScrollerController : MonoBehaviour {

	public float speed = 0;
	public static ScrollerController current;

	float pos = 0;
	
	void Start () {
		current = this;
	}

	void Update () {
		pos += speed;
		if (pos > 1.0f)
			pos -= 1.0f;

		renderer.material.mainTextureOffset = new Vector2(pos, 0);
	}
}
