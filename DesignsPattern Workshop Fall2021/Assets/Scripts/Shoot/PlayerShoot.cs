using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour, ITimeEvent
{
    [Tooltip("Time between bullets in seconds")]
    [SerializeField] private float fireRate = 1f;
    private bool fireCooldown = false;

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire") && !fireCooldown)
        {
            BulletFactory.S.CreateBullet(CollisionBase.collisionGroups.Player, transform.position);
            fireCooldown = true;
            TimeManager.S.AddTimeEvent(this, fireRate);
        }
    }
    public void Activate(int id)
    {
        fireCooldown = false;
    }
}
