using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicalInput : MonoBehaviour
{
    public bool _value = false;
    public bool value {
        set
        {
            if (_value != value)
            {
                _value = value;
                valueChanged?.Invoke(value);
            }
        }
        get
        {
            return _value;
        }
    }
    public delegate void LogicalEvent(bool v);
    public event LogicalEvent valueChanged;

    public LogicalOutput source;
    
    void Update()
    {
        value = source.value;
        /*
        if (OR)
            if (sources.Any(a => a.value))
            {
                Value = true;
            }
            else
            {
                Value = false;
            }
        else
            if (!sources.Any(a => !a.value))
            {
                Value = true;
            }
            else
            {
                Value = false;
            }
            */
    }
}
