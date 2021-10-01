using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MovementStrategy
{
    [Header("Sine Movement")]
    [SerializeField] private Vector3 magnitude = Vector3.right;
    private float randomDeviation = 0f;

    private Vector3 lastPosition = new Vector3();

    private void OnEnable()
    {
        randomDeviation = Random.value * 2 * Mathf.PI;
        lastPosition = new Vector3();
    }
    public override void Move()
    {
        Vector3 newPosition = magnitude * Mathf.Sin(randomDeviation + (Time.fixedTime * speed));

        transform.position += newPosition - lastPosition;
        lastPosition = newPosition;
    }
}
