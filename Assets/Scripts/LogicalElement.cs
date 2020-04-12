using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalElement : MonoBehaviour
{
    public LogicalElement inputElement;
    public LogicalInput logicalInput;
    public LogicalOutput logicalOutput;

    protected virtual void Awake()
    {
        if (inputElement!=null)
            logicalInput.source = inputElement.logicalOutput;
    }


    //TODO избавиться от апдейта
    protected virtual void Update()
    {
        logicalInput.value = (logicalInput.source != null) ? logicalInput.source.value : false;
    }

}
