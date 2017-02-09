using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ligar : MonoBehaviour {

	SerialPort serialPort;
	// Use this for initialization
	void Start () {
		serialPort = new SerialPort ("COM7", 9600);
		serialPort.Open ();
		serialPort.Write ("l");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
