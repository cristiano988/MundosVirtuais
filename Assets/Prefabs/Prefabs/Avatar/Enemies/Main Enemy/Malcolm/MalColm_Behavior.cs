using UnityEngine;
using System.Collections;

public class MalColm_Behavior : MonoBehaviour {
	/*
	*	Enemy
	*/

	private static readonly int LEFT_PUNCH = 1;
	private static readonly int RIGHT_PUNCH = 2;
	private static readonly string PLAYER_LEFT_HAND = "PlayerLeftHand";
	private static readonly string PLAYER_RIGHT_HAND = "PlayerRightHand";

	private float nextHit;
	private float hited;
	private float hitRate;

	//
	Animator animator;
	NavMeshAgent navigation;
	Transform playerPosition;

	//Variaveis para as animaçoes
	private bool walk = false;
	private bool knocked_out = false;
	private int health;
	private float intro;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		navigation = GetComponent<NavMeshAgent> ();
		hitRate = 1.5f;
		health = 5;
		intro = Time.time + 2.0f;
	}

	// Update is called once per frame
	void Update () {
		if(Time.time <= intro)
			animator.Play ("zombie_biting");
		else if (!knocked_out) {
			if (distanceToPlayer () > 4) {
				fetchPlayer ();
			} else {
				walking (false);	
				navigation.Stop ();
				if (Time.time >= nextHit)
					tryToHit ();
			}
		}
	}

	private void knockedOut(){
		knocked_out = true;
		navigation.Stop ();
		animator.SetTrigger("knocked_out");
		StartCoroutine (Example ());

	}
	IEnumerator Example() {
		
		yield return new WaitForSeconds(3);
		Application.LoadLevel (2);

	}
	void OnTriggerEnter(Collider other) {
		//Verificar se o colider e o do player
		if (other.CompareTag (PLAYER_LEFT_HAND) || other.CompareTag (PLAYER_RIGHT_HAND) && !knocked_out
			&& Time.time >= hited){
			/* Foi o player que atingiu, mas para nao fazer sempre a animaçao,
			 * fazemos a animaçao em +/- 50% das vezes.
			 * */
			if(--health <= 0)
				knockedOut();
			else if(Random.Range(1,2) == 1){
				animator.SetTrigger ("hit_to_body_trigger");
				hited += hitRate;
			}
		}
	}

	private void fetchPlayer(){
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
		navigation.destination = new Vector3 (playerPosition.transform.position.x, 
			playerPosition.transform.position.y,
			playerPosition.transform.position.z);
		navigation.Resume ();
		walking (true);
	}

	private void walking(bool _walk){
		animator.SetBool ("walk", _walk);
	}

	private void leftPunch(){
		animator.SetTrigger ("left_punch_trigger");
	}

	private void rightPunch(){
		animator.SetTrigger ("right_punch_trigger");
	}

	private void tryToHit(){
		float random = Random.Range(1, 10);
		Debug.Log (random);
		if (random < 5)
			leftPunch ();
		else
			rightPunch ();

		nextHit = Time.time + hitRate;
	}

	private float distanceToPlayer(){
		Vector3 agent = ((Transform)GetComponent<Transform>()).position;
		Vector3 player = ((Transform)(GameObject.FindGameObjectWithTag ("Player").transform)).position;
		return Vector3.Distance(agent, player);
	}
}