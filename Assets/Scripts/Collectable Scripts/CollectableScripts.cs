using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScripts : MonoBehaviour
{

    // Referencia al script de puntaje
    private Puntaje puntaje;

    // Puntos que este objeto otorga al recolectarse
    public float puntosARecompensar = 10f;

    private void Start()
    {
        // Encuentra el script de puntaje en la escena
        puntaje = FindObjectOfType<Puntaje>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.PLAYER_TAG || target.tag == TagManager.PLAYER_HEALTH_TAG)
        {

            // Incrementa el puntaje del jugador
            if (puntaje != null)
            {
                puntaje.SumarPuntos(puntosARecompensar);
            }

            // Incrementa la cantidad de monedas en el controlador del gameplay
            GameplayController.instance.coinCount++;

            // Desactiva el objeto coleccionable
            gameObject.SetActive(false);
        }
    }
}
