using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicalInput : MonoBehaviour
{

    public bool value = false;

    public List<LogicalOutput> sources;

    // Start is called before the first frame update
    void Awake()
    {
        sources = new List<LogicalOutput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sources.Any(a => a.value))
            value = true;
        else
            value = false;
    }
}
