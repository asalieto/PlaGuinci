using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

	public Transform goal;
	private NavMeshAgent agent;

	void Start () {
		//goal = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update(){
		agent.destination = goal.position; 
		if (Vector3.Distance (this.transform.position, goal.position) < 4.5f) {
			Destroy (this.gameObject);
			GameObject.FindWithTag ("MainCamera").GetComponent<GameScr> ().enterEnemy ();
		}
	}
}