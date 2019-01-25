using UnityEngine;

public class PrefabStartSpawner : MonoBehaviour {

	[SerializeField] private float width = 1f;
	[SerializeField] private float height = 1f;

	[SerializeField] private GameObject[] defenderPrefabArray;

	void Start () {
		foreach (GameObject thisDefender in defenderPrefabArray){
			Spawn (thisDefender);
			}
	}
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myDefender = Instantiate (myGameObject) as GameObject;
		myDefender.transform.parent = transform;
		myDefender.transform.position = transform.position;
		
	}
}
