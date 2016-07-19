using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PreviewTower : MonoBehaviour {

	private int numColisions;
	public int cost;
	private MeshRenderer[] renderers;
	private GameObject[] ways;
	public GameObject Tower;
	private GameObject Model;

	// Use this for initialization
	void Start () {
		numColisions = 0;
		reloadTransp ();
	}

	// Update is called once per frame
	void Update () {

		//transform.position = transform.parent.position - this.transform.parent.right;
		//transform.localRotation = transform.parent.localRotation;

		//Debug.Log (numColisions);

		if (Input.GetButtonDown("Fire3" + this.transform.GetComponentInParent<Player> ().player.ToString()) && numColisions <= 1) {
			
			this.transform.GetComponentInParent<Player> ().colocando = false;
			this.transform.GetComponentInParent<Player> ().removeSouls (cost);

			Model = Instantiate (Tower);
            Model.transform.parent = null;
			Model.transform.position = this.transform.position;
			Model.transform.GetComponent <CapsuleCollider> ().isTrigger = false;

			ways = GameObject.FindGameObjectsWithTag ("Way");

			foreach (GameObject way in ways) {
				way.GetComponent<MeshRenderer>().enabled = false;
			}
			Destroy (this.gameObject);
		}

		if (Input.GetButtonDown ("Fire2" + this.transform.GetComponentInParent<Player> ().player.ToString())) {
			//Cancel
			ways = GameObject.FindGameObjectsWithTag ("Way");

			foreach (GameObject way in ways) {
				way.GetComponent<MeshRenderer>().enabled = false;
			}
			this.transform.GetComponentInParent<Player> ().colocando = false;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		numColisions++;
		reloadTransp ();
	}

	void OnTriggerExit(Collider col){
		numColisions--;
		reloadTransp ();
	}

	void reloadTransp(){
		renderers = GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer renderer in renderers) {
			if (numColisions <= 1) {
				Color color = Color.green;
				color.a = 0.2f;
				renderer.material.color = color;
			}else{
				Color color = Color.red;
				color.a = 0.2f;
				renderer.material.color = color;
			}
		}
	}
}
