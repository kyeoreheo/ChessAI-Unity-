using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public bool white;
    public string position;
    public char col;
    public int row;
    public List<GameObject> possiblePaths = new List<GameObject>();
    public List<string> str_possiblePaths = new List<string>();
    Board myBoard;

    private void Start()
    {
        myBoard = GameObject.Find("_Board").GetComponent<Board>();
    }

    void Update()
    {
        position = this.GetComponent<Unit>().position_;
        col = position[0];
        row = int.Parse(position[1].ToString());
    }

    public void SetPosition(string inputPosition)
    {
        position = inputPosition;
        col = position[0];
        row = int.Parse(position[1].ToString());
    }

    void highlightPaths()
    {
        GeneratePaths();

        for (int i = 0; i < str_possiblePaths.Count; i++)
        {
            if (myBoard.SpotAt(str_possiblePaths[i]).name != "Null")
            {
                if(white &&!myBoard.UnitExist(Board.WUNITS,str_possiblePaths[i]))
                    possiblePaths.Add(myBoard.SpotAt(str_possiblePaths[i]));

                else if (!white && !myBoard.UnitExist(Board.BUNITS, str_possiblePaths[i]))
                    possiblePaths.Add(myBoard.SpotAt(str_possiblePaths[i]));
            }
        }

        for (int i = 0; i < possiblePaths.Count; i++)
            possiblePaths[i].SetActive(true);
    }

    void GeneratePaths()
    {
        string possiblePath;

        possiblePath = (char)(col - 1) + (row + 2).ToString();
        str_possiblePaths.Add(possiblePath); //up left

        possiblePath = (char)(col + 1) + (row + 2).ToString();
        str_possiblePaths.Add(possiblePath); // up right

        possiblePath = (char)(col - 1) + (row - 2).ToString();
        str_possiblePaths.Add(possiblePath); //down left

        possiblePath = (char)(col + 1) + (row - 2).ToString();
        str_possiblePaths.Add(possiblePath); //down right

        possiblePath = (char)(col - 2) + (row + 1).ToString();
        str_possiblePaths.Add(possiblePath); //left up

        possiblePath = (char)(col - 2) + (row - 1).ToString();
        str_possiblePaths.Add(possiblePath); //left down

        possiblePath = (char)(col + 2) + (row + 1).ToString();
        str_possiblePaths.Add(possiblePath); //right up

        possiblePath = (char)(col + 2) + (row - 1).ToString();
        str_possiblePaths.Add(possiblePath); //right down
    }

    public void OnMouseDown()
    {
        highlightPaths();
        this.GetComponent<Unit>().PickUnit();

    }
    public void OnMouseUp()
    {
        for (int i = 0; i < possiblePaths.Count; i++)
        {
            possiblePaths[i].SetActive(false);
        }
        possiblePaths.Clear();
        str_possiblePaths.Clear();
        this.GetComponent<Unit>().UnPickUnit();

    }
}
