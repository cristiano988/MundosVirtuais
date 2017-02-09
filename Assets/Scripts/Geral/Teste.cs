using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		bool run = Input.GetKey ("w");
		animator.SetBool ("Run", run);
	}
}
