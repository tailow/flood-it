using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    GameManager gameManager;

    void Start()
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
        PlayerPrefs.SetInt("boardWidth", 14);
        PlayerPrefs.SetInt("boardHeight", 14);

        PlayerPrefs.SetInt("amountOfTurns", 19);

        SceneManager.LoadScene("scene_menu");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("scene_menu");
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();

        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("scene_settings");
    }
}
