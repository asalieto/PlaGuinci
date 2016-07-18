using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public void newGame () {
		Destroy(GameObject.Find ("Song").gameObject);
		Invoke ("LoadNewGame", 1);
	}	

	public void backToMenu () {
		Invoke("LoadBackToMenu", 1);
	}

	public void credits () {
		Invoke("LoadCredits", 1);
	}

	public void controls () {
		Invoke("LoadControls", 1);
	}
	
	public void exit () {
		Invoke("LoadExit", 1);
	}
	
	void LoadNewGame(){
		Application.LoadLevel("Level2");
	}

	void LoadBackToMenu(){
		Application.LoadLevel("MainMenu");
	}

	void LoadControls(){
		Application.LoadLevel("HowTo");
	}
	
	void LoadCredits(){
		Application.LoadLevel("Credits");
	}

	void LoadExit(){
		Application.Quit ();
	}
}
