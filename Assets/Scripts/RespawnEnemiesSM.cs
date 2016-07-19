using UnityEngine;
using System.Collections;

public class RespawnEnemiesSM : State {
	//private GettingCostSM gettingCost;
	public float timeToChange;
	private float timeToExit;
	private static int round;

	void OnEnable(){
		timeToChange = 40.0f;
		timeToExit = 0;
		Debug.Log ("Entrando en el estado de RespawnEnemiesSM");
		GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().prepareGame = false;
		GameObject.FindGameObjectsWithTag ("Player") [1].GetComponent<Player> ().prepareGame = false;

		GameObject.Find ("Canvas").transform.FindChild("batalla").gameObject.SetActive(true);	
	}

	void Start(){
		round = 1;
		/*Debug.Log ("Entrando en el estado de RespawnEnemiesSM");
		GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().prepareGame = false;*/
	}

	void Update()
	{
		timeToExit += Time.deltaTime;
		for (int m = 0; m < GameObject.FindObjectsOfType<spawn>().Length; m++) {
			GameObject.FindObjectsOfType<spawn> () [m].createSpawn (round);
		}
	}

	public override void CheckExit(){
		if (timeToExit >= timeToChange){
			Debug.Log ("Saliendo del estado RespawnEnemiesSM");
			round++;
			if (round >= 10) {
				Debug.Log ("SE ACABARON LAS RONDAS");
			} else {
				for (int m = 0; m < GameObject.FindObjectsOfType<spawn>().Length; m++) {
					GameObject.FindObjectsOfType<spawn> () [m].resetCont();
				}

				stateMachine.ChangeState(this.GetComponent<PrepareTowersST>());
			}
		}
	}
}
