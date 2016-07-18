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
	}
}