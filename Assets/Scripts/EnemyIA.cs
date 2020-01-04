using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public enum TypeShot { Default, Laser};
        
    public GameObject bulletPrefab;
    public int pointsGiveToPlayer = 10;
    public TypeShot typeBullet;
    public float speedBullet = 5f, damageBullet = 10f, delayShot = 0.75f;
    public AudioClip shotClip;

    bool isCounting;
    Animator anim;
    Transform shotExitT;
    float timePerShot;

    void Start()
    {
        anim = GetComponent<Animator>();
        shotExitT = transform.Find("ShotExit");
        StartCount();
    }

    void Update()
    {
        Attack();
    }

    void StopCount()
    {
        isCounting = false;
    }
    void CountTime()
    {
        if (isCounting)
        {
            timePerShot += Time.deltaTime;
        }
    }
    void Attack()
    {
        CountTime();

        switch (typeBullet)
        {
            default:
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
                break;
            case TypeShot.Laser:
                
                if (timePerShot >= delayShot)
                {
                    anim.SetTrigger("Shot");
                    GetComponent<AudioSource>().clip = shotClip;
                    GetComponent<AudioSource>().Play();

                    Engine.Shot(shotExitT, bulletPrefab, speedBullet, damageBullet);

                    timePerShot = 0f;

                    StopCount();
                }
                break;
        }
    }
    
    public void StartCount()
    {
        isCounting = true;
    }
}
