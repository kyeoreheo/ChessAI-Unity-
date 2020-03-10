using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public bool white;
    public List<GameObject> possiblePaths = new List<GameObject>();

    //private------------------
    private string position;
    private char col;
    private int row;
    Unit myUnit;
    Board myBoard;

    private void Start()
    {
        myUnit = this.GetComponent<Unit>();
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
        if (white)
        {
            string possiblePath1 = (col).ToString() + (row + 1);
            if (!myBoard.UnitExist(Board.UNITS,possiblePath1)) // if there are no unit 
            {
                myBoard.SpotAt(possiblePath1).SetActive(true); //makes that spot active
                if (myBoard.SpotAt(possiblePath1).name != "Null") // if possiblePath1 is not in board, the name will be Null
                    possiblePaths.Add(myBoard.SpotAt(possiblePath1));
            }

            if (row <= 2)
            { //for the first move only
                string possiblePath2 = (col).ToString() + (row + 2);
                if (!myBoard.UnitExist(Board.UNITS, possiblePath1))
                {
                    myBoard.SpotAt(possiblePath2).SetActive(true);
                    if (myBoard.SpotAt(possiblePath2).name != "Null")
                        possiblePaths.Add(myBoard.SpotAt(possiblePath2));
                }
            }
            string left = (char)(col - 1) + (row + 1).ToString();
            string right = (char)(col + 1) + (row + 1).ToString();

            for (int i = 0; i < Board.BUNITS.Count; i++)
            {
                if (Board.BUNITS[i].GetComponent<Unit>().position_ == left)
                {
                    myBoard.SpotAt(left).SetActive(true);
                    possiblePaths.Add(myBoard.SpotAt(left));
                }
                if (Board.BUNITS[i].GetComponent<Unit>().position_ == right)
                {
                    myBoard.SpotAt(right).SetActive(true);
                    possiblePaths.Add(myBoard.SpotAt(right));
                }
            }
        }
        else //black
        {
            string possiblePath1 = (col).ToString() + (row - 1);
            if (!myBoard.UnitExist(Board.UNITS,possiblePath1)) // if there are no unit 
            {
                myBoard.SpotAt(possiblePath1).SetActive(true); //makes that spot active
                if (myBoard.SpotAt(possiblePath1).name != "Null") // if possiblePath1 is not in board, the name will be Null
                {
                    possiblePaths.Add(myBoard.SpotAt(possiblePath1));
                }
            }

            if (row >= 7)
            { //for the first move only
                string possiblePath2 = (col).ToString() + (row - 2);
                if (!myBoard.UnitExist(Board.UNITS,possiblePath1))
                {
                    myBoard.SpotAt(possiblePath2).SetActive(true);
                    if (myBoard.SpotAt(possiblePath2).name != "Null")
                    {
                        possiblePaths.Add(myBoard.SpotAt(possiblePath2));
                    }
                }
            }

            string left = (char)(col - 1) + (row -1).ToString();
            string right = (char)(col + 1) + (row -1).ToString();

            for (int i = 0; i < Board.WUNITS.Count; i++)
            {
                if (Board.WUNITS[i].GetComponent<Unit>().position_ == left)
                {
                    myBoard.SpotAt(left).SetActive(true);
                    possiblePaths.Add(myBoard.SpotAt(left));
                }
                if (Board.WUNITS[i].GetComponent<Unit>().position_ == right)
                {
                    myBoard.SpotAt(right).SetActive(true);
                    possiblePaths.Add(myBoard.SpotAt(right));
                }
            }
        }
    }

    public void OnMouseDown()
    {
        myUnit.PickUnit();
        highlightPaths();
    }
    public void OnMouseUp()
    {
        for (int i = 0; i < possiblePaths.Count; i++)
        {
            possiblePaths[i].SetActive(false);
        }
        possiblePaths.Clear();
        myUnit.UnPickUnit();

    }
}
