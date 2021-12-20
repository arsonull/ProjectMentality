using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeObjective : InteractableTrigger
{
    public OCDObjectivesController ocdCon;
    public GameObject obj;

    void Awake()
    {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // ocdCon = player.GetComponent<OCDObjectivesController>();
        obj = gameObject;
    }
    
    public override void InteractAction()
    {
        switch(obj.name)
        {
            case "PC_Case":
                ocdCon.FakeObjectivePassed(1);
                break;
            case "Couch":
                ocdCon.FakeObjectivePassed(2);
                break;
            case "Mirror":
                ocdCon.FakeObjectivePassed(4);
                break;
            case "Toilet":
                ocdCon.FakeObjectivePassed(5);
                break;
            case "Bed":
                ocdCon.FakeObjectivePassed(6);
                break;
            case "GasStove":
                ocdCon.FakeObjectivePassed(7);
                break;
            default:
                break;
        }
    }
}
