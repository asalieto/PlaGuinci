using UnityEngine;
using System.Collections;

public class CalculateCost : MonoBehaviour {
	public float realCost;
	private float totalCost;
	private float totalTowers;
	public int index;

	// Use this for initialization
	void Start () {
		realCost = 0.0f;
		totalCost = 0.0f;
		totalTowers = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (index != 3) {
			if (col.gameObject.tag == "TowerRange") {
                if (gameObject.GetComponentInParent<TurretShot>()) {
				    totalCost += col.gameObject.GetComponentInParent<TurretShot> ().level+1;
                }
                else if (gameObject.GetComponentInParent<RepeaterShot>())
                {
                    totalCost += col.gameObject.GetComponentInParent<RepeaterShot>().level + 1;
                }
                else if (gameObject.GetComponentInParent<TurretRats>())
                {
                    totalCost += col.gameObject.GetComponentInParent<TurretRats>().level + 1;
                }

                totalTowers++;
			}
		}
	}

	public void ChangeCost(){
		//sumatorio(nivel torre)/num torres
		if (totalTowers != 0) {
			realCost = (totalCost+(totalTowers*2) / totalTowers)*2;
		} else {
			realCost = 1;
		}
		NavMesh.SetAreaCost(index, realCost);
	}
}
