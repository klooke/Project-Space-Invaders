using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [Range(1, 3)] public int level = 2;
    public GameObject shipB, shipC;
    [Range(1,10)] public int maxShipB = 10, maxShipC = 10;
        
    void Start()
    {
        //Debug.Log("Numero de naves: " + maxShipB + "Level: " + level);
        InitLevel();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            if (collision.name == "CubanB(Clone)")
            {
                StartCoroutine(InvokeShip(shipB, maxShipB + 1, collision.GetComponent<Animator>().GetBool("Invert")));
                Destroy(collision.gameObject);
            }
        }
    }

    void InitLevel()
    {
        switch (level)
        {
            case 2:
                for (int i = 0; i < maxShipB; i++)
                {
                    bool invert;

                    if (i % 2 == 0) invert = false;
                    else invert = true;

                    StartCoroutine(InvokeShip(shipB, i, invert));
                }
                break;
            case 3:
                for (int i = 0; i < maxShipB; i++)
                {
                    bool invert;

                    if (i % 2 == 0) invert = false;
                    else invert = true;

                    StartCoroutine(InvokeShip(shipB, i, invert));
                }

                for (int i = 0; i < maxShipC; i++)
                {
                    StartCoroutine(InvokeShip(shipC, i));
                }
                break;
        }
    }

    IEnumerator InvokeShip(GameObject _obj, float _time)
    {
        yield return new WaitForSeconds(_time);

        try
        {
            GameObject tmp = Instantiate(_obj, GameObject.Find("Battlefield").transform);
        }
        catch
        {
            Debug.LogError("Erro ao instanciar o gameobject!");
        }
    }
    IEnumerator InvokeShip(GameObject _obj, float _time, bool _invert)
    {
        yield return new WaitForSeconds(_time);

        try
        {
            GameObject tmp = Instantiate(_obj, GameObject.Find("Battlefield").transform);
            tmp.GetComponent<Animator>().SetBool("Invert", _invert);
        }
        catch
        {
            Debug.LogError("Erro ao instanciar o gameobject!");
        }
    }
}
