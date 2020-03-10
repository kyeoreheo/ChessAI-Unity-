using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool clickable;
    public int id_;
    public string position_;
    public char col_;
    public int row_;
    public string name_;
    public List<string> strPossiblePaths_ = new List<string>();

    public Vector3 landPosition;

    private Vector3 mOffset;
    private float mZcoord;
    private bool hasClicked_;

    Rigidbody myBody;
    BoxCollider myBox;
    Board myBoard;

    void Start()
    {
        mOffset = new Vector3(0, 0, 0);
        clickable = true;
        name_ = this.name;
        this.name = name_ + "(" + position_ + ")";
        landPosition = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);
        myBody = this.GetComponent<Rigidbody>();
        myBox = this.GetComponent<BoxCollider>();
        myBoard = GameObject.Find("_Board").GetComponent<Board>();
        col_ = position_[0];
        row_ = int.Parse(position_[1].ToString());


        GeneratePath(position_);

    }

    public void GeneratePath(string inputPosition)
    {
        strPossiblePaths_.Clear();
        switch (name[1])
        {
            case 'P':
                {
                    //unit.GetComponent<Rook>().OnMouseUp();
                    break;
                }
            case 'N':
                {
                    //unit.GetComponent<King>().OnMouseUp();
                    //KnightPath();
                    break;
                }
            case 'B':
                {
                    //unit.GetComponent<Pawn>().OnMouseUp();
                    break;
                }
            case 'R':
                {
                    //unit.GetComponent<Knight>().OnMouseUp();
                    break;
                }
            case 'K':
                {
                    //unit.GetComponent<Queen>().OnMouseUp();
                    KingPath(inputPosition);
                    break;
                }
            case 'Q':
                {
                    //unit.GetComponent<Bishop>().OnMouseUp();
                    break;
                }
            default:
                {
                    Debug.Log("Nothing Matched");
                    break;
                }
        }
    }

    void KingPath(string inputPosition)
    {
        char myCol = inputPosition[0];
        int myRow = int.Parse(inputPosition[1].ToString());

        string possiblePath;
        if (name_[0] == 'W')
        {
            possiblePath = (char)(myCol - 1) + (myRow).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol + 1) + (myRow).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol - 1) + (myRow + 1).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol - 1) + (myRow - 1).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol + 1) + (myRow + 1).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol + 1) + (myRow - 1).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol) + (myRow + 1).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol) + (myRow - 1).ToString();
            if (!myBoard.UnitExist(Board.WUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);
        }
        else if (name_[0] == 'B')
        {
            possiblePath = (char)(myCol - 1) + (myRow).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol + 1) + (myRow).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol - 1) + (myRow + 1).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol - 1) + (myRow - 1).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol + 1) + (myRow + 1).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol + 1) + (myRow - 1).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol) + (myRow + 1).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);

            possiblePath = (char)(myCol) + (myRow - 1).ToString();
            if (!myBoard.UnitExist(Board.BUNITS, possiblePath) && myBoard.InBoundary(possiblePath))
                strPossiblePaths_.Add(possiblePath);
        }
        
    }

    public void Setup()
    {

    }
    void Update()
    {
        if (hasClicked_)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }
    public void SetUpUnit(string inputName, string inputPosition, int inputId)
    {
        this.name = inputName;
        position_ = inputPosition;
        id_ = inputId;
    }
    public void SetPosition(Vector3 inputVector3)
    {
        landPosition = inputVector3;
        col_ = (char)(landPosition.x + 97);
        row_ = (int)landPosition.z + 1;
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Board.CURRENTUNIT != null)
        {
            if (collision.gameObject.name == Board.CURRENTUNIT.name)
            {
                collision.gameObject.GetComponent<Unit>().SetPosition(landPosition);
                RemoveUnit();
                Destroy(this.gameObject);
            }
        }
    }

    void RemoveUnit()
    {
        for (int i = 0; i < Board.UNITS.Count; i++)
        {
            if (Board.UNITS[i].name == this.name)
                Board.UNITS.Remove(this.gameObject);
        }
        for (int i = 0; i < Board.WUNITS.Count; i++)
        {
            if (Board.WUNITS[i].name == this.name)
                Board.WUNITS.Remove(this.gameObject);
        }

        for (int i = 0; i < Board.BUNITS.Count; i++)
        {
            if (Board.BUNITS[i].name == this.name)
                Board.BUNITS.Remove(this.gameObject);
        }
    }


    public void PickUnit()//picked
    {
        if (clickable)
        {
            //this.tag = "unit";

            Board.CURRENTUNIT = this.gameObject;

            for (int i = 0; i < Board.UNITS.Count; i++)
            {
                Board.UNITS[i].GetComponent<Unit>().clickable = false;
            }
            hasClicked_ = true;
            myBody.isKinematic = true;
            myBox.isTrigger = true;
            mZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        }
    }


    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZcoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void UnPickUnit()
    {
        for (int i = 0; i < Board.UNITS.Count; i++)
        {
            Board.UNITS[i].GetComponent<Unit>().clickable = true;
        }
        myBody.isKinematic = false;
        myBox.isTrigger = false;
        hasClicked_ = false;
        this.gameObject.transform.position = landPosition;
        position_ = convertPosition((int)landPosition.x, (int)landPosition.z);
        this.name = name_ + "(" + position_ + ")";
        hasClicked_ = false;

        for(int i = 0; i < Board.SPOTS.Count; i++)
        {
            Board.SPOTS[i].GetComponent<Spot>().DeactiveSpot();
        }
        GeneratePath(position_);
    }
    string convertPosition(int first, int second)
    {
        
        return (char)(first+97) + (second+1).ToString(); 
    }
}
