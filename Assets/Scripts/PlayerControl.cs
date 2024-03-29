﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speedBullet = 5f, damageBullet = 100f, speed = 3.5f, delayShot = 0.5f;
    public AudioClip shotClip;

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
                GetComponent<AudioSource>().clip = shotClip;
                GetComponent<AudioSource>().Play();

                Engine.Shot(shotExitT, bulletPrefab, speedBullet, damageBullet);

                timePerShot = 0f;
            }
        }
    }
    void InputMove()
    {
        float inputH = Input.GetAxis("Horizontal");

        if (inputH > Engine.INPUT_RIGHT)
        {
            if (transform.position.x < Engine.LIMIT_RIGHT)
                Engine.Move(transform, Vector2.right, speed);
        }
        else if (inputH < Engine.INPUT_LEFT)
        {
            if (transform.position.x > Engine.LIMIT_LEFT)
                Engine.Move(transform, Vector2.left, speed);
        }
    }
}
