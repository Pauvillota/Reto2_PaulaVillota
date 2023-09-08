using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trampa : MonoBehaviour
{
    public bool puedeMorir;
    public bool invertirSprite;
    private Vector2 actualpos;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (puedeMorir)
        {
            if (collision.CompareTag("Bala"))
            {
                Destroy(collision.transform.gameObject);
                Destroy(transform.parent.gameObject);
            }
        }
        //Solo detecta colisiones del Player
        if (collision.CompareTag("Player") && !FindObjectOfType<Vidas>().inmortal)
        {
            //Encuentro el objeto Vidas en el juego
            GameObject vidas = GameObject.FindObjectOfType<Vidas>().gameObject;
            //Le resto un punto a la variable VidaTotal
            vidas.GetComponent<Vidas>().VidaTotal--;
            FindObjectOfType<CharacterController2D>().life--;
            //Muestro la VidaTotal en el texto del canvas
            vidas.GetComponent<TextMeshProUGUI>().text = vidas.GetComponent<Vidas>().VidaTotal.ToString();
            //Llamar a CondicionesVida para evaluar el GameOver
            vidas.GetComponent<Vidas>().CondicionesVida();
            //Devolver al jugador al inicio
            collision.transform.position = FindObjectOfType<Inicio>().transform.position;
        }

    }

    private void Update()
    {
        StartCoroutine(CheckEnemyMoving());
    }
    IEnumerator CheckEnemyMoving()

    {

        actualpos = transform.position;

        yield return new WaitForSeconds(0.5f);


        if (transform.position.x > actualpos.x)
        {
            spriteRenderer.flipX = !invertirSprite;
        }
        else if (transform.position.x < actualpos.x)
        {
            spriteRenderer.flipX = invertirSprite;
        }


    }
}
