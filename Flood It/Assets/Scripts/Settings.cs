using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    int boardWidth;
    int boardHeight;

    int amountOfTurns;

    private void Start()
    {
        gameObject.GetComponent<Dropdown>().value = 1;

        SetBoardSize();
        SetDifficulty();
    }

    public void SetBoardSize()
    {
        if (gameObject.GetComponent<Dropdown>().value == 0)
        {
            boardWidth = 10;
            boardHeight = 10;

            PlayerPrefs.SetInt("boardWidth", boardWidth);
            PlayerPrefs.SetInt("boardHeight", boardHeight);
        }

        else if (gameObject.GetComponent<Dropdown>().value == 1)
        {
            boardWidth = 14;
            boardHeight = 14;

            PlayerPrefs.SetInt("boardWidth", boardWidth);
            PlayerPrefs.SetInt("boardHeight", boardHeight);
        }

        else if (gameObject.GetComponent<Dropdown>().value == 2)
        {
            boardWidth = 20;
            boardHeight = 20;

            PlayerPrefs.SetInt("boardWidth", boardWidth);
            PlayerPrefs.SetInt("boardHeight", boardHeight);
        }

        SetDifficulty();
    }

    public void SetDifficulty()
    {
        if (gameObject.GetComponent<Dropdown>().value == 0)
        {
            amountOfTurns = (boardWidth * boardHeight) / 5;
            Mathf.RoundToInt(amountOfTurns);

            PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);
        }

        else if (gameObject.GetComponent<Dropdown>().value == 1)
        {
            amountOfTurns = (boardWidth * boardHeight) / 10;
            Mathf.RoundToInt(amountOfTurns);

            PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);
        }

        else if (gameObject.GetComponent<Dropdown>().value == 2)
        {
            amountOfTurns = (boardWidth * boardHeight) / 15;
            Mathf.RoundToInt(amountOfTurns);

            PlayerPrefs.SetInt("amountOfTurns", amountOfTurns);
        }
    }
}
