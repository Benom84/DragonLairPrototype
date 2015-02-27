using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	private int damage = 1;
	private bool debugMode = true;
	void OnTriggerEnter2D(Collider2D col) {
		
		if (col.gameObject.tag == "Player") {
			if (debugMode) Debug.Log("Attack Hit Player");
			col.gameObject.GetComponent<PlayerMovement>().Hit(damage);
			
		}
		if ((col.gameObject.tag != "Enemy") && (col.gameObject.tag != "Attack"))
			DestroyObject (gameObject);
		
	}

	public void SetDamage(int value) {
		damage = value;
	}
}
