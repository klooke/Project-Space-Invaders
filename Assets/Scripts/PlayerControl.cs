using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    const float DELAY_SHOT_MAX = 0.5f;

    public GameObject bulletPrefab;

    Transform shotExitT;
    float timePerShot;

    void Start()
    {
        shotExitT = transform.Find("ShotExit");
    }

    void Update()
    {
        Shot(Input.GetAxis("Fire1"));
        MoveHorizontal(Input.GetAxis("Horizontal"));
    }

    void Shot(float _inputFire)
    {
        timePerShot += Time.deltaTime;

        if (timePerShot >= DELAY_SHOT_MAX)
        {
            if (_inputFire != 0)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = shotExitT.position;
                bullet.transform.rotation = transform.rotation;

                timePerShot = 0f;
            }
        }
    }
    void MoveHorizontal(float _inputH)
    {
        float speed = 3.5f * Time.deltaTime;
        Vector2 playerPos = transform.position;

        if (_inputH > 0)
        {
            if (playerPos.x < 7.5)
            {
                Vector2 dir = new Vector2(_inputH, 0f) * speed;
                transform.Translate(dir);
            }
        }
        else if (_inputH < 0)
        {
            if (playerPos.x > -7.5)
            {
                Vector2 dir = new Vector2(_inputH, 0f) * speed;
                transform.Translate(dir);
            }
        }
    }
}
