using UnityEngine;
using System.Collections;

public class LOSE : MonoBehaviour {

	private int entradas;

	// Use this for initialization
	void Start () {
		entradas = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		entradas++;
		if (entradas >= 20) {
			Application.LoadLevel ("EndGame_Lose");
		}
	}
}
