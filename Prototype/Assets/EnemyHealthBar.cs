using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {
	
	private GameObject enemy;
	private Enemy es;
	private int health;
	private int maxHealth;
	private Image image;
	
	// Use this for initialization
	void Start () {
		
		image = GetComponent<Image> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		es = enemy.GetComponent<Enemy> ();
		maxHealth = es.maxHP;
		health = es.hp;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enemy) {
			
			maxHealth = es.maxHP;
			health = es.hp;
			image.fillAmount = (health * 1.0f / maxHealth);
		}
		else
			image.fillAmount = 0f;
		
	}
}
