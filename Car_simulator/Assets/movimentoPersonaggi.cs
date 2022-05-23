using UnityEngine;
using System.Collections;
public class MovimentoPersonaggi : MonoBehaviour
{
    float speed = 4.0f;
    GameObject player;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            if (collision.rigidbody.name == "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Start()
    {
        GameObject _p = GameObject.Find("Player");
        if (_p != null)
        {
            player = _p;
        }
    }
    void Update()
    {
        Vector3 moveVector = Vector3.left;
        transform.position += moveVector * speed * Time.deltaTime;
        if (player != null)
        {
            if (this.transform.position.x <= player.transform.position.x - 10.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}