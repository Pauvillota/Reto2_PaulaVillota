using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysCanvas : MonoBehaviour
{
    //Variable que almacena el puntaje total durante la partida
    public int keysTotal;
    private void Start()
    {
        //Inicializa el texto del canvas con el puntaje total
        gameObject.GetComponent<TextMeshProUGUI>().text = keysTotal.ToString();
    }
}
