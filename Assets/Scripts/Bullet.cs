using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        Engine.Move(transform, Vector2.up, speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
