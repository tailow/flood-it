using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int amountOfRectanglesX;
    public int amountOfRectanglesY;
    public int boardWidth = 600;
    public int boardHeight = 600;

    int rectHeight;
    int rectWidth;

    public int amountOfMoves = 10;

    public Transform rectParent;
    public GameObject rectPrefab;

    public GameObject endScreen;
    public Text endScreenText;

    public Text amountOfMovesText;

    public Color currentColor;

    public GameObject[,] rectArray;
    public List<GameObject> currentBlocksList;
    public List<GameObject> currentNeighborsList;

    List<Color> colorList;

    void Start ()
    {
        // Setting rectangle size
        rectWidth = boardWidth / (amountOfRectanglesX - 1);
        rectHeight = boardHeight / (amountOfRectanglesY - 1);

        SpawnRectangles();

        currentBlocksList = new List<GameObject>();
        currentNeighborsList = new List<GameObject>();
        
        GetCurrentBlocks();

        amountOfMovesText.text = amountOfMoves.ToString();
    }

    void SpawnRectangles()
    {
        rectArray = new GameObject[amountOfRectanglesX, amountOfRectanglesY];

        // Spawning rectangles
        for (int y = boardHeight / 2; y > -boardHeight / 2; y -= rectHeight)
        {
            for (int x = -boardWidth / 2; x < boardWidth / 2; x += rectWidth)
            {  
                var rectObj = Instantiate(rectPrefab, new Vector3(x, y, 0), Quaternion.identity);
                rectObj.transform.localScale = new Vector3(rectWidth, rectHeight, 1);
                rectObj.GetComponent<SpriteRenderer>().color = GetRandomColor();
                rectObj.transform.SetParent(rectParent);
            }
        }

        // Making an array out of rectangles
        for (int y = 0; y < amountOfRectanglesY; y++)
        {
            for (int x = 0; x < amountOfRectanglesX; x++)
            {
                rectArray[x, y] = rectParent.GetChild(x + (y * amountOfRectanglesX)).gameObject;
            }
        }
    }

    public void ConnectColors(Color nextColor)
    {
        amountOfMoves--;
        amountOfMovesText.text = amountOfMoves.ToString();

        if (amountOfMoves <= 0)
        {
            endScreenText.text = "You lost.";

            endScreen.SetActive(true);

            foreach (Transform child in GameObject.Find("Buttons").transform)
            {
                child.GetComponent<Button>().interactable = false;
            }
        }

        foreach (GameObject block in currentBlocksList)
        {
            block.GetComponent<SpriteRenderer>().color = nextColor;
        }

        currentColor = nextColor;
        GetCurrentBlocks();

        if (currentBlocksList.Count >= amountOfRectanglesX * amountOfRectanglesY)
        {
            endScreenText.text = "You won!";
            endScreenText.color = Color.green;
            
            endScreen.SetActive(true);

            foreach (Transform child in GameObject.Find("Buttons").transform)
            {
                child.GetComponent<Button>().interactable = false;
            }
        }
    }

    void GetCurrentBlocks()
    {
        currentNeighborsList.Clear();

        currentBlocksList.Clear();

        currentBlocksList.Add(rectArray[0, 0]);

        CheckNeighboringBlocks(0, 0);
    }

    void CheckNeighboringBlocks(int currentBlockX, int currentBlockY)
    {
        currentColor = rectArray[0, 0].GetComponent<SpriteRenderer>().color;

        for (int i = 1; i <= 4; i++)
        {
            if (i == 1 && currentBlockY > 0) // UP
            {
                if (rectArray[currentBlockX, currentBlockY - 1].GetComponent<SpriteRenderer>().color == currentColor) // If same color as currentColor
                {
                    if (!currentBlocksList.Contains(rectArray[currentBlockX, currentBlockY - 1])) // If not already in current block list
                    {
                        currentBlocksList.Add(rectArray[currentBlockX, currentBlockY - 1]);
                        
                        // Check its neighbors
                        CheckNeighboringBlocks(currentBlockX, currentBlockY - 1);
                    }               
                }

                else if (rectArray[currentBlockX, currentBlockY - 1].GetComponent<SpriteRenderer>().color != currentColor) // If different color as currentColor
                {
                    if (!currentNeighborsList.Contains(rectArray[currentBlockX, currentBlockY - 1]))
                    {
                        currentNeighborsList.Add(rectArray[currentBlockX, currentBlockY - 1]);
                    }
                }
            }

            if (i == 1 && currentBlockX < amountOfRectanglesX - 1) // RIGHT
            {
                if (rectArray[currentBlockX + 1, currentBlockY].GetComponent<SpriteRenderer>().color == currentColor) // If same color as currentColor
                {
                    if (!currentBlocksList.Contains(rectArray[currentBlockX + 1, currentBlockY])) // If not already in current block list
                    {
                        currentBlocksList.Add(rectArray[currentBlockX + 1, currentBlockY]);
                        
                        // Check its neighbors
                        CheckNeighboringBlocks(currentBlockX + 1, currentBlockY);
                    }
                }

                else if (rectArray[currentBlockX + 1, currentBlockY].GetComponent<SpriteRenderer>().color != currentColor) // If different color as currentColor
                {
                    if (!currentNeighborsList.Contains(rectArray[currentBlockX + 1, currentBlockY]))
                    {
                        currentNeighborsList.Add(rectArray[currentBlockX + 1, currentBlockY]);
                    }
                }
            }

            if (i == 1 && currentBlockY < amountOfRectanglesY - 1) // DOWN
            {
                if (rectArray[currentBlockX, currentBlockY + 1].GetComponent<SpriteRenderer>().color == currentColor) // If same color as currentColor
                {
                    if (!currentBlocksList.Contains(rectArray[currentBlockX, currentBlockY + 1])) // If not already in current block list
                    {
                        currentBlocksList.Add(rectArray[currentBlockX, currentBlockY + 1]);
                        
                        // Check its neighbors
                        CheckNeighboringBlocks(currentBlockX, currentBlockY + 1);
                    }
                }

                if (rectArray[currentBlockX, currentBlockY + 1].GetComponent<SpriteRenderer>().color != currentColor) // If different color as currentColor
                {
                    if (!currentNeighborsList.Contains(rectArray[currentBlockX, currentBlockY + 1]))
                    {
                        currentNeighborsList.Add(rectArray[currentBlockX, currentBlockY + 1]);
                    }
                }
            }

            if (i == 1 && currentBlockX > 0) // LEFT
            {
                if (rectArray[currentBlockX - 1, currentBlockY].GetComponent<SpriteRenderer>().color == currentColor) // If same color as currentColor
                {
                    if (!currentBlocksList.Contains(rectArray[currentBlockX - 1, currentBlockY])) // If not already in current block list
                    {
                        currentBlocksList.Add(rectArray[currentBlockX - 1, currentBlockY]);

                        // Check its neighbors
                        CheckNeighboringBlocks(currentBlockX - 1, currentBlockY);
                    }
                }

                if (rectArray[currentBlockX - 1, currentBlockY].GetComponent<SpriteRenderer>().color != currentColor) // If different color as currentColor
                {
                    if (!currentNeighborsList.Contains(rectArray[currentBlockX - 1, currentBlockY]))
                    {
                        currentNeighborsList.Add(rectArray[currentBlockX - 1, currentBlockY]);
                    }
                }
            }
        }
    }

    Color GetRandomColor()
    {
        Color randomColor;

        // Initializing color array
        colorList = new List<Color>();

        colorList.Add(Color.red);
        colorList.Add(Color.blue);
        colorList.Add(Color.green);
        colorList.Add(new Color(1, 1, 0, 1));

        randomColor = colorList[Random.Range(0, colorList.Count)];

        return randomColor;
    }
}
