using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Example ());

	}
	IEnumerator Example() {

		yield return new WaitForSeconds(3);
		Application.LoadLevel (0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
