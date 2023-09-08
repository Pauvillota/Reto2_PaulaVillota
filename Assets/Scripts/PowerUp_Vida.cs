using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUp_Vida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject vidas = FindObjectOfType<Vidas>().gameObject;
            vidas.GetComponent<Vidas>().VidaTotal++;
            FindObjectOfType<CharacterController2D>().life++;
            vidas.GetComponent<TextMeshProUGUI>().text = vidas.GetComponent<Vidas>().VidaTotal.ToString();
            Destroy(gameObject);
        }
    }

}
