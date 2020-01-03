using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    GameObject player;
    public Text pointsTxt;
    public Image lifeImg;
    public float points;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        if (player != null)
        {            
            float life = player.GetComponent<ShipStats>().life;

            Debug.Log("Life: " + life / 100f);
            lifeImg.fillAmount = life / 100f;
            pointsTxt.text = points + " pts";

            LifeIsLower();
        }
        else lifeImg.fillAmount = 0f;
    }
    void LifeIsLower()
    {
        Animator lifeAnimator = lifeImg.GetComponentInParent<Animator>();
        
        if (lifeImg.fillAmount <= 0.3f) lifeAnimator.enabled = true;
        else
        {
            if (lifeAnimator.enabled) lifeAnimator.enabled = false;
        }
    }
}
