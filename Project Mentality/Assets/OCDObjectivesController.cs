using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCDObjectivesController : MonoBehaviour
{
    //Boolean array to keep track of which real objectives have been completed
    private bool[] realObj = new bool[7];
    //Int of fake objective progress
    private int fakeObj;
    //Int to keep track of how many times the player has left the house succesfully, in order to tell them game how many more fake objectives to add
    private int successes;
    //Int to keep track of fake points;
    private int points;
    
    // Start is called before the first frame update
    void Start()
    {
        fakeObj = 0;
        successes = 0;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //EventHandler will call this method to increment the fake and real objectives when the correct current objective is completed
    void ObjectivePassed(int reward, int obj)
    {
        if (!realObj[obj]) realObj[obj] = true;
        fakeObj++;
        points += reward;
    }

    //EventHandler will call this method to pass the real objective when it's completed out of order, then calls the objective failed method
    void OutOfOrderPass(int obj)
    {
        if (!realObj[obj]) realObj[obj] = true;
        ObjectiveFailed();
    }

    //EventHandler will call this method when an action is failed
    void ObjectiveFailed()
    {
        fakeObj = 0;
        points = 0;
    }

    //EventHandler calls this method when the player leaves the house successfully; 
    void Escape()
    {
        ResetRealObj();
        fakeObj = 0;
        successes++;
        points = 0;
    }

    void ResetRealObj()
    {
        for(int i = 0; i < 7; i++)
        {
            realObj[i] = false;
        }
    }

    int getSuccesses()
    {
        return successes;
    }

    int getPoints()
    {
        return points;
    }
}
