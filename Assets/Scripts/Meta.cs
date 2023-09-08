using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo detecta colisiones del Player
        if (collision.CompareTag("Player"))
       
        {
            //Mostrar PanelGanar
            GameObject.FindObjectOfType<Paneles>().panelGanar.SetActive(true);
        }
    }
}
