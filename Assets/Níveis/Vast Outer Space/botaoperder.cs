using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class botaoperder : MonoBehaviour {
    public Button botaoPerder;

	// Use this for initialization
	void Start () {

        botaoPerder = botaoPerder.GetComponent<Button>();
	
	}
	
	public void  IrparaGameover ()
    {
        Application.LoadLevel (2);

    }
}
