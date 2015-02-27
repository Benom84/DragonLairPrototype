using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int hp = 2;
	public float attackDelay = 2f;
	public float attackSpeed = 2f;
	public int attackDamage = 1;
	public GameObject attack;

	private float lastAttack = 0f;
	private GameObject player;
	private LevelManager levelManager;


	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		levelManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelManager>();
	
	}
	
	void FixedUpdate () {

		if (levelManager.gameEnded)
						return;

		if (hp <= 0) DestroyObject (gameObject);
		if (Time.time > lastAttack + attackDelay) Attack ();


	
	}

	private void Attack() {

		lastAttack = Time.time;

		// Find the player y location
		Vector2 attackDirection = player.transform.position - transform.position;
		attackDirection = attackDirection.normalized;
		GameObject currAttack = Instantiate (attack, transform.position, transform.rotation) as GameObject;
		currAttack.rigidbody2D.AddForce (attackDirection * attackSpeed);
		currAttack.GetComponent<EnemyAttack> ().SetDamage (attackDamage);

	
	}

	public void Hit(int force) {

		hp -= force;
	}
}
