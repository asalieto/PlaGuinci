using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private RaycastHit hit;
	private GameObject Model;
	public Sword weapon;

	public int souls = 10;

	public bool prepareGame;
    public float maxSpeed = 5.0f;
    public float jumpForce = 15.0f;
    public int player;
    bool canJump;

    private float raycastlenght = 1000;
    
	public bool colocando;
    // Use this for initialization
	void Start () {
		colocando = false;
        canJump = false;
		prepareGame = true;
	}

    // Update is called once per frame
	void Update(){

        //Movimiento
        if (Mathf.Abs(transform.GetComponent<Rigidbody>().velocity.magnitude) < maxSpeed)
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal" + player.ToString()), 0.0f, Input.GetAxis("Vertical" + player.ToString())), ForceMode.Impulse);
        }

        if (transform.GetComponent<Rigidbody>().velocity.x > maxSpeed)
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(maxSpeed , transform.GetComponent<Rigidbody>().velocity.y, transform.GetComponent<Rigidbody>().velocity.z);
        }

        if (transform.GetComponent<Rigidbody>().velocity.x < -maxSpeed)
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(-maxSpeed , transform.GetComponent<Rigidbody>().velocity.y, transform.GetComponent<Rigidbody>().velocity.z);
        }

        if (transform.GetComponent<Rigidbody>().velocity.z > maxSpeed)
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(transform.GetComponent<Rigidbody>().velocity.x, transform.GetComponent<Rigidbody>().velocity.y, maxSpeed);
        }

        if (transform.GetComponent<Rigidbody>().velocity.z < -maxSpeed)
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector3(transform.GetComponent<Rigidbody>().velocity.x, transform.GetComponent<Rigidbody>().velocity.y, -maxSpeed);
        }
			
		if(Input.GetAxis("Vertical" + player.ToString()) + Input.GetAxis("Horizontal" + player.ToString()) !=0.0f){
			transform.localRotation = Quaternion.Euler (0.0f, (Mathf.Atan2 (Input.GetAxis("Vertical" + player.ToString()) , -Input.GetAxis("Horizontal" + player.ToString())) * Mathf.Rad2Deg), 0.0f);
		}

		if (prepareGame) {
			//Cruceta (construccion)
			if ((Input.GetAxis ("HorizontalCross" + player.ToString ()) != 0.0f || Input.GetAxis ("HorizontalCross" + player.ToString ()) != 0.0f || Input.GetAxis ("VerticalCross" + player.ToString ()) != 0.0f || Input.GetAxis ("VerticalCross" + player.ToString ()) != 0.0f) && colocando == false) {	
				if (souls >= 1) {
					colocando = true;

					if (Input.GetAxis ("HorizontalCross" + player.ToString ()) > 0.0f) {
						Model = Instantiate (Resources.Load ("TowerBalistaPreview")) as GameObject;
					} else if (Input.GetAxis ("HorizontalCross" + player.ToString ()) < 0.0f) {
						Model = Instantiate (Resources.Load ("TowerCannonPreview")) as GameObject;
					} else if (Input.GetAxis ("VerticalCross" + player.ToString ()) > 0.0f) {
						Model = Instantiate (Resources.Load ("TowerRepeaterPreview")) as GameObject;
					} else if (Input.GetAxis ("VerticalCross" + player.ToString ()) < 0.0f) {
						Model = Instantiate (Resources.Load ("TowerRatatataPreview")) as GameObject;
					}
					Model.transform.SetParent (this.transform);
					Model.transform.position = this.transform.position - (this.transform.right * 1.5f);
					Model.transform.localRotation = this.transform.localRotation;
					Model.GetComponentInChildren<CapsuleCollider> ().isTrigger = true;
				}
			}
			//Cancelar (por si los bugs)
			if(Input.GetButtonDown ("Fire2" + player.ToString())){
				colocando = false;
				Destroy (Model);
			}

		} else {
			//Cancelar (por si los bugs)
			if(colocando == true){
				colocando = false;
				Destroy (Model);
			}
		}

		//Atacar
		if (Input.GetAxis ("Fire1" + player.ToString ())>0) {
			weapon.EnableCollider ();
		}
	}

	public void removeSouls (int n){
		/*
		int aux = 0;

		Player[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (Player pla in players) {
			pla.souls = aux;
		}
		*/
		souls -= n;
		GameObject.Find ("NumSouls").GetComponent<Text> ().text = souls.ToString ();
	}	

    //Controlar si puede saltar o no
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Terreno" && transform.GetComponent<Rigidbody>().velocity.y == 0)
        {
            canJump = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Terreno")
        {
            canJump = false;
        }
    }

	void OnTriggerEnter(Collider tower) {

		if (tower.gameObject.GetComponentInParent<TurretShot> () != null && tower.gameObject.tag == "TowerRange" && (tower.gameObject.GetComponentInParent<TurretShot> ().name == "TowerCannon" || tower.gameObject.GetComponentInParent<TurretShot> ().name == "TowerBalista")) {
			tower.gameObject.GetComponentInParent<TurretShot> ().changePowerUp (true);
		} else if(tower.gameObject.GetComponentInParent<RepeaterShot> () != null) {
			tower.gameObject.GetComponentInParent<RepeaterShot>().changePowerUp(true);
		} else if(tower.gameObject.GetComponentInParent<TurretRats> () != null) {
			tower.gameObject.GetComponentInParent<TurretRats>().changePowerUp(true);
		}
	}

	void OnTriggerExit(Collider tower){
		if (tower.gameObject.GetComponentInParent<TurretShot> () != null && tower.gameObject.tag == "TowerRange" && (tower.gameObject.GetComponentInParent<TurretShot> ().name == "TowerCannon" || tower.gameObject.GetComponentInParent<TurretShot> ().name == "TowerBalista")) {
			tower.gameObject.GetComponentInParent<TurretShot> ().changePowerUp (false);
		} else if(tower.gameObject.GetComponentInParent<RepeaterShot> () != null) {
			tower.gameObject.GetComponentInParent<RepeaterShot>().changePowerUp(false);
		} else if(tower.gameObject.GetComponentInParent<TurretRats> () != null) {
			tower.gameObject.GetComponentInParent<TurretRats>().changePowerUp(false);
		}
	}
}
