using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Text text;
    public Module module;

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

        text.text = "";
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.gameObject.tag == "Switch")
            {
                text.text = "E";
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.collider.GetComponent<BasicSwitch>().Toggle();
                }
            }

            if (hit.collider.gameObject.GetComponent<Module>())
            {
                //text.text = "E";
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    module = hit.collider.GetComponent<Module>();
                    module.PickUp(transform);
                }
            }

            if (hit.collider.gameObject.GetComponent<ModuleHandler>() && module)
            {
                //text.text = "E";
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    module.Place(hit.collider.GetComponent<ModuleHandler>());
                    module = null;
                }
            }
        }
    }
}
