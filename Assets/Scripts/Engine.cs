using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine
{
    public const float LIMIT_RIGHT = 7.5f, LIMIT_LEFT = -7.5f;
    public const float INPUT_RIGHT = 0.1f, INPUT_LEFT = -0.1f;

    public static bool SeeTarget(Transform _t, string _enemyTag)
    {
        Transform[] eyerT = new Transform[2] { _t.Find("EyerLeft"), _t.Find("EyerRight") };
        RaycastHit2D[] hit = new RaycastHit2D[2] { Physics2D.Raycast(eyerT[0].position, -Vector2.up), Physics2D.Raycast(eyerT[1].position, -Vector2.up) };

        if (hit[0].collider != null)
        {
            if (hit[0].collider.CompareTag(_enemyTag)) return true;
            else return false;
        }

        if (hit[1].collider != null)
        {
            if (hit[1].collider.CompareTag(_enemyTag)) return true;
            else return false;
        }

        return false;
    }
    public static void Shot(Transform _t, GameObject _bullet, float _speed, float _damage)
    {
        var bullet = GameObject.Instantiate(_bullet, _t.position, _t.rotation);
        bullet.tag = _t.parent.tag;
        try
        {
            bullet.GetComponent<Bullet>().speed = _speed;
            bullet.GetComponent<Bullet>().damage = _damage;
        }
        catch
        {
            bullet.transform.SetParent(_t);
            bullet.GetComponent<Laser>().speed = _speed;
            bullet.GetComponent<Laser>().damage = _damage;
        }
    }
    public static void Move(Transform _t, Vector2 _dir, float _speed)
    {
        float speed = _speed * Time.deltaTime;
        Vector2 dir = _dir * speed;

        _t.Translate(dir);
    }
    public static void Scale(Transform _t, Vector2 _dir, float _speed)
    {
        float speed = _speed * Time.deltaTime;
        Vector3 dir = _dir * speed;

        _t.localScale += dir;
    }
}
