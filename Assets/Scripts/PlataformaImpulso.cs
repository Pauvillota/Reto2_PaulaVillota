using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaImpulso : MonoBehaviour
{
    public float fuerzaImpulso;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaImpulso);
            GetComponent<Animator>().Play("plataformaImpulso");
        }
    }
}
