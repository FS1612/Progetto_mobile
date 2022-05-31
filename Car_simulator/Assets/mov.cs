using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    private Vector2 Direzione;
    private Vector2 Posizione_iniziale;

    void Start()
    {
        Direzione = new Vector2();
        Posizione_iniziale = transform.position;
    }
    void Update()
    {
        // Muovo l'oggetto su e giù, 5f è la velocità di movimento
        transform.Translate(Direzione * 5f * Time.deltaTime);
        if (transform.position.y > Posizione_iniziale.y + 0.2f)
            Direzione = new Vector2(-1f, -1f);
        if (transform.position.y < Posizione_iniziale.y - 0.2f)
            Direzione = new Vector2(-1f, 1f);
    }
}