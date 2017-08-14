using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
}
