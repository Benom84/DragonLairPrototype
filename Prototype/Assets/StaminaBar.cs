using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour {

	private GameObject player;
	private PlayerMovement pm;
	private int stamina;
	private int maxStamina;
	private Image image;
	
	// Use this for initialization
	void Start () {
		
		image = GetComponent<Image> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		pm = player.GetComponent<PlayerMovement> ();
		maxStamina = pm.maxStamina;
		stamina = pm.stamina;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player) {
			
			maxStamina = pm.maxStamina;
			stamina = pm.stamina;
			image.fillAmount = (stamina * 1.0f / maxStamina);
		}
		else
			image.fillAmount = 0f;
		
	}
}
