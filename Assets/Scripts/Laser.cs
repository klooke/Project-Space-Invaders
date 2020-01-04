using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f, damage = 100f;

    public bool isMoving;
    
    void Start()
    {
        isMoving = true;
        Destroy(gameObject, 1f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tag))
        {
            if (collision.CompareTag("Finish"))
            {
                isMoving = false;
            }
            else if (collision.gameObject.layer != 8)
            {                
                isMoving = false;
                collision.GetComponent<ShipStats>().TakeDamage(damage);
            }
        }
    }
    void Update()
    {
        if (isMoving) Engine.Scale(transform, Vector2.up, speed);
    }
}
