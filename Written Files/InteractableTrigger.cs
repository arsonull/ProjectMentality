using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    //[SerializeField] private bool isTriggered = false;
    [SerializeField] public string InteractText;

    // public void OnTriggerEnter(Collider obj)
    // {
    //     if (obj.CompareTag("Player"))
    //     {
    //         isTriggered = true;
    //         Debug.Log("Player has entered");
    //     }
    // }

    // public void OnTriggerExit(Collider obj)
    // {
    //     if (obj.CompareTag("Player"))
    //     {
    //         isTriggered = false;
    //         Debug.Log("Player has left");
    //     }
    // }

    // private void Update()
    // {
    //     if (isTriggered && Input.GetKeyDown(KeyCode.F))
    //     {
    //         InteractAction();
    //     }
    // }

    public string getInteractText()
    {
        return InteractText;
    }

    public virtual void InteractAction()
    {

    }
}
