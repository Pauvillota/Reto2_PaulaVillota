using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBala : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform origenBala;

    public float tiempoBala = 1.5f;
    public float fuerzaDisparo = 1000f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject nuevaBala = Instantiate(prefabBala, origenBala.position, origenBala.rotation);


            nuevaBala.GetComponent<Rigidbody2D>().AddForce(new Vector2(origenBala.lossyScale.x* fuerzaDisparo, 0));
            StartCoroutine(DestruirBala(nuevaBala));
        }
    }

    IEnumerator DestruirBala(GameObject nuevaBala)
    {
        yield return new WaitForSeconds(tiempoBala);
        Destroy(nuevaBala);
    }
}
