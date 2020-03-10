using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUnit : MonoBehaviour
{
    // Start is called before the first frame update
    public float inputDegree;
    void Start()
    {
        this.transform.Rotate(Vector3.up*inputDegree);        
    }

}
