using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    int boardWidth;
    int boardHeight;

    int amountOfTurns;

    int easyDifficulty = 5;
    int mediumDifficulty = 10;
    int hardDifficulty = 15;

    void Start()
    {
        // Setting dropdown values to default
        if (SceneManager.GetActiveScene().name == "scene_settings")
        {
            gameObject.GetComponent<Dropdown>().value = 1;
        }
    }

    public void SetBoardSize()
    {
        if (gameObject.GetComponent<Dropdown>().value == 0)
        {
            boardWidth = 10;
            boardHeight = 10;

            PlayerPrefs.SetInt("boardWidth", boardWidth);
            PlayerPrefs.SetInt("boardHeight", boardHeight);

            SetDifficulty();
        }

        else if (gameObject.GetComponent<Dropdown>().value == 1)
        {
            boardWidth = 14;
            boardHeight = 14;

            PlayerPrefs.SetInt("boardWidth", boardWidth);
            PlayerPrefs.SetInt("boardHeight", boardHeight);

            SetDifficulty();
        }

        else if (gameObject.GetComponent<Dropdown>().value == 2)
        {
            boardWidth = 20;
            boardHeight = 20;

            PlayerPrefs.SetInt("boardWidth", boardWidth);
            PlayerPrefs.SetInt("boardHeight", boardHeight);

            SetDifficulty();
        }
    }

    public void SetDifficulty()
    {
        if (gameObject.GetComponent<Dropdown>().value == 0)
        {
            amountOfTurns = (boardWidth * boardHeight) / easyDifficulty;
            Mathf.RoundToInt(amountOfTurns);

            PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);
        }

        else if (gameObject.GetComponent<Dropdown>().value == 1)
        {
            amountOfTurns = (boardWidth * boardHeight) / mediumDifficulty;
            Mathf.RoundToInt(amountOfTurns);

            PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);
        }

        else if (gameObject.GetComponent<Dropdown>().value == 2)
        {
            amountOfTurns = (boardWidth * boardHeight) / hardDifficulty;
            Mathf.RoundToInt(amountOfTurns);

            PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);
        }
    }
}
