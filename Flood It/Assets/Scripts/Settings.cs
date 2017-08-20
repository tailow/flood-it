using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    int boardWidth;
    int boardHeight;

    void Start()
    {
        if (gameObject.GetComponent<Dropdown>() && gameObject.name == "BoardSize")
        {
            GetComponent<Dropdown>().value = 1;

            SetBoardSize();
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
    }
}
