using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    GameObject player;
    public GameObject pauseMenu, messagePopup;
    public bool pause;
    public Text pointsTxt;
    public Image lifeImg;
    public float points;
    public AudioClip warningClip;

    float msgPopupTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ContinueGame();
    }
    void Update()
    {
        InputHUD();
        UpdateHUD();
        IsWin();
    }

    void InputHUD()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause) ContinueGame();
            else PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (player.GetComponent<ShipStats>().godMod)
            {
                msgPopupTime = 0f;
                messagePopup.SetActive(true);
                messagePopup.GetComponent<Text>().text = "Modo deus desativado!";
                
                player.GetComponent<ShipStats>().godMod = false;
            }
            else
            {
                msgPopupTime = 0f;
                messagePopup.SetActive(true);
                messagePopup.GetComponent<Text>().text = "Modo deus ativado!";

                player.GetComponent<ShipStats>().godMod = true;
            }
        }
    }    
    void UpdateHUD()
    {
        if (messagePopup.activeSelf)
        {
            msgPopupTime += Time.deltaTime;

            if (msgPopupTime >= 1f)
            {
                messagePopup.SetActive(false);
                msgPopupTime = 0f;
            }
        }

        if (player != null)
        {
            float life = player.GetComponent<ShipStats>().life;

            Debug.Log("Life: " + life / 100f);
            lifeImg.fillAmount = life / 100f;
            pointsTxt.text = points + " pts";

            LifeIsLower();
        }
        else
        {
            lifeImg.fillAmount = 0f;
            GamerOver();
        }
    }
    void IsWin()
    {
        if (GameObject.Find("Battlefield").transform.childCount <= 0) YouWin();
    }
    void LifeIsLower()
    {
        Animator lifeAnimator = lifeImg.GetComponentInParent<Animator>();

        if (lifeImg.fillAmount <= 0.3f)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().clip = warningClip;
                GetComponent<AudioSource>().Play();
            }

            lifeAnimator.enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            if (lifeAnimator.enabled) lifeAnimator.enabled = false;
        }
    }
    void GamerOver()
    {
        PauseGame();
        pauseMenu.transform.Find("Status").GetComponent<Text>().text = "GAME OVER!";
        pauseMenu.transform.Find("Status").GetComponent<Text>().color = Color.red;
        pauseMenu.transform.Find("Resume").gameObject.SetActive(false);
        pauseMenu.transform.Find("Restart").gameObject.SetActive(true);
    }
    void YouWin()
    {
        PauseGame();
        pauseMenu.transform.Find("Status").GetComponent<Text>().text = "VOCÊ VENCEU!";
        pauseMenu.transform.Find("Status").GetComponent<Text>().color = Color.green;
        pauseMenu.transform.Find("Resume").gameObject.SetActive(false);
        pauseMenu.transform.Find("NextLevel").gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pause = true;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pause = false;
    }
    public void CloseGame()
    {
        if (Application.isEditor) UnityEditor.EditorApplication.isPlaying = false;
        else Application.Quit();
    }
}
