using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	bool paused = false;

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			paused = togglePause();
	}

	void OnGUI()
	{
		if(paused)
		{
			GUILayout.Label("Pausado");
			if(GUILayout.Button("Volver"))
				paused = togglePause();
		}
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}

}

