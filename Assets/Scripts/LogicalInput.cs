using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class LogicalInput : LogicalIO
{
    public LogicalOutput _source;
    public LogicalOutput source
    {
        set
        {
            if (_source != value)
            {
                if (_source!=null)
                {
                    _source.valueChanged -= UpdateValue;
                }
                _source = value;
                if (_source != null)
                {
                    _source.valueChanged += UpdateValue;
                }
                UpdateValue();
            }
        }
        get
        {
            return _source;
        }
    }

    void UpdateValue()
    {
        value = (source != null) ? source.value : false;
    }

    void UpdateValue(bool v)
    {
        value = v;
    }
}
