using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {

	GameObject objective;

	public float damage = 10.0f;
	public float speed = 1.0f;

	void Start () {

	}

	void Update () {
		if (objective)
		{
			transform.position = Vector3.MoveTowards(transform.position, objective.transform.position, speed);
			transform.rotation = Quaternion.LookRotation(objective.transform.position - transform.position);
		}
		else
		{
			Debug.Log("Proyectil destruido por falta de objetivo");
			Destroy(gameObject);
		}
	}

	void setObjective(GameObject enemy)
	{
		objective = enemy;
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