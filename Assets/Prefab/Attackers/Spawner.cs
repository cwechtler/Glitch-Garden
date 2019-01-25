using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] private float width = 1f;
	[SerializeField] private float height = 1f;

	[SerializeField] private GameObject[] attackerPrefabArray;

	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if(isTimeToSpawn (thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		
		float spawnDelay = attacker.seenEverySecond;
		float spawnPerSecond = 1 / spawnDelay;
		
		if(Time.deltaTime > spawnDelay){
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnPerSecond * Time.deltaTime / 5;
		
		return (Random.value < threshold);
		
	}
}
