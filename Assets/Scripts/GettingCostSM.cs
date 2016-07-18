using UnityEngine;
using System.Collections;

public class GettingCostSM : State {
	public State gettingCost;
	//public float timeToChange;
	//private float timeToExit;
	private bool exit;

	void OnEnable(){
		Debug.Log ("Entrando en el estado de GettingCostSM");
		GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().prepareGame = false;
		GameObject.FindGameObjectsWithTag ("Player") [1].GetComponent<Player> ().prepareGame = false;
		exit = false;
		//timeToChange = 60.0f;
		//timeToExit = 0;

		/** AQUI IRIA MOSTRAR LA HUD, SE PUEDE LLAMAR A UN METODO DIRECTAMENTE */
	}

	/*void Start(){
		Debug.Log ("Entrando en el estado de GettingCostSM");
		GameObject.FindGameObjectsWithTag ("Player") [0].GetComponent<Player> ().prepareGame = false;
		exit = false;
	}*/

	void Update()
	{
		if (!exit) {
			for(int z = 0; z<GameObject.FindGameObjectsWithTag("Way").Length; z++){
				GameObject.FindGameObjectsWithTag("Way")[z].GetComponent<CalculateCost>().ChangeCost();
				// SOLO FALTA EL SET AREA; GUARDAR NOMBRE
				// NavMesh.SetAreaCost(NavMeshAgent.
				//NavMesh.SetAreaCost(, );
				//Debug.Log(GameObject.FindGameObjectsWithTag("Way")[z].GetComponent<CalculateCost>().realCost);
			}
			exit = true;
		}
		//timeToExit += Time.deltaTime;
		//
	}

	public override void CheckExit(){
		//if (timeToExit >= timeToChange){
			//stateMachine.ChangeState();
		//}
		if (exit) {
			Debug.Log ("Saliendo del estado GettingCostSM");
			stateMachine.ChangeState(this.GetComponent<RespawnEnemiesSM>());
		}
	}
}

