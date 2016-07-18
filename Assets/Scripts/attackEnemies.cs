using UnityEngine;
using System.Collections;

public class attackEnemies : MonoBehaviour {

    GameObject objective;
    GameObject[] enemies;

    public float damage = 10.0f;
    public float speed = 1.0f;
    public float range = 2.0f;
    float lifetime = 30.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (objective)
        {
            transform.position = Vector3.MoveTowards(transform.position, objective.transform.position, speed);
            transform.rotation = Quaternion.LookRotation(objective.transform.position - transform.position);
            transform.Rotate(270, 270, 0);
        }
        else
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; i++)
            {
                if (Vector3.Distance(transform.position, enemies[i].transform.position) <= range)
                {
                    objective = enemies[i];
                    break;
                }
            }
            if (!objective)
            {
                GetComponent<Rigidbody>().AddForce(Random.Range(-9.9f, 10.0f), 0, Random.Range(-9.9f, 10.0f));
                if(GetComponent<Rigidbody>().velocity.magnitude > 2.0f)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity / GetComponent<Rigidbody>().velocity.magnitude;
                }
                transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
                transform.Rotate(270, 270, 0);
            }
        }

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }


    void setDamage(float dmg)
    {
        damage = dmg;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SendMessage("ReceiveDmg", damage);
            Destroy(gameObject);
        }
    }
}
