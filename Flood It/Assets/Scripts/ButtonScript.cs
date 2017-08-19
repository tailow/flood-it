using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    GameManager gameManager;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "scene_main")
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }   
    }

    public void ButtonIsPressed()
    {
        GetComponent<Button>().interactable = false;

        foreach (Transform sibling in transform.parent)
        {
            if (sibling != transform)
            {
                sibling.gameObject.GetComponent<Button>().interactable = true;
            }
        }

        gameManager.ConnectColors(GetComponent<Image>().color);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("scene_main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("scene_menu");

        PlayerPrefs.DeleteAll();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("scene_settings");
    }
}
