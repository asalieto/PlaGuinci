using UnityEngine;
using System.Collections;

public class TurretRats : MonoBehaviour {

    public float[] damage = { 6, 10, 14, 18 };
    public float[] delay = { 1.1f, 0.9f, 0.7f, 0.5f };

    public GameObject rat;

    public int level;
    public int maxLevel;

    float experience;
    public float[] levelUpCost = { 50, 120, 210 };

    float timer;
    bool powerUp;

    // Use this for initialization
    void Start () {
        experience = 0;
        level = 0;
        timer = 0;
        powerUp = false;
    }
    
    // Update is called once per frame
    void Update () {
        if (timer <= 0)
        {
            GameObject spawn = Instantiate(rat);
            spawn.transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z); ;
            spawn.SendMessage("setDamage", damage[level]);

            getExperience(delay[level]);

            if (!powerUp)
            {
                timer = delay[level];
            }
            else {
                timer = delay[level] / 2;
            }
        }
        else {
            timer -= Time.deltaTime;
        }

        if (powerUp)
        {
            getExperience(Time.deltaTime);
        }
    }

    public void changePowerUp(bool x)
    {
        Debug.Log("Holis entro aquiiii y el valor antiguo es: " + powerUp);
        Debug.Log("Torre de tipo: " + this.name);
        powerUp = x;
        Debug.Log("Adioooos salgo de aquiiii y el valor nuevo es: " + powerUp);
    }

    public void getExperience(float exp)
    {
        experience += exp;
        if (level < maxLevel)
        {
            if (experience > levelUpCost[level])
            {
                levelUp();
            }
        }
    }

    void levelUp()
    {
        if (level < maxLevel)
        {
            level++;
            GameObject fx = Instantiate(Resources.Load("LevelUp")) as GameObject;
            fx.transform.position = transform.position;
        }
    }
}
