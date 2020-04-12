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

    /*
    public LogicalOutput source
    {
        get
        {
            return _source;
        }
        set
        {
            if (_source != null) _source.valueChanged -= UpdateOutput;
            _source = value;
            if (_source != null) _source.valueChanged += UpdateOutput;
            UpdateOutput(true);

        }
    }

    private void Awake()
    {
        if (_source!=null)
            _source.valueChanged += UpdateOutput;
        UpdateOutput(true);
    }


    public void UpdateOutput(bool v)
    {
        value = (_source != null) ? _source.value : false;
    } 
     */
}
