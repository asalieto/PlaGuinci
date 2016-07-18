using UnityEngine;
using System.Collections;

public class FlaskBehavior : MonoBehaviour {

    GameObject objective;

    public float damage = 5.0f;
    public float speed = 1.0f;
    public float gasDuration = 5.0f;
    public GameObject gasCloud;
    Quaternion randomizedRotation;


    void Start()
    {
        randomizedRotation = Random.rotation;
    }

    void Update()
    {
        if (objective)
        {
            transform.position = Vector3.MoveTowards(transform.position, objective.transform.position, speed);
            transform.Rotate(randomizedRotation.eulerAngles*Time.deltaTime);
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
            GameObject cloud = Instantiate(gasCloud);
            cloud.transform.position = transform.position;
            cloud.SendMessage("setDuration", gasDuration);
            cloud.SendMessage("setDamage", damage);
            Destroy(gameObject);
        }
    }


}
