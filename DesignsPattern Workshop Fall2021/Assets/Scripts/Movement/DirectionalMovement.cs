using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MovementStrategy
{
    [SerializeField] private Vector2 directionMagnitude = new Vector2();
    private Transform parent = null;
    private void Awake()
    {
        parent = transform;
        while (parent.parent != null)
            parent = parent.parent;
    }
    public Vector2 GetDirection() { return directionMagnitude; }
    public void SetDirection(Vector2 direction) { directionMagnitude = direction; }
    public void SwapDirection()
    {
        directionMagnitude.x = -directionMagnitude.x;
        directionMagnitude.y = -directionMagnitude.y;
    }

    public override void Move()
    {
        parent.position += (Vector3)directionMagnitude * speed * Time.fixedDeltaTime;
    }
}
