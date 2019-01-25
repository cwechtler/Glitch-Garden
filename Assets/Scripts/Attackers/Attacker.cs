using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySecond;
	[SerializeField] private int scoreValue = 10;
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget){
			animator.SetBool ("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D(){
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if (health){
				health.DealDamage (damage); 
			}
		}
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
	}
	
	public void GetScore (){
		ScoreKeeper scoreKeeper = GameObject.Find ("Score Text").GetComponent<ScoreKeeper>();
		scoreKeeper.Score(scoreValue);
	}
}
