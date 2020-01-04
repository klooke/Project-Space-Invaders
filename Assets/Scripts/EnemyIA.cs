﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int pointsGiveToPlayer = 10;
    public float speedBullet = 5f, damageBullet = 10f, delayShot = 0.75f;
    public AudioClip shotClip;

    Animator anim;
    Transform shotExitT;
    float timePerShot;

    void Start()
    {
        anim = GetComponent<Animator>();
        shotExitT = transform.Find("ShotExit");
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        timePerShot += Time.deltaTime;

        if (Engine.SeeTarget(transform, "Player"))
        {
            if (timePerShot >= delayShot)
            {
                anim.SetTrigger("Shot");
                GetComponent<AudioSource>().clip = shotClip;
                GetComponent<AudioSource>().Play();

                Engine.Shot(shotExitT, bulletPrefab, speedBullet, damageBullet);

                timePerShot = 0f;
            }
        }
    }
}
