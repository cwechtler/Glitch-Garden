using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D (){
		print ("lose Collider");
		
		levelManager.LoadLevel("Lose Screen");
	}
}
