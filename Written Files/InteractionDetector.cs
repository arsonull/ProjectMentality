using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDetector : MonoBehaviour
{
    public Camera myInteractionCamera;

    //public OCDObjectivesController ocdCon;
    // Start is called before the first frame update
    public GameObject interactionTextObj;
    public Text interactionText;
    public OCDObjectivesController ocdCon;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = myInteractionCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Interactable")
            {
                GameObject obj = hit.transform.gameObject;
                //For debugging, but spams console if not collapsed
                Debug.Log("Looking at " + obj.name);

                if (obj.GetComponent<Door>() != null)
                {
                    interactionTextObj.SetActive(true);
                    Door script = obj.GetComponent<Door>();
                    interactionText.text = script.InteractText;
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        script.InteractAction();
                    }
                }
                else if (obj.GetComponent<ObjectiveTest>())
                {
                    if (obj.name != "Dining_Table")
                    {
                        interactionTextObj.SetActive(true);
                        ObjectiveTest script = obj.GetComponent<ObjectiveTest>();
                        interactionText.text = script.InteractText;
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            //ocdCon.ObjectivePassed(5, 1);
                            script.InteractAction();
                        }
                    }
                    else
                    {
                        if (ocdCon.realObj[6])
                        {
                            interactionTextObj.SetActive(true);
                            ObjectiveTest script = obj.GetComponent<ObjectiveTest>();
                            interactionText.text = script.InteractText;
                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                //ocdCon.ObjectivePassed(5, 1);
                                script.InteractAction();
                            }
                        }
                    }
                }
                else if (obj.GetComponent<FakeObjective>())
                {
                    FakeObjective script = obj.GetComponent<FakeObjective>();
                    switch (obj.name)
                    {
                        case "PC_Case":
                            if (ocdCon.successes > 0)
                            {
                                if (ocdCon.realObj[0])
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = "Press F to turn on computer";
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                                if (ocdCon.realObj[3] && ocdCon.successes > 2)
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = "Press F to turn off computer";
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                            }
                            break;
                        case "Couch":
                            if (ocdCon.successes > 1)
                            {
                                if (ocdCon.realObj[2])
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = script.InteractText;
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                            }
                            break;
                        case "Mirror":
                            if (ocdCon.successes > 3)
                            {
                                if (ocdCon.realObj[4])
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = script.InteractText;
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                            }
                            break;
                        case "Toilet":
                            if (ocdCon.successes > 4)
                            {
                                if (ocdCon.realObj[5])
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = script.InteractText;
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                            }
                            break;
                        case "Bed":
                            if (ocdCon.successes > 5)
                            {
                                if (ocdCon.realObj[7])
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = script.InteractText;
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                            }
                            break;
                        case "GasStove":
                            if (ocdCon.successes > 6)
                            {
                                if (ocdCon.realObj[8])
                                {
                                    interactionTextObj.SetActive(true);
                                    interactionText.text = script.InteractText;
                                    if (Input.GetKeyDown(KeyCode.F))
                                    {
                                        //ocdCon.ObjectivePassed(5, 1);
                                        script.InteractAction();
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            else
            {
                interactionTextObj.SetActive(false);
            }
        }
    }
}
