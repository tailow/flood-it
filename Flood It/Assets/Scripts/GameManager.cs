using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int amountOfRectanglesX = 10;
    public int amountOfRectanglesY = 10;
    public int boardWidth = 600;
    public int boardHeight = 600;

    int rectHeight;
    int rectWidth;

    public Transform rectParent;
    public GameObject rectPrefab;

    public GameObject[,] rectArray;

    List<Color> colorList;

    void Start ()
    {
        // Setting rectangle size
        rectWidth =  boardWidth / amountOfRectanglesX;
        rectHeight = boardHeight / amountOfRectanglesY;

        SpawnRectangles();
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
                rectArray[x, y] = rectParent.GetChild(x + (y * 10)).gameObject;
            }
        }

    }

    public void ConnectColors(Color nextColor)
    {

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
