using UnityEngine;

public class Blocker : MonoBehaviour {

	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	
	void OnTriggerStay2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		if (attacker){
			animator.SetTrigger ("UnderAttack Trigger");
		}	
	}
}
