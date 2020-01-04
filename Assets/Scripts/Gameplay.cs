using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [Range(1, 2)] public int level = 2;
    public GameObject shipB;
    [Range(1,10)] public int maxShipB = 10;
        
    void Start()
    {
        //Debug.Log("Numero de naves: " + maxShipB + "Level: " + level);
        InitLevel();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            StartCoroutine(InvokeShip(shipB, maxShipB + 1, collision.GetComponent<Animator>().GetBool("Invert")));
            Destroy(collision.gameObject);
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
                    Debug.Log("Instanciando nave " + i);
                    if (i == maxShipB) Debug.Log("Ultima nave");
                }
                break;
        }
    }
    IEnumerator InvokeShip(GameObject _obj, float _time, bool _invert)
    {
        //Debug.Log("O inimigo será instanciando em: " + _time + " segundos.");

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
