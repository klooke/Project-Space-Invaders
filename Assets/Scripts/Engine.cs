using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine
{
    public const float LIMIT_RIGHT = 7.5f, LIMIT_LEFT = -7.5f;
    public const float INPUT_RIGHT = 1f, INPUT_LEFT = -1f;

    public static void Shot(Transform _t, GameObject _bullet, float _speed)
    {
        GameObject bullet = GameObject.Instantiate(_bullet);
        bullet.transform.position = _t.position;
        bullet.transform.rotation = _t.rotation;
        bullet.GetComponent<Bullet>().speed = _speed;
    }
    public static void Move(Transform _t, Vector2 _dir, float _speed)
    {
        float speed = _speed * Time.deltaTime;
        Vector2 dir = _dir * speed;

        _t.Translate(dir);
    }
}
