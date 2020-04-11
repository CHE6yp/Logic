using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LogicalOutput))]
public class Battery : MonoBehaviour
{
    public LogicalOutput logicalOutput;

    // Start is called before the first frame update
    void Start()
    {
        logicalOutput = GetComponent<LogicalOutput>();
        logicalOutput.value = true;
    }

}
