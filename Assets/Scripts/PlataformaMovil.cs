using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform[] puntosMovimiento;
    public float velocidadMovimiento;
    private int siguientePlataforma;
    private bool ordenPlataformas = true;

    private void Update()
    {
        if (ordenPlataformas && siguientePlataforma + 1 >= puntosMovimiento.Length)
        {
            ordenPlataformas = false;
        }
        if (!ordenPlataformas && siguientePlataforma<= 0)
        {
            ordenPlataformas = true;
        }
        if(Vector2.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.1f)
        {
            if (ordenPlataformas)
            {
                siguientePlataforma += 1;
            }
            else
            {
                siguientePlataforma -= 1;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position, velocidadMovimiento * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
