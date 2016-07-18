using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoisonEnemies : MonoBehaviour {

    public float lifeTime = 5.0f;
    public float damagePerSecond = 3.0f;

	void Start () {
    }
	

	void Update () {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else if (lifeTime < gameObject.GetComponent<ParticleSystem>().startLifetime) {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
	}

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.gameObject);
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SendMessage("ReceiveDmg", damagePerSecond * Time.deltaTime);
        }
    }

    void setDamage(float dmg)
    {
        damagePerSecond = dmg;
    }

    void setDuration(float time)
    {
        lifeTime = time;
    }
}
