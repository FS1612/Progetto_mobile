using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPersonaggi : MonoBehaviour
{
    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private float minY, maxY;

    [SerializeField]
    private float speed;

    private bool isMoving = true;
    private Vector2 targetPosition;

    private Vector2 GetRandomTarget()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Start()
    {
        targetPosition = GetRandomTarget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isMoving = false;
    }

    void Update()
    {
        if (isMoving)
        {
            if ((Vector2)transform.position == targetPosition)
            {
                targetPosition = GetRandomTarget();
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
            }
        }
    }
}
