using UnityEngine;
using System.Collections;

public class PrepareTowersST : State {
	//private GettingCostSM gettingCost;
	public float timeToChange;
	private float timeToExit;

	void OnEnable(){
		Debug.Log ("Entrando en el estado de PrepareTowersST");
		GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().prepareGame = true;
		GameObject.FindGameObjectsWithTag ("Player") [1].GetComponent<Player> ().prepareGame = true;
		timeToChange = 20.0f;
		timeToExit = 0;

		GameObject.Find ("Canvas").transform.FindChild("preparacion").gameObject.SetActive(true);	
	}

	void Start(){
		
	}

	void Update()
	{
		timeToExit += Time.deltaTime;

		if (timeToExit >= 3.0f) {
			//GameObject.FindGameObjectWithTag ("Batalla").gameObject.SetActive (false);	
		}
	}

	public override void CheckExit(){
		if (timeToExit >= timeToChange){
			Debug.Log ("Saliendo del estado PrepareTowersST");
			stateMachine.ChangeState(this.GetComponent<GettingCostSM>());
		}
	}
}
