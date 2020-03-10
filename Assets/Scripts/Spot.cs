using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public Material defaultMat;
    public Material selectedMat;
    public bool selectable;
    Board myBoard;

    private void Start()
    {
        myBoard = GameObject.Find("_Board").GetComponent<Board>();
    }

    public void DeactiveSpot()
    {
        this.GetComponent<Renderer>().material = defaultMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        string currentTag = Board.CURRENTUNIT.tag;
        
        if (other.tag == currentTag)
        {
            for (int i = 0; i < Board.SPOTS.Count; i++)
            {
                Board.SPOTS[i].GetComponent<Spot>().DeactiveSpot();
            }
            this.GetComponent<Renderer>().material = selectedMat;
            Board.CURRENTUNIT.GetComponent<Unit>().SetPosition(new Vector3(this.transform.position.x, 0.5f, this.transform.position.z));
        }

        //if (Board.CURRENTUNIT.tag != other.tag)
        //{
        //    if (other.CompareTag("Black"))
        //    {
        //        if (other.GetComponent<Unit>().name_ == "BK")
        //        {
        //            Debug.Log("Black King is attacked by" + Board.CURRENTUNIT.name);
        //            ChessAI.BKISCHECKED = true;
        //        }
        //        else
        //            ChessAI.BKISCHECKED = false;
        //    }
        //    else if (other.CompareTag("White"))
        //    {
        //        if (other.GetComponent<Unit>().name_ == "WK")
        //        {
        //            Debug.Log("White King is attacked by" + Board.CURRENTUNIT.name);
        //            ChessAI.BKISCHECKED = true;
        //        }
        //    else
        //        ChessAI.BKISCHECKED = false;
        //    }
        //}
    }
}
