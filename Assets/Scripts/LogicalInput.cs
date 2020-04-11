using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicalInput : LogicalIO
{
    public LogicalOutput source;
    
    void Update()
    {
        value = (source != null) ? source.value : false;
    }
}
