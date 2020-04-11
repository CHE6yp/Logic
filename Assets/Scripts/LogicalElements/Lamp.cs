using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : LogicalElement
{
    public Light light;

    protected override void Awake()
    {
        base.Awake();
        logicalInput.valueChanged += Switch;
    }

    void Switch(bool v)
    {
        if (v)
            light.intensity = 4;
        else
            light.intensity = 0;
    }
}
