using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float damage;

	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
		
	void OnTriggerEnter2D (Collider2D collider){
		if(collider.GetComponent<Attacker>()){
			Health health = collider.GetComponent<Health>();
			if (health){
				health.DealDamage (damage); 
				Destroy (gameObject);
			}
		}
	}
}
