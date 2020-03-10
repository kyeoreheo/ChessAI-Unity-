using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    //private------------------
    public string position;
    public char col;
    public int row;
    public bool white;
    public List<GameObject> possiblePaths = new List<GameObject>();
    public List<string> str_possiblePaths = new List<string>();

    Board myBoard;
    Unit myUnit;

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
        GeneratePaths();
        for (int i = 0; i < str_possiblePaths.Count; i++)
        {
            myBoard.SpotAt(str_possiblePaths[i]).SetActive(true);
            if (myBoard.SpotAt(str_possiblePaths[i]).name != "Null")
                possiblePaths.Add(myBoard.SpotAt(str_possiblePaths[i]));
        }
    }

    void GeneratePaths()
    {
        string possiblePath;
        if (white)
        {
            for (int r = row; r < 9; r++) //just up
            {
                bool stop = false;
                possiblePath = col + r.ToString();

                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 9;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 9;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }
                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }

            for (int r = row; r > 0; r--) //just Down
            {
                bool stop = false;
                possiblePath = col + r.ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 0;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 0;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }

                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }

            for (int c = col; c <105 ; c++) //just right
            {
                bool stop = false;
                possiblePath = (char)c + row.ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }

                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }

            for (int c = col; c >96; c--) //just left
            {
                bool stop = false;
                possiblePath = (char)c + row.ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }
                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }
        }
        else
        {
            for (int r = row; r < 9; r++) //just up
            {
                bool stop = false;
                possiblePath = col + r.ToString();

                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 9;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 9;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }
                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }

            for (int r = row; r > 0; r--) //just Down
            {
                bool stop = false;
                possiblePath = col + r.ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 0;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        r = 0;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }

                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }

            for (int c = col; c < 105; c++) //just right
            {
                bool stop = false;
                possiblePath = (char)c + row.ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }

                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }

            for (int c = col; c > 96; c--) //just left
            {
                bool stop = false;
                possiblePath = (char)c + row.ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        str_possiblePaths.Add(possiblePath);
                        stop = true;
                    }
                }
                if (possiblePath != position && !stop)
                    str_possiblePaths.Add(possiblePath);
            }
        }
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
