using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Pig : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;
		if(!obj.GetComponent<Defender>()){
			return;
		}
		animator.SetBool ("isAttacking", true);
		attacker.Attack (obj);
	}
}
