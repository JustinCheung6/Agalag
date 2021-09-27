using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MovementStrategy
{
    public enum Direction
    {
        up = 0,
        right = 1,
        down = 2,
        left = 3,

    };

    [SerializeField] private Direction direction;

    public void SetDirection(Direction d)
    {
        direction = d;
    }

    public override void Move()
    {
        Vector3 d = Vector3.zero;

        if (direction == Direction.up)
            d = Vector3.up;
        else if (direction == Direction.right)
            d = Vector3.right;
        else if (direction == Direction.down)
            d = Vector3.down;
        else if (direction == Direction.left)
            d = Vector3.left;

        transform.position += d * speed * Time.fixedDeltaTime;
    }
}
