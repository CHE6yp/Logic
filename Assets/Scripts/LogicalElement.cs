using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalElement : MonoBehaviour, IOneOutput
{
    //public IOneOutput inputElement;
    public GameObject inputElement; //bad
    public LogicalInput logicalInput;
    public LogicalOutput _logicalOutput;
    public LogicalOutput logicalOutput {
        get { return _logicalOutput; }
        set { _logicalOutput = value; }
    }

    protected virtual void Awake()
    {
        if (inputElement!=null)
            //logicalInput.source = inputElement.logicalOutput;
            logicalInput.source = (inputElement.GetComponent(typeof(IOneOutput)) as IOneOutput).logicalOutput; //veryBad, but can't expose interface field in inspector otherwise
    }


    //TODO избавиться от апдейта
    protected virtual void Update()
    {
        logicalInput.value = (logicalInput.source != null) ? logicalInput.source.value : false;
    }

}
