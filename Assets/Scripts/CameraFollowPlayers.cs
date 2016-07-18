using UnityEngine;
using System.Collections;

public class CameraFollowPlayers : MonoBehaviour {

    //Array que almacena referencias a todos los personajes
    GameObject[] players;

    //Limites de los bordes de la pantalla
    //Se toman de las posiciones mas extremas de los personajes
    float leftBound = 0;
    float rightBound = 0;
    float topBound = 0;
    float bottomBound = 0;

    //Atributos de la camara
    Vector2 cameraCenter;
    Vector3 cameraPosition;
    public float cameraSpeed = 0.02f;

    float zoom = 1.0f;

    public float minZoom = 8.0f;
    public float maxZoom = 40.0f;

	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");


    }
	
	void FixedUpdate () {
           
        
        //Cada frame se inicializan al valor del jugador 1
        leftBound = players[0].transform.position.x;
        rightBound = players[0].transform.position.x;
        topBound = players[0].transform.position.z;
        bottomBound = players[0].transform.position.z;

        //Y se compara con el resto de jugadores
        //Si alguno se aleja del centro, expande el borde
        foreach (GameObject player in players)
        {
            if (player.transform.position.x < leftBound)
            {
                leftBound = player.transform.position.x;
            }
            if (player.transform.position.x > rightBound)
            {
                rightBound = player.transform.position.x;
            }
            if (player.transform.position.z > topBound)
            {
                topBound = player.transform.position.z;
            }
            if (player.transform.position.z < bottomBound)
            {
                bottomBound = player.transform.position.z;
            }

        }

        //Calculando el centro de la camara
        cameraCenter = new Vector2(((rightBound + leftBound) / 2), ((topBound + bottomBound) / 2));

        //Calculando el zoom de la camara
        //Valores mas altos implican una camara mas lejana
        zoom = Mathf.Sqrt(Mathf.Pow(((rightBound - leftBound) / 1.6f), 2) + Mathf.Pow(((topBound - bottomBound) / 0.9f), 2));

        //Limitadores de distancia
        if (zoom < minZoom)
        {
            zoom = minZoom;
        }

        if (zoom > maxZoom)
        {
            zoom = maxZoom;
        }

        //La posicion que debe tomar la camara
        cameraPosition = new Vector3(cameraCenter.x, zoom * Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.x)), (cameraCenter.y) - (zoom * Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.x))));

        //Movimiento suavizado con interpolado lineal
        transform.position = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed);
    }
}
