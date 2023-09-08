using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public AudioClip puertaAuido;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo detecta colisiones del Player
        if (collision.CompareTag("Player"))
        {
            //Encuentro el objeto Puntaje en el juego
            GameObject puntaje = GameObject.FindObjectOfType<Puntaje>().gameObject;
            //Le sumo un punto a la variable PuntajeTotal
            puntaje.GetComponent<Puntaje>().PuntajeTotal++;
            //Muestro el PuntajeTotal en el texto del canvas
            puntaje.GetComponent<TextMeshProUGUI>().text = puntaje.GetComponent<Puntaje>().PuntajeTotal.ToString();
            audioSource.PlayOneShot(puertaAuido);
            //Elimino la moneda
            Destroy(gameObject);
        }
    }
}
