using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speedBullet = 5f, speed = 3.5f, delayShot = 0.5f;

    Transform shotExitT;
    float timePerShot;

    void Start()
    {
        shotExitT = transform.Find("ShotExit");
    }

    void Update()
    {
        InputShot();
        InputMove();
    }

    void InputShot()
    {
        float inputFire = Input.GetAxis("Fire1");

        timePerShot += Time.deltaTime;

        if (timePerShot >= delayShot)
        {
            if (inputFire != 0)
            {
                Engine.Shot(shotExitT, bulletPrefab, speedBullet);

                timePerShot = 0f;
            }
        }
    }
    void InputMove()
    {
        float inputH = Input.GetAxis("Horizontal");

        switch (inputH)
        {
            case Engine.INPUT_RIGHT:

                if (transform.position.x < Engine.LIMIT_RIGHT)
                    Engine.Move(transform, Vector2.right, speed);

                break;
            case Engine.INPUT_LEFT:

                if (transform.position.x > Engine.LIMIT_LEFT)
                    Engine.Move(transform, Vector2.left, speed);

                break;
        }
    }
}
