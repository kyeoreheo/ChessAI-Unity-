using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject NULL;

    public Text txtCurrentUnit;
    //public------------------------------------
    public bool DEBUGMODE;
    public static List<GameObject> UNITS = new List<GameObject>();
    public static List<GameObject> SPOTS = new List<GameObject>();
    public static List<GameObject> BUNITS = new List<GameObject>();
    public static List<GameObject> WUNITS = new List<GameObject>();
    public static GameObject CURRENTUNIT;

    //private------------------------------------
    private GameObject spot_;
    private GameObject spotsContainer_;
    private GameObject unitsContainer_;
    private List<string> unitNames_;
    private Hashtable unitTable = new Hashtable();
    //public int currentChessID_;

    public GameObject SpotAt(string inputPosition)
    {
        int leftSpot = inputPosition[0];
        int rightSpot = inputPosition[1];

        if ((leftSpot >=97 && leftSpot <= 104) && (rightSpot >=49 && rightSpot <=56) && inputPosition.Length<3)
        {
            rightSpot = int.Parse(inputPosition[1].ToString());
            int position = octalToDecimal((leftSpot - 97) + (rightSpot - 1) * 10);
            return SPOTS[position];
        }
        else
            return NULL;

    }

    public bool InBoundary(string inputPosition)
    {
        bool result = false;
        int leftSpot = inputPosition[0];
        int rightSpot = inputPosition[1];
        if ((leftSpot >= 97 && leftSpot <= 104) && (rightSpot >= 49 && rightSpot <= 56) && inputPosition.Length < 3)
        {
            result = true;
        }
        return result;
    }

    public bool UnitExist(List<GameObject> inputList ,string inputPosition)
    {
        bool result = false;
        for (int i = 0; i < inputList.Count; i++)
        {
            if (inputPosition == inputList[i].GetComponent<Unit>().position_)
            {
                return true;
            }
        }
        return result;
    }

    int octalToDecimal(int n)
    {
        int num = n;
        int dec_value = 0;
        int b_ase = 1;
        int temp = num;
        while (temp > 0)
        {
            int last_digit = temp % 10;
            temp = temp / 10;
            dec_value += last_digit * b_ase;
            b_ase = b_ase * 8;
        }
        return dec_value;
    }

    void SetUp()
    {
        spot_ = (GameObject)Resources.Load("Spot", typeof(GameObject));
        spotsContainer_ = GameObject.Find("SpotsContainer_");
        unitsContainer_ = GameObject.Find("UnitsContainer_");
        unitNames_ = new List<string> { "BK", "BQ", "BB", "BN", "BP", "BR", "WK", "WQ", "WB", "WN", "WP", "WR" };
    }
    void GenerateTheBoard()
    {
        GameObject tempObj;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tempObj = Instantiate(spot_, this.transform.position, Quaternion.identity);
                tempObj.transform.SetParent(spotsContainer_.transform);
                tempObj.transform.position = new Vector3(j, 0, i);
                tempObj.name = ((char)(j+97)) + (i + 1).ToString();
                SPOTS.Add(tempObj);
                tempObj.SetActive(false);
            }
        }
    }
    void GenerateUinits()
    {
        for (int i = 0; i < unitNames_.Count; i++)
        {
            GameObject tempObj;
            tempObj = (GameObject)Resources.Load(unitNames_[i], typeof(GameObject));
            unitTable.Add(unitNames_[i], tempObj);
        }
    }
    void UnitData(string inputName, string inputPosition, Vector3 inputVector3, int id)
    {
        GameObject tempObj;
        tempObj = Instantiate((GameObject)unitTable[inputName], this.transform.position, Quaternion.identity);
        tempObj.transform.SetParent(unitsContainer_.transform);
        tempObj.transform.position = inputVector3;
        tempObj.GetComponent<Unit>().SetUpUnit(inputName, inputPosition, id);
        UNITS.Add(tempObj);
    }
    void DisplayerUnits()
    {
        //White units---------------------------------------
        UnitData("WK", "e1", new Vector3(4, 2, 0), 0);
        UnitData("WQ", "d1", new Vector3(3, 2, 0), 1);
        UnitData("WB", "c1", new Vector3(2, 2, 0), 2);
        UnitData("WB", "f1", new Vector3(5, 2, 0), 3);
        UnitData("WN", "b1", new Vector3(1, 2, 0), 4);
        UnitData("WN", "g1", new Vector3(6, 2, 0), 5);
        UnitData("WR", "a1", new Vector3(0, 2, 0), 6);
        UnitData("WR", "h1", new Vector3(7, 2, 0), 7);
        for (int i = 0; i < 8; i++)
            UnitData("WP",(char)(i+97)+(2).ToString(),new Vector3(i,2,1),8+i);

        for (int i = 0; i < UNITS.Count; i++)
        {
            WUNITS.Add(UNITS[i]);
        }
        //Black units----------------------------------------------
        UnitData("BK", "e8", new Vector3(4, 2, 7), 16);
        UnitData("BQ", "d8", new Vector3(3, 2, 7), 17);
        UnitData("BB", "c8", new Vector3(2, 2, 7), 18);
        UnitData("BB", "f8", new Vector3(5, 2, 7), 19);
        UnitData("BN", "b8", new Vector3(1, 2, 7), 20);
        UnitData("BN", "g8", new Vector3(6, 2, 7), 21);
        UnitData("BR", "a8", new Vector3(0, 2, 7), 22);
        UnitData("BR", "h8", new Vector3(7, 2, 7), 23);
        for (int i = 0; i < 8; i++)
            UnitData("BP", (char)(i+97)+(7).ToString(), new Vector3(i, 2, 6), 24 + i);

        for (int i = 16; i < UNITS.Count; i++)
        {
            BUNITS.Add(UNITS[i]);
        }

    }

    void Start()
    {
        SetUp();
        GenerateTheBoard();
        GenerateUinits();
        DisplayerUnits();
    }

    public void ReStart()
    {
        UNITS.Clear();
        WUNITS.Clear();
        BUNITS.Clear();

        // SetUp();
        //GenerateTheBoard();
        //GenerateUinits();
        //DisplayerUnits();
        while (unitsContainer_.transform.childCount > 0)
        {
            Transform child = unitsContainer_.transform.GetChild(0);
            child.parent = null;
            Destroy(child.gameObject);
        }
        DisplayerUnits();

    }

    private void Update()
    {
        if(CURRENTUNIT != null)
        txtCurrentUnit.text = CURRENTUNIT.name;
    }
}
