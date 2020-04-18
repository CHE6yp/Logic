using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Text text;
    public Text text2;
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


        text.text = "";
        text2.text = "";
        if (Physics.Raycast(ray, out hit, 10))
        {

            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider.gameObject.tag == "Switch")
            {
                text2.text = "E - нажать";
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.collider.GetComponent<BasicSwitch>().Toggle();
                }
            }

            if (module)
            {
                text.text = "Q - положить";

                if (Input.GetKeyUp(KeyCode.Q))
                {
                    if (hit.collider.gameObject.GetComponent<ModuleHandler>())
                    {
                        if (hit.collider.gameObject.GetComponent<ModuleHandler>().module == null)
                        {
                            module.Place(hit.collider.GetComponent<ModuleHandler>());
                            module = null;
                        }
                        else
                        {
                            Module moduleTemp = module;
                            module = hit.collider.gameObject.GetComponent<ModuleHandler>().module;
                            hit.collider.gameObject.GetComponent<ModuleHandler>().module.PickUp(transform);
                            moduleTemp.Place(hit.collider.GetComponent<ModuleHandler>());
                        }
                    }
                    else
                    {
                        module.Throw();
                        module = null;
                    }
                }
            }


            if (hit.collider.gameObject.GetComponent<Module>())
            {
                if (!hit.collider.GetComponent<Module>().attached || hit.collider.GetComponent<Module>().handler.detachable)
                {
                    text.text = "Q - взять";
                    if (Input.GetKeyUp(KeyCode.Q) && !module)
                    {
                        module = hit.collider.GetComponent<Module>();
                        module.PickUp(transform);
                    }
                }
            }

            
            
        }
    }
}
