using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

    public GameObject[] enemigos; //vector de todos los enemigos creados
    public GameObject melee;
	public GameObject ranged;

	private float time;
	private int[] rondas = new int[10]; 
    public int cont; //variable de control para cuantos enemigos quieres crear
	private GameObject Enem;
    private Vector3 spawnPoint; //punto de spawn

	void Awake(){

		time = 0.0f;

		for(int i = 0; i<rondas.Length; i++) {
			int randito = Random.Range(1, 4); //ajin va de 1 a 2 (sticker de Ako)
			//Debug.Log(i+": "+randito);
			rondas[i] = randito;
		}
	}

    // Update is called once per frame
    void Update () {
		time += Time.deltaTime;
    }

	public void createSpawn(int _ronda){
		//Debug.Log(cont);
		switch (rondas[_ronda-1]) {
			case 1:
				if (cont <= (5  + _ronda*2)) {
					if (cont % 2 == 0) {
						InvokeRepeating ("meleeEnemy", 2, 5f);
					}else{
						InvokeRepeating ("rangedEnemy", 2, 5f);
					}
				}
			break;

			case 2:
				if (cont <= (5 + _ronda*2)) {
					int ran = Random.Range(1, 10);
					if (cont % 2 + ran <= 5) {
						InvokeRepeating("meleeEnemy", 2, 5f);
					}else {
						InvokeRepeating("rangedEnemy", 2, 5f);
					}
				}
			break;

			case 3:
				if (cont <= (5  + _ronda*2)) {
					if (cont % 3 == 0) {
						InvokeRepeating ("meleeEnemy", 2, 5f);
					} else {
						InvokeRepeating ("rangedEnemy", 2, 5f);
					}
				}
			break;

		}
	}

	public void resetCont(){
		cont = 0;
	}

    void spawnEnemy(){

        //posicionamiento del spawn de los enemigos
		spawnPoint.x = this.gameObject.transform.position.x;
		spawnPoint.y = this.gameObject.transform.position.y;
		spawnPoint.z = this.gameObject.transform.position.z;

        int randito = Random.Range(1,3); //ajin va de 1 a 2 (sticker de Ako)
       
        switch(randito){
			case 1:
				Instantiate(melee, spawnPoint, Quaternion.identity);
				break;

			case 2:
				Instantiate(ranged, spawnPoint, Quaternion.identity);
				break;
        }
        CancelInvoke();
    }

	void meleeEnemy(){
		cont++;

		spawnPoint.x = this.gameObject.transform.position.x;
		spawnPoint.y = this.gameObject.transform.position.y;
		spawnPoint.z = this.gameObject.transform.position.z;
		Instantiate(melee, spawnPoint, Quaternion.identity);

		CancelInvoke();
	}

	void rangedEnemy(){
		cont++;

		spawnPoint.x = this.gameObject.transform.position.x;
		spawnPoint.y = this.gameObject.transform.position.y;
		spawnPoint.z = this.gameObject.transform.position.z;
		Instantiate(ranged, spawnPoint, Quaternion.identity);

		CancelInvoke();
	}
}