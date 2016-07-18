using UnityEngine;
using System.Collections;

public class lifetimeDestroy : MonoBehaviour {

    public float lifetime = 2.0f;

	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
