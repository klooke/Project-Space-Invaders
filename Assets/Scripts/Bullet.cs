﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f, damage = 100f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tag))
        {
            if (collision.CompareTag("Finish"))
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.layer != 8)
            {
                collision.GetComponent<ShipStats>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        Engine.Move(transform, Vector2.up, speed);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
