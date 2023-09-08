using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Inmortal : MonoBehaviour
{
    public float tiempoInmortal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vidas vidas = FindObjectOfType<Vidas>();
            vidas.inmortal = true;
            vidas.ResetInmortal(tiempoInmortal);
            Destroy(gameObject);
        }
    }

}
