﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negator : LogicalElement
{
    protected override void Awake()
    {
        base.Awake();
        logicalInput.valueChanged += Switch;
        Switch(logicalInput.value);

    }

    void Switch(bool v)
    {
        logicalOutput.value = !v;
    }
}
