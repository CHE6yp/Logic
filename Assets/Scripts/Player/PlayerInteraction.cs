using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawLine(ray.origin, ray.direction*100);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.tag == "Switch")
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.collider.GetComponent<BasicSwitch>().Toggle();
                }
            }
        }
    }
}
