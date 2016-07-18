using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private float time;
	public float damage;

	// Use this for initialization
	void Start () {
		this.GetComponent<BoxCollider>().enabled = false;
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<BoxCollider>().enabled) {
			time += Time.deltaTime;
		}

		if (time > 0.5f) {
			this.GetComponent<BoxCollider>().enabled = false;
			time = 0.0f;
		}
	}
		
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy"){
			col.gameObject.SendMessage("ReceiveDmg", damage);
        }
	}

	public void EnableCollider(){
		this.GetComponent<BoxCollider>().enabled = true;
	}
}
