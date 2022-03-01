using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visuale_auto : MonoBehaviour

{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float velocitacamera;
    [SerializeField] private float velocitarotazione;
    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        var targetposition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetposition, velocitacamera * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, velocitarotazione * Time.deltaTime);
    }
}
