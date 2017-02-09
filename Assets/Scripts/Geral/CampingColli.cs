using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class CampingColli : MonoBehaviour {

	public GameObject Campingfire;
	SerialPort serialPort;

	// Use this for initialization
	void Start () {
		serialPort = new SerialPort ("COM3", 9600);

	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerEnter(Collider other){
		Debug.Log("Entrou");
		if(other.tag== "CampingCollider")
		{
			// Use this for initialization
			Debug.Log(other.tag);
				
				serialPort.Open ();
				serialPort.Write ("l");
		serialPort.Close ();

		}
		else
		{
			if(other.tag== "OceanCollider")
			{
				Debug.Log(other.tag);

				serialPort.Open ();
				serialPort.Write ("k");
				serialPort.Close ();
			}
			
		}



	}
	void OnTriggerExit(Collider other){

		

			

			Debug.Log("Saiu");
			if(other.tag== "CampingCollider")
			{
				// Use this for initialization
			Debug.Log(other.tag);
				
				serialPort.Open ();
				serialPort.Write ("d");
				serialPort.Close ();

			}
			else
		{
				if(other.tag== "OceanCollider")
				{
				Debug.Log(other.tag);
					
					serialPort.Open ();
					serialPort.Write ("d");
					serialPort.Close ();
				}

			}


		
	}
}
