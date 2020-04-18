using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Lamp : LogicalElement
{
    public Light light;
    public HDAdditionalLightData data;

    protected override void Awake()
    {
        base.Awake();
        logicalInput.valueChanged += Switch;
        Switch(logicalInput.value);
    }

    void Switch(bool v)
    {
        logicalOutput.value = v;
        if (v)
        {
            //light.intensity = 1.5f;
            data.intensity = 600f;
            GetComponent<MeshRenderer>().material.SetFloat("_EMISSIONINTENCITY",3.5f);
        }
        else
        {
            //light.intensity = 0;
            data.intensity = 0;
            //GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            GetComponent<MeshRenderer>().material.SetFloat("_EMISSIONINTENCITY", 0);
        }
    }
}
