using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    //private------------------
    public bool white;
    public string position;
    public char col;
    public int row;
    public List<GameObject> possiblePaths = new List<GameObject>();
    public List<string> str_possiblePaths = new List<string>();
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
    //public void SetPosition(string inputPosition)
    //{
    //    position = inputPosition;
    //    col = position[0];
    //    row = int.Parse(position[1].ToString());
    //}
    void highlightPaths()
    {
        GeneratePaths();
        //for (int i = 0; i < str_possiblePaths.Count; i++)
        //{
        for (int j = 0; j < str_possiblePaths.Count; j++)
        {
            myBoard.SpotAt(str_possiblePaths[j]).SetActive(true);
            if (myBoard.SpotAt(str_possiblePaths[j]).name != "Null")
                possiblePaths.Add(myBoard.SpotAt(str_possiblePaths[j]));
        }
        //}


        if (white)
        {
            bool found = false;
            for (int i = 0; i < possiblePaths.Count;)
            {
                found = false;
                for (int j = 0; j < Board.WUNITS.Count; j++)
                {
                    if (possiblePaths.Count > 0 && possiblePaths[i].name == Board.WUNITS[j].GetComponent<Unit>().position_)
                    {//possiblePaths.Count>0 && <- deleted. 
                        possiblePaths[i].SetActive(false);
                        possiblePaths.Remove(possiblePaths[i]);
                        found = true;
                        i = 0;
                    }
                }
                if (!found)
                    i++;
            }
        }
        else
        {
            bool found = false;
            for (int i = 0; i < possiblePaths.Count;)
            {
                found = false;
                for (int j = 0; j < Board.BUNITS.Count; j++)
                {
                    if (possiblePaths.Count > 0 && possiblePaths[i].name == Board.BUNITS[j].GetComponent<Unit>().position_)
                    {//possiblePaths.Count>0 && <- deleted. 
                        possiblePaths[i].SetActive(false);
                        possiblePaths.Remove(possiblePaths[i]);
                        found = true;
                        i = 0;
                    }
                }
                if (!found)
                    i++;
            }

        }
    }
    void GeneratePaths()
    {
        string possiblePath;
        possiblePath = (char)(col) + (row + 1).ToString();
        str_possiblePaths.Add(possiblePath); //up
        possiblePath = (char)(col - 1) + (row + 1).ToString();
        str_possiblePaths.Add(possiblePath); //lef up
        possiblePath = (char)(col - 1) + (row).ToString();
        str_possiblePaths.Add(possiblePath); // left
        possiblePath = (char)(col - 1) + (row - 1).ToString();
        str_possiblePaths.Add(possiblePath); //left down
        possiblePath = (char)(col) + (row - 1).ToString();
        str_possiblePaths.Add(possiblePath); // down
        possiblePath = (char)(col + 1) + (row - 1).ToString();
        str_possiblePaths.Add(possiblePath); //right down
        possiblePath = (char)(col + 1) + (row).ToString();
        str_possiblePaths.Add(possiblePath); // right

        possiblePath = (char)(col + 1) + (row + 1).ToString();
        str_possiblePaths.Add(possiblePath); //right up






    }
    public void OnMouseDown()
    {
        highlightPaths();
        myUnit.PickUnit();

    }
    public void OnMouseUp()
    {
        for (int i = 0; i < possiblePaths.Count; i++)
        {
            possiblePaths[i].SetActive(false);
        }
        possiblePaths.Clear();
        str_possiblePaths.Clear();
        myUnit.UnPickUnit();

    }
}
