using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    //private------------------
    public string position;
    public char col;
    public int row;
    public bool white;
    public List<GameObject> possiblePaths = new List<GameObject>();
    public List<string> str_possiblePaths = new List<string>();
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
            for (int j = 0; j < Board.SPOTS.Count; j++)
            {
                if (Board.SPOTS[j].name == str_possiblePaths[i])
                {
                    Board.SPOTS[j].SetActive(true);
                    possiblePaths.Add(Board.SPOTS[j]);
                }
            }
        }
    }

    void GeneratePaths()
    {
        string possiblePath;
        int r = row;
        if (white)
        {
            for (char c = col; c < 105; c++) //right up
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> Black
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
                r++;
            }

            r = row;
            for (char c = col; c > 96; c--) //left down
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) //White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> Black
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
                r--;
            }

            r = row;
            for (char c = col; c < 105; c++) //right down
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) // White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        //Debug.Log("Here: " + possiblePath);
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) // White <-> Black
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
                r--;
            }

            r = row;
            for (char c = col; c > 96; c--) //left up
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.WUNITS.Count; i++) // White <-> White
                {
                    if (Board.WUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.WUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.BUNITS.Count; i++) //White <-> Black
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
                r++;

            }
        }
        else
        {
            for (char c = col; c < 105; c++) //right up
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) //Black <-> Black
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //Black <-> White
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
                r++;
            }

            r = row;
            for (char c = col; c > 96; c--) //left down
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) //Black <-> Black
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //Black <-> White
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
                r--;
            }

            r = row;
            for (char c = col; c < 105; c++) //right down
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) // Black <-> Black
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)105;
                        //Debug.Log("Here: " + possiblePath);
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) // Black <-> White
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
                r--;
            }

            r = row;
            for (char c = col; c > 96; c--) //left up
            {
                bool stop = false;
                possiblePath = (char)c + (r).ToString();
                for (int i = 0; i < Board.BUNITS.Count; i++) // Black <-> White
                {
                    if (Board.BUNITS[i].GetComponent<Unit>().position_ == possiblePath && Board.BUNITS[i].GetComponent<Unit>().position_ != position)
                    {
                        c = (char)96;
                        stop = true;
                    }
                }
                for (int i = 0; i < Board.WUNITS.Count; i++) //Black <-> White
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
                r++;
            }
        } 
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
