using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class And : MonoBehaviour, IOneOutput
{
    public List<GameObject> inputElements;
    public List<LogicalInput> logicalInputs;
    public LogicalOutput _logicalOutput;
    public LogicalOutput logicalOutput
    {
        get { return _logicalOutput; }
        set { _logicalOutput = value; }
    }

    private void Awake()
    {
        logicalInputs = new List<LogicalInput>();
        foreach (GameObject ie in inputElements)
        {
            LogicalInput l = new LogicalInput();
            l.source = (ie.GetComponent(typeof(IOneOutput)) as IOneOutput).logicalOutput; //veryBad, but can't expose interface field in inspector otherwise
            logicalInputs.Add(l);
        }
    }

    //TODO уебать апдейт
    void Update()
    {
        //INSANELY BAD
        foreach (LogicalInput li in logicalInputs)
        {
            li.value = (li.source != null) ? li.source.value : false;
        }


        if (!logicalInputs.Any(a => !a.value))
        {
            logicalOutput.value = true;
        }
        else
        {
            logicalOutput.value = false;
        }
    }
}
