using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Or : MonoBehaviour, IOneOutput
{
    public List<IOneOutput> inputElements;
    public List<LogicalInput> logicalInputs;
    public LogicalOutput _logicalOutput;
    public LogicalOutput logicalOutput
    {
        get { return _logicalOutput; }
        set { _logicalOutput = value; }
    }
    
    //TODO избавиться от апдейтов
    void Update()
    {
        if (logicalInputs.Any(a => a.value))
        {
            logicalOutput.value = true;
        }
        else
        {
            logicalOutput.value = false;
        }
    }
}
