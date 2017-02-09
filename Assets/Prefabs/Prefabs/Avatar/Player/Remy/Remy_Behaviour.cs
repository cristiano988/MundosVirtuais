using UnityEngine;
using System.Collections;

public class Remy_Behaviour : MonoBehaviour {
	//Player
	Animator animator;
	private bool walk;
	private bool run;
	private bool fight;
	private bool left_jab;
	private bool right_cross;
	public GameObject Inimigo;
	public Transform Spam;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		walk = Input.GetKey ("w");
		run = Input.GetKeyDown (KeyCode.LeftShift) && walk;

		left_jab = Input.GetButton ("Fire1");
		right_cross = Input.GetButton ("Fire2");
		updateAnimations ();

	}

	private void updateAnimations(){
	
		animator.SetBool ("walk", walk);
		animator.SetBool ("run", run);
		animator.SetBool ("fight", fight);
		animator.SetBool ("left_jab", left_jab);
		animator.SetBool ("right_cross", right_cross);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("EnemyLeftHand"))
			Debug.Log ("Murro Enemigo");
		if (other.tag.Equals ("House") && fight== false) {

			fight = true;
				Instantiate (Inimigo, Spam);

		}
		
	}
}
