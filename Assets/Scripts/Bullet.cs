using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        MoveVertical();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void MoveVertical()
    {
        float speed = 5f * Time.deltaTime;
        Vector2 dir = Vector2.up * speed;

        transform.Translate(dir);        
    }
}
