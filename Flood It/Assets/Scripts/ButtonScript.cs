using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    GameManager gameManager;

    public GameObject difficultyScreen;

    int amountOfTurns;

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

    public void ChooseDifficulty()
    {
        difficultyScreen.SetActive(true);
    }

    public void CancelStart()
    {
        difficultyScreen.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("scene_main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("scene_menu");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("scene_menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("scene_settings");
    }

    public void EasyDifficulty()
    {
        if (PlayerPrefs.GetInt("boardWidth") == 10)
        {
            amountOfTurns = 15;
        }

        else if (PlayerPrefs.GetInt("boardWidth") == 14)
        {
            amountOfTurns = 20;
        }

        else if (PlayerPrefs.GetInt("boardWidth") == 20)
        {
            amountOfTurns = 30;
        }

        else
        {
            PlayerPrefs.SetInt("boardWidth", 14);
            PlayerPrefs.SetInt("boardHeight", 14);

            amountOfTurns = 20;
        }

        Mathf.RoundToInt(amountOfTurns);

        PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);

        SceneManager.LoadScene("scene_main");
    }

    public void MediumDifficulty()
    {
        if (PlayerPrefs.GetInt("boardWidth") == 10)
        {
            amountOfTurns = 13;
        }

        else if (PlayerPrefs.GetInt("boardWidth") == 14)
        {
            amountOfTurns = 17;
        }

        else if (PlayerPrefs.GetInt("boardWidth") == 20)
        {
            amountOfTurns = 25;
        }

        else
        {
            PlayerPrefs.SetInt("boardWidth", 14);
            PlayerPrefs.SetInt("boardHeight", 14);

            amountOfTurns = 17;
        }

        Mathf.RoundToInt(amountOfTurns);

        PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);

        SceneManager.LoadScene("scene_main");
    }

    public void HardDifficulty()
    {
        if (PlayerPrefs.GetInt("boardWidth") == 10)
        {
            amountOfTurns = 10;
        }

        else if (PlayerPrefs.GetInt("boardWidth") == 14)
        {
            amountOfTurns = 14;
        }

        else if (PlayerPrefs.GetInt("boardWidth") == 20)
        {
            amountOfTurns = 20;
        }

        else
        {
            PlayerPrefs.SetInt("boardWidth", 14);
            PlayerPrefs.SetInt("boardHeight", 14);

            amountOfTurns = 14;
        }

        Mathf.RoundToInt(amountOfTurns);

        PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);

        SceneManager.LoadScene("scene_main");
    }
}
