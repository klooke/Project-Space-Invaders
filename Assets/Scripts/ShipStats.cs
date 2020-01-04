using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public GameObject explosionPrefab;
    public bool godMod;
    public float life = 100f;
    public AudioClip expClip;

    void IsEnemy()
    {
        if (CompareTag("Enemy"))
        {
            GameObject HUD = GameObject.Find("HUD");
            HUD.GetComponent<HUD>().points += GetComponent<EnemyIA>().pointsGiveToPlayer;
        }
    }
    void DestroyWithExplosion()
    {
        GetComponent<AudioSource>().clip = expClip;
        GetComponent<AudioSource>().Play();

        IsEnemy();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;

        try
        {
            foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) sr.enabled = false;
            foreach (CapsuleCollider2D cc2d in GetComponentsInChildren<CapsuleCollider2D>()) cc2d.enabled = false;
        }
        catch { }

        GameObject exp = Instantiate(explosionPrefab);
        exp.transform.position = transform.position;
        exp.transform.rotation = transform.rotation;

        float timeEndExp = exp.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length;
        
        Destroy(exp, timeEndExp);
        Destroy(gameObject, timeEndExp);
    }
    public void TakeDamage(float _value)
    {
        if (godMod) return;

        life -= _value;

        if (life <= 0f) DestroyWithExplosion();
    }
}
