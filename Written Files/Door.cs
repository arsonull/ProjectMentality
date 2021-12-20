using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableTrigger
{
    public bool isOpen = false;
    public Animator myAnimationController;
    //[SerializeField] private Animator myAnimationController;

    public void start()
    {
        InteractText = "Press F to ";

        if (isOpen)
        {
            InteractText += "close";
        }
        else
        {
            InteractText += "open";
        }
    }

    public void Awake()
    {
        myAnimationController = GetComponent<Animator>();
    }

    public override void InteractAction()
    {
        // Debug.Log("F has been pressed");
        if (isOpen)
        {
            // Debug.Log(InteractText);
            myAnimationController.SetTrigger("close");
            isOpen = false;
        }
        else
        {
            // Debug.Log(InteractText);
            myAnimationController.SetTrigger("open");
            isOpen = true;
        }
        //GetComponent<Animator>().SetBool("isOpen", isOpen);
        //myAnimationController.SetBool("isOpen", isOpen);
    }
}
