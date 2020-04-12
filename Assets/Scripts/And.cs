using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class And : TwoInputs
{
    public override bool Strategy()
    {
        return logicalInput1.value && logicalInput2.value;
    }
}
