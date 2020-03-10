using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ChessAI : MonoBehaviour
{
    public GameObject unit;
    public List<GameObject> possiblePaths = new List<GameObject>();
    public string position;
    public char c;
    public int p;

    public GameObject WHITEKING;
    public GameObject BLACKKING;
    public static bool WKISCHEKCED;
    public static bool BKISCHECKED;

    private string gameLog;
    public Text txtTurn;
    private int turn;
    public int inputTurn;
    public float delay;
    private bool gameDone;


    Unit currentUnit;
    Board myBoard;
    private void Start()
    {
        gameDone = false;
        myBoard = GameObject.Find("_Board").GetComponent<Board>();
        WKISCHEKCED = false;
        BKISCHECKED = false;
        turn = 0;
    }
    void SetKings()
    {
        for (int i = 0; i < Board.WUNITS.Count; i++)
        {
            if (Board.WUNITS[i].GetComponent<Unit>().name_ == "WK")
                WHITEKING = Board.WUNITS[i];
        }
        for (int i = 0; i < Board.BUNITS.Count; i++)
        {
            if (Board.BUNITS[i].GetComponent<Unit>().name_ == "BK")
                BLACKKING = Board.BUNITS[i];
        }
    }
    public void GenerateRandomGame()
    {
        turn = 0;
        StartCoroutine(AI());
    }

    private void Update()
    {
        txtTurn.text = turn.ToString();
        if (turn >= inputTurn || gameDone)
        {
            gameDone = false;
            GenerateRandomGame();
        }
    }

    void CreateText()
    {
        gameLog += "\n";
        string path = Application.dataPath + "/chessLog.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path,gameLog);
        }
        File.AppendAllText(path, gameLog);
    }

    IEnumerator AI()
    { //problem at BN
        myBoard.ReStart();
        yield return new WaitForSeconds(0.5f);
        SetKings();
        string unitName;
        string unitPosition1;
        string unitPosition2;
        string whiteMove;
        string blackMove;
        string resultMove;
        yield return new WaitForSeconds(delay);
        while (turn < inputTurn && WHITEKING != null && BLACKKING != null)
        {
            //yield return new WaitForSeconds(delay);

            //-------WHITE-----------------------------//
            while (p <= 0)
            {
                possiblePaths.Clear();
                yield return new WaitForSeconds(delay);
                ChooseWhiteUnit(); //choose a random unit
                yield return new WaitForSeconds(delay);
                if (unit != null)
                {
                    MouseDownUnit(); //unit.MouseDown
                    if (p <= 0)
                        MouseUpUnit();
                }
            }
            //-------Picked a unit -------
            currentUnit = Board.CURRENTUNIT.GetComponent<Unit>();
            unitName = currentUnit.name_;
            unitPosition1 = currentUnit.position_;
            yield return new WaitForSeconds(delay);
            //-------Place a unit in possible paths
            PlaceUnit();
            yield return new WaitForSeconds(delay);
            MouseUpUnit();
            unitPosition2 = currentUnit.position_;
            whiteMove = unitName + "(" + unitPosition1 + "->" + unitPosition2 + ")";

            p = 0;
            while (p <= 0)
            {
                possiblePaths.Clear();
                yield return new WaitForSeconds(delay);
                ChooseBlackUnit(); //choose a random unit
                yield return new WaitForSeconds(delay);
                if (unit != null)//---------added
                {
                    MouseDownUnit(); //unit.MouseDown
                    if (p <= 0)
                        MouseUpUnit();
                }
            }
            currentUnit = Board.CURRENTUNIT.GetComponent<Unit>();
            unitName = currentUnit.name_;
            unitPosition1 = currentUnit.position_;


            yield return new WaitForSeconds(delay);
            PlaceUnit();
            yield return new WaitForSeconds(delay);
            MouseUpUnit();
            unitPosition2 = currentUnit.position_;
            blackMove = unitName + "(" + unitPosition1 + "->" + unitPosition2 + ")";

            resultMove = turn.ToString() + ": "+ whiteMove + " " + blackMove + "|";
            gameLog += resultMove;
            turn++;

            p = 0;
        }

        if (WHITEKING == null)
        {
            gameLog += "-Black Won";
        }
        if (BLACKKING == null)
        {
            gameLog += "-White Won";
        }
        CreateText();

        if (WHITEKING == null || BLACKKING == null)
        {
            gameDone = true;
        }
    }
    public void BtnNoDelay()
    {
        turn = 0;
        myBoard.ReStart();
        StartCoroutine(NoDelay());
    }

    IEnumerator NoDelay()
    { //problem at BN
        yield return new WaitForSeconds(0.05f);
        //SetKings();

        string unitName;
        string unitPosition1;
        string unitPosition2;
        string whiteMove;
        string blackMove;
        string resultMove;
        while (turn < inputTurn && !WKISCHEKCED && !BKISCHECKED)
        {
            Debug.Log(turn);
            //-------WHITE-----------------------------//
            while (p <= 0)
            {
                possiblePaths.Clear();
                ChooseWhiteUnit(); //choose a random unit
                MouseDownUnit(); //unit.MouseDown
                if (p <= 0)
                    MouseUpUnit();
            }
            //-------Picked a unit -------

            currentUnit = Board.CURRENTUNIT.GetComponent<Unit>();

            unitName = currentUnit.name_;
            unitPosition1 = currentUnit.position_;
            PlaceUnit();
            MouseUpUnit();
            unitPosition2 = currentUnit.position_;
            whiteMove = unitName + "(" + unitPosition1 + "->" + unitPosition2 + ")";
            p = 0;
            while (p <= 0)
            {
                possiblePaths.Clear();
                ChooseBlackUnit(); //choose a random unit
                MouseDownUnit(); //unit.MouseDown
                if (p <= 0)
                    MouseUpUnit();
            }
            currentUnit = Board.CURRENTUNIT.GetComponent<Unit>();
            unitName = currentUnit.name_;
            unitPosition1 = currentUnit.position_;
            PlaceUnit();
            MouseUpUnit();
            unitPosition2 = currentUnit.position_;
            blackMove = unitName + "(" + unitPosition1 + "->" + unitPosition2 + ")";
            resultMove = turn.ToString() + ": " + whiteMove + " " + blackMove + "|";
            gameLog += resultMove;
            turn++;
            p = 0;
        }
        CreateText();
    }

    void ChooseWhiteUnit()
    {
        //if (unit != null) 
        //    Debug.Log("chooseWhite, current: " + unit.name);
        int randomInt = Random.Range(0, Board.WUNITS.Count);
        unit = Board.WUNITS[randomInt];
        c = unit.name[1];
        //Debug.Log("unit=Board.WUNITES[" + randomInt + "]: " + unit.name + ", WUcount : " + Board.WUNITS.Count);
    }
    void ChooseBlackUnit()
    {
        //if (unit != null)
        //    Debug.Log("chooseWhite, current: " + unit.name);
        int randomInt = Random.Range(0, Board.BUNITS.Count);
        unit = Board.BUNITS[randomInt];
        c = unit.name[1];
       //Debug.Log("unit=Board.BUNITES[" + randomInt + "]: " + unit.name + ", BUcount : " + Board.WUNITS.Count);

    }
    void MouseUpUnit()
    {
        switch (c)
        {
            case 'R':
                {
                    unit.GetComponent<Rook>().OnMouseUp();
                    break;
                }
            case 'K':
                {
                    unit.GetComponent<King>().OnMouseUp();
                    break;
                }
            case 'P':
                {
                    unit.GetComponent<Pawn>().OnMouseUp();
                    break;
                }
            case 'N':
                {
                    unit.GetComponent<Knight>().OnMouseUp();
                    break;
                }
            case 'Q':
                {
                    unit.GetComponent<Queen>().OnMouseUp();
                    break;
                }
            case 'B':
                {
                    unit.GetComponent<Bishop>().OnMouseUp();
                    break;
                }
            default:
                {
                    Debug.Log("Nothing Matched");
                    break;
                }
        }
    }
    void MouseDownUnit()
    {
        switch (c)
        {
            case 'R':
                {
                    unit.GetComponent<Rook>().OnMouseDown();
                    if(unit.GetComponent<Rook>().possiblePaths.Count>0)
                        possiblePaths = unit.GetComponent<Rook>().possiblePaths;
                    break;
                }
            case 'K':
                {
                    unit.GetComponent<King>().OnMouseDown();
                    if (unit.GetComponent<King>().possiblePaths.Count > 0)
                        possiblePaths = unit.GetComponent<King>().possiblePaths;
                    break;
                }
            case 'P':
                {
                    unit.GetComponent<Pawn>().OnMouseDown();
                    if (unit.GetComponent<Pawn>().possiblePaths.Count > 0)
                        possiblePaths = unit.GetComponent<Pawn>().possiblePaths;
                    break;
                }
            case 'N':
                {
                    unit.GetComponent<Knight>().OnMouseDown();
                    if (unit.GetComponent<Knight>().possiblePaths.Count > 0)
                        possiblePaths = unit.GetComponent<Knight>().possiblePaths;
                    break;
                }
            case 'Q':
                {
                    unit.GetComponent<Queen>().OnMouseDown();
                    if (unit.GetComponent<Queen>().possiblePaths.Count > 0)
                        possiblePaths = unit.GetComponent<Queen>().possiblePaths;
                    break;
                }
            case 'B':
                {
                    unit.GetComponent<Bishop>().OnMouseDown();
                    if (unit.GetComponent<Bishop>().possiblePaths.Count > 0)
                        possiblePaths = unit.GetComponent<Bishop>().possiblePaths;
                    break;
                }
            default:
                {
                    Debug.Log("Nothing Matched");
                    break;
                }

        }
        p = possiblePaths.Count;
    }
    void PlaceUnit()
    {
        int randomNumber = Random.Range(0, possiblePaths.Count);
        unit.GetComponent<Unit>().SetPosition(possiblePaths[randomNumber].transform.position);
    }
}
