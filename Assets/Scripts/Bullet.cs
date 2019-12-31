using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tag)) Destroy(gameObject);
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
