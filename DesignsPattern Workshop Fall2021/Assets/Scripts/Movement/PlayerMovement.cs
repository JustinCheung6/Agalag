using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementStrategy
{

    public override void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}
