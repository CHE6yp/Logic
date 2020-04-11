using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LogicalInput))]
[RequireComponent(typeof(LogicalOutput))]
public class LogicalElement : MonoBehaviour
{
    public LogicalInput logicalInput;
    public LogicalOutput logicalOutput;

    protected virtual void Awake()
    {
        logicalInput = GetComponent<LogicalInput>();
        logicalOutput = GetComponent<LogicalOutput>();
    }

}
