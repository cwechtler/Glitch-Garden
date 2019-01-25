using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;
	private AudioSource audioSource;

	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;
			if(!obj.GetComponent<Defender>()){
				return;
			}
			if(obj.GetComponent<Blocker>()){
				animator.SetTrigger ("jump trigger");
				audioSource.Play();
			}else{
				animator.SetBool ("isAttacking", true);
				attacker.Attack (obj);
			}	
	}		
}
