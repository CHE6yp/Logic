using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LogicalInput))]
[RequireComponent(typeof(LogicalOutput))]
public class And : MonoBehaviour
{
    public LogicalInput logicalInput;
    public LogicalOutput logicalOutput;


    // Update is called once per frame
    void Update()
    {
        
    }
}
