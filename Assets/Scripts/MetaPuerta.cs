using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPuerta : MonoBehaviour
{
    public AudioClip puertaAuido;
    public AudioSource audioSource;
    public Animator puertaAnim;

    public int puntajeMinimo;
    public int keysMinimo;

    public bool evaluarPuntaje;
    public bool evaluarLlaves;
    public bool evaluarPregunta;

    public GameObject panelPregunta;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo detecta colisiones del Player
        if (collision.gameObject.CompareTag("Player"))
        {
            if (evaluarPuntaje)
            {
                // Encuentra el objeto Puntaje en el juego
                Puntaje puntaje = FindObjectOfType<Puntaje>();

                if (puntaje != null && puntaje.PuntajeTotal >= puntajeMinimo)
                {
                    audioSource.PlayOneShot(puertaAuido);
                    // Ejecutar animación "door"
                    puertaAnim.Play("Puerta");
                    // Destruir la puerta
                    Destruir();
                }
                else
                {
                    Debug.Log("Te faltan monedas por conseguir.");
                }
            }
            else if (evaluarLlaves)
            {
                // Encuentra el objeto Puntaje en el juego
                KeysCanvas llaves = FindObjectOfType<KeysCanvas>();

                if (llaves != null && llaves.keysTotal >= keysMinimo)
                {
                    audioSource.PlayOneShot(puertaAuido);
                    // Ejecutar animación "door"
                    puertaAnim.Play("Puerta");
                    // Destruir la puerta
                    Destruir();
                }
                else
                {
                    Debug.Log("Te faltan llaves por conseguir.");
                }
            }
            else if (evaluarPregunta)
            {
                panelPregunta.SetActive(true);
            }
            else
            {
                audioSource.PlayOneShot(puertaAuido);
                // Ejecutar animación "door"
                puertaAnim.Play("Puerta");
                // Destruir la puerta
                Destruir();
            }
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
