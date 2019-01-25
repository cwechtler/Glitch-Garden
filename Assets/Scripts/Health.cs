using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] private float health = 100f;
	
	private float difficultyLevel;
	private Attacker attacker;
	
	void Start(){
		difficultyLevel = PlayerPrefsManager.GetDifficulty();
		attacker = GetComponent<Attacker>();
		DifficultyLevel();
	}
	
	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0){
			DestroyObject();
			if(attacker){
				attacker.GetScore();
			}
		}
	}
	public void DestroyObject(){
		Destroy (gameObject);
	}
	
	public void DifficultyLevel(){
		if(difficultyLevel == 1f  && attacker){
			health += 0f;
		}
		if(difficultyLevel == 2f && attacker){
			health += 10f;
		}
		if(difficultyLevel == 3f && attacker){
			health += 20f;
		}
	}
}
