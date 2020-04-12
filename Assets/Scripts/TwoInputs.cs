using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwoInputs : MonoBehaviour, IOneOutput
{
    public GameObject inputElement1;
    public GameObject inputElement2;
    public LogicalInput logicalInput1;
    public LogicalInput logicalInput2;

    public LogicalOutput _logicalOutput;
    public LogicalOutput logicalOutput
    {
        get { return _logicalOutput; }
        set { _logicalOutput = value; }
    }

    private void Awake()
    {
        //veryBad, but can't expose interface field in inspector otherwise
        if (inputElement1 != null)
            logicalInput1.source = (inputElement1.GetComponent(typeof(IOneOutput)) as IOneOutput).logicalOutput;
        if (inputElement2 != null)
            logicalInput2.source = (inputElement2.GetComponent(typeof(IOneOutput)) as IOneOutput).logicalOutput; 

    }

    //TODO уебать апдейт
    void Update()
    {
        //INSANELY BAD
        logicalInput1.value = (logicalInput1.source != null) ? logicalInput1.source.value : false;
        logicalInput2.value = (logicalInput2.source != null) ? logicalInput2.source.value : false;

        if (Strategy())
        {
            logicalOutput.value = true;
        }
        else
        {
            logicalOutput.value = false;
        }
    }

    public abstract bool Strategy();
}
