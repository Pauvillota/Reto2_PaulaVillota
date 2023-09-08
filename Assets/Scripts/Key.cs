using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo detecta colisiones del Player
        if (collision.CompareTag("Player"))
        {
            //Encuentro el objeto KeysCanvas en el juego
            GameObject puntaje = GameObject.FindObjectOfType<KeysCanvas>().gameObject;
            //Le sumo un punto a la variable keysTotal
            puntaje.GetComponent<KeysCanvas>().keysTotal++;
            //Muestro el keysTotal en el texto del canvas
            puntaje.GetComponent<TextMeshProUGUI>().text = puntaje.GetComponent<KeysCanvas>().keysTotal.ToString();
            //Elimino la llave
            Destroy(gameObject);
        }
    }





}
