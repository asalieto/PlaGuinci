using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float maxHealth=50;
	float health;
    public GameObject healthBar;
    float damagedTimer = 0.0f;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        updateHealthVisual();
	}

	// Update is called once per frame
	void Update () {
        if (damagedTimer > 0.0f)
        {
            damagedTimer -= Time.deltaTime;
            SkinnedMeshRenderer[] models = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < models.Length; i++)
            {
                models[i].material.color = Color.Lerp(Color.white, Color.red, 2 * damagedTimer);
            }
        }
	}

	public void ReceiveDmg(float _dmg){
		//Debug.Log ("He recibido daño");
		health -= _dmg;
        damagedTimer = 0.5f;
        if (health <= 0) {
			Death();
		}
        updateHealthVisual();

    }

	private void Death(){
		//Debug.Log ("He muerto");
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Bullet")
		{
			ReceiveDmg(col.GetComponent<ProjectileBehavior>().damage);
			Destroy(col.gameObject);
		}
	}
	
    public void updateHealthVisual()
    {
        float healthNormalized = health / maxHealth;
        healthBar.transform.localScale = new Vector3(healthNormalized, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}