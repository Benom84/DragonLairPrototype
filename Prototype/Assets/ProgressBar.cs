using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	private GameObject player;
	private PlayerMovement pm;
	private int health;
	private int maxHealth;
	private Image image;

	// Use this for initialization
	void Start () {

		image = GetComponent<Image> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		pm = player.GetComponent<PlayerMovement> ();
		maxHealth = pm.maxHP;
		health = pm.hp;


	}
	
	// Update is called once per frame
	void Update () {

		if (player) {

			maxHealth = pm.maxHP;
			health = pm.hp;
			image.fillAmount = (health * 1.0f / maxHealth);
		}
		else
			image.fillAmount = 0f;
	
	}
}
