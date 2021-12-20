using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTest : InteractableTrigger
{
    public OCDObjectivesController ocdCon;
    public GameObject obj;
    Vector3 originalPosition;
    bool originalState;

    void Start()
    {
        originalPosition = gameObject.transform.position;
        originalState = gameObject.activeSelf;
    }

    void Awake()
    {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // ocdCon = player.GetComponent<OCDObjectivesController>();
        obj = gameObject;
    }
    
    public override void InteractAction()
    {
        Debug.Log("In InteractAction for " + obj.name);
        // Debug.Log(InteractText);
        // ocdCon.testObjectiveText(InteractText);
        switch(obj.name)
        {
            case "Wardrobe":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(1);
                break;
            case "ClothBasket":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(2);
                break;
            case "WashingMachine":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(3);
                break;
            case "DryingMachine":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(4);
                break;
            case "Bath":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(5);
                break;
            case "Sink":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(6);
                break;
            case "Pie":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(7);
                break;
            case "Dining_Table":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(8);
                break;
            case "Bedroom_Shelf":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(9);
                break;
            case "FrontDoor":
                Debug.Log("Case for " + obj.name);
                ocdCon.ObjectivePassed(10);
                break;
            default:
                break;
        }
    }

    public void resetPosition()
    {
        gameObject.transform.position = originalPosition;
        gameObject.SetActive(originalState);
    }
}
