using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	private static Music pInstance = null;
	public static Music Instance {
		get { return pInstance; }
	}

	// Use this for initialization
	void Awake () {
		if (pInstance != null && pInstance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			pInstance = this;
		}

		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


