using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OCDObjectivesController : MonoBehaviour
{
    //Boolean array to keep track of which real objectives have been completed
    public bool[] realObj = new bool[9];
    public int nextRealObj;
    //Int of fake objective progress
    private bool[] fakeObj;
    public int nextFakeObj;
    //Int to keep track of how many times the player has left the house succesfully, in order to tell them game how many more fake objectives to add
    public int successes;
    //Int to keep track of fake points;
    private int points;
    //The Objective List UI
    public Text ObjectiveListText;

    //Array of game objects representing fake objectives
    private GameObject[] fakeObjects;

    public GameObject RewardObj;
    public Text RewardText;

    public Text ScoreText;

    Vector3 originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.localPosition;
        nextRealObj = 1;
        nextFakeObj = 1;
        successes = 0;
        fakeObjects = new GameObject[] {GameObject.Find("PC_Case"), GameObject.Find("Couch"), GameObject.Find("Mirror"), GameObject.Find("Toilet"), GameObject.Find("Bed"), GameObject.Find("GasStove")};
        setFakeObjectives();
        points = 0;
        //ObjectiveListText.text = "Testing 1,2,3";
    }

    //EventHandler will call this method to increment the fake and real objectives when the correct current objective is completed
    public void ObjectivePassed(int obj)
    {
        Debug.Log("In ObjectivePassed() for arg: " + obj);
        if (InOrderCheck(obj) || obj == 10)
        {
            switch (obj)
            {
                case 1:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nGo turn on your computer";
                    if (successes > 0) ObjectiveListText.text = "Objective:\nGo turn on your computer";
                    else ObjectiveListText.text = "Objective:\nGrab your dirty clothes from your basket";
                    break;
                case 2:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nPut your clothes in the washer";
                    ObjectiveListText.text = "Objective:\nPut your clothes in the washer";
                    break;
                case 3:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nGo relax on the couch while your clothes are washing";
                    if (successes > 1) ObjectiveListText.text = "Objective:\nGo relax on the couch while your clothes are washing";
                    else ObjectiveListText.text = "Objective:\nNow go dry those clothes from the washer";
                    break;
                case 4:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nGo turn off your computer, don't want to waste electricity";
                    if (successes > 2) ObjectiveListText.text = "Objective:\nGo turn off your computer, don't want to waste electricity";
                    else ObjectiveListText.text = "Objective:\nYou should clean yourself up with a shower now";
                    break;
                case 5:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nInspect your hair in the mirror";
                    if (successes > 3) ObjectiveListText.text = "Objective:\nInspect your hair in the mirror";
                    else ObjectiveListText.text = "Objective:\nNow lets make sure that smile is nice and bright by brushing your teeth";
                    break;
                case 6:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nGo sit on the toilet for a while";
                    if (successes > 4) ObjectiveListText.text = "Objective:\nGo sit on the toilet for a while";
                    else ObjectiveListText.text = "Objective:\nGo get yourself a nice pie for breakfast in the kitchen";
                    break;
                case 7:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nNow go eat that delicious pie at the kitchen table";
                    ObjectiveListText.text = "Objective:\nNow go eat that delicious pie at the kitchen table";
                    break;
                case 8:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nGo make your bed";
                    if (successes > 5) ObjectiveListText.text = "Objective:\nGo make your bed";
                    else ObjectiveListText.text = "Objective:\nGrab your keys from the bedroom shelf on the wall";
                    break;
                case 9:
                    InOrderPass(obj);
                    // ObjectiveListText.text = ObjectiveListText.text + "\nEnsure the stove is turned off";
                    if (successes > 6) ObjectiveListText.text = "Objective:\nEnsure the stove is turned off";
                    else ObjectiveListText.text = "Objective:\nHead out the front door, you're ready to take on the day!";
                    break;
                case 10:
                    Escape();
                    break;
                default:
                    ObjectiveListText.text = "AHHHHHHHH";
                    break;
            }
        }
        else
        {
            OutOfOrderPass(obj);
        }
        
    }

    public void FakeObjectivePassed(int obj)
    {
        Debug.Log(fakeObj.Length);
        //if (obj == 1 && fakeObj[0] && successes >= 2) obj = 3;
        if (obj == 1 && successes > 2 && fakeObj[0]) obj = 3;
        switch (obj)
        {
            //Turning on computer
            case 1:
                Debug.Log("Turn on computer");
                if (realObj[0])
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nGrab your dirty clothes from your basket";
                }
                else ObjectiveFailed();
                break;
            //Relaxing on couch. Requires realObj 0-2
            case 2:
                if (InOrderCheck(3) && InOrderFakeCheck(obj))
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nNow go dry those clothes from the washer";
                }
                else
                {
                    ObjectiveFailed();
                }
                break;
            //Turn off computer. Requires realObj 0-3
            case 3:
                Debug.Log("Turn off computer");
                if (InOrderCheck(4) && InOrderFakeCheck(obj))
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nYou should clean yourself up with a shower now";
                }
                else
                {
                    ObjectiveFailed();
                }
                break;
            //Inspect mirror. Requires 0-4
            case 4:
                if (InOrderCheck(5) && InOrderFakeCheck(obj))
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nNow lets make sure that smile is nice and bright by brushing your teeth";
                }
                else
                {
                    ObjectiveFailed();
                }
                break;
            //Sit on toilet. Requires 0-5
            case 5:
                if (InOrderCheck(6) && InOrderFakeCheck(obj))
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nGo get yourself a nice pie for breakfast in the kitchen";
                }
                else
                {
                    ObjectiveFailed();
                }
                break;
            //Make your bed Requires 0-7
            case 6:
                if (InOrderCheck(8) && InOrderFakeCheck(obj))
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nGrab your keys from the bedroom shelf on the wall";
                }
                else
                {
                    ObjectiveFailed();
                }
                break;
            //Ensure Stove is off. Requires 0-8
            case 7:
                if (InOrderCheck(9) && InOrderFakeCheck(obj))
                {
                    InOrderFakePass(obj);
                    ObjectiveListText.text = "Objective:\nHead out the front door, you're ready to take on the day!";
                }
                else
                {
                    ObjectiveFailed();
                }
                break;
            default:
                ObjectiveListText.text = "AHHHHHHHH";
                break;
        }
    }

    // void WaitToReleaseReward(int seconds)
    // {
    //     yield WaitForSecondsRealtime(seconds);
    //     return;
    // }

    void ReleaseReward()
    {
        RewardObj.SetActive(false);
    }

    //EventHandler will call this method to pass the real objective when it's completed out of order, then calls the objective failed method
    void OutOfOrderPass(int obj)
    {
        if (obj == 1) realObj[0] = true;
        else if (!realObj[obj-1]) realObj[obj-1] = true;
        ObjectiveFailed();
    }

    bool InOrderCheck(int obj)
    {
        if (obj == 1) return true;
        if (obj == nextRealObj) return true;
        for (int i = 0; i < obj -1; i++)
        {
            if (!realObj[i])
            {
                Debug.Log("Out of order for: " + obj + ", i = " + i);
                var list = new List<bool>(realObj);
                Debug.Log(string.Join(", ", list.ConvertAll(x => x.ToString()).ToArray()));
                return false;
            } 
        }
        Debug.Log("Reached end of InOrderCheck");
        return false;
    }

    bool InOrderFakeCheck(int obj)
    {
        if (obj == nextFakeObj) return true;
        for (int j = 0; j < obj -1; j++)
        {
            if (obj == 1) return true;
            if (!fakeObj[j])
            {
                Debug.Log("In Order Fake check failed for obj: " + obj);
                var list = new List<bool>(fakeObj);
                Debug.Log(string.Join(", ", list.ConvertAll(x => x.ToString()).ToArray()));
                return false;
            }
        }
        return true;
    }

    void InOrderPass(int obj)
    {
        nextRealObj++;
        realObj[obj -1] = true;
        int reward = obj * 10;
        RewardText.text = "+" + reward + " Points!!";
        RewardObj.SetActive(true);
        points += reward;
        ScoreText.text = "Score: " + points;
        Invoke("ReleaseReward", 5.0f);
    }

    void InOrderFakePass(int obj)
    {
        nextFakeObj++;
        fakeObj[obj -1] = true;
        int reward = obj * 10;
        RewardText.text = "+" + reward + " Points!!";
        RewardObj.SetActive(true);
        points += reward;
        ScoreText.text = "Score: " + points;
        Invoke("ReleaseReward", 5.0f);
    }

    //EventHandler will call this method when an action is failed
    void ObjectiveFailed()
    {
        setFakeObjectives();
        int temp = points;
        RewardText.text = "No! You have to do your tasks in order! -" + temp;
        RewardObj.SetActive(true);
        points = 0;
        ScoreText.text = "Score: " + points;
        ObjectiveListText.text = "Objective:\nGet Dressed";
        nextRealObj = 1;
        nextFakeObj = 1;
        Invoke("ReleaseReward", 5.0f);
    }

    //EventHandler calls this method when the player leaves the house successfully; 
    void Escape()
    {
        if (AllRealObjPassed())
        {
            ResetRealObj();
            successes++;
            setFakeObjectives();
            gameObject.transform.position = originalPosition;
            RewardText.text = "Next Day...";
            RewardObj.SetActive(true);
            points = 0;
            nextFakeObj = 1;
            nextRealObj = 1;
            GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
            foreach(GameObject interactable in interactables)
            {
                if (interactable.GetComponent<Door>())
                {
                    Door door = interactable.GetComponent<Door>();
                    if (door.isOpen)
                    {
                        door.InteractAction();
                    }
                }
                else if (interactable.GetComponent<ObjectiveTest>())
                {
                    ObjectiveTest script = interactable.GetComponent<ObjectiveTest>();
                    script.resetPosition();
                }
            }
            ObjectiveListText.text = "Objective:\nGet dressed";
            Invoke("ReleaseReward", 5.0f); 
        }
        else
        {
            RewardText.text = "You need to complete all objectives in order to be ready for the day!!";
            RewardObj.SetActive(true);
            Invoke("ReleaseReward", 10.0f);
        }
    }

    public void testObjectiveText(string test)
    {
        Debug.Log(ObjectiveListText.text);
        string temp = string.Concat(ObjectiveListText.text, test);
        ObjectiveListText.text = temp;
    }

    //helper method to reset fake objectives
    private void setFakeObjectives()
    {
        // Debug.Log("In SetFakeObjectives, succ: " + successes);
        // for (int i = 0; i <= 5; i++)
        // {
        //     fakeObjects[i].tag = "Disabled";
        //     Debug.Log(fakeObjects[i].name + " is " + fakeObjects[i].tag);
        // }
        switch(successes)
        {
            case 0:
                fakeObj = new bool[0];
                break;
            case 1:
                fakeObj = new bool[1];
                // fakeObjects[0].tag = "Interactable";
                // Debug.Log(fakeObjects[0].name + " is " + fakeObjects[0].tag);
                break;
            case 2:
                fakeObj = new bool[2];
                // fakeObjects[0].tag = "Interactable";
                // fakeObjects[1].tag = "Interactable";
                // Debug.Log(fakeObjects[1].name + "1 is " + fakeObjects[1].tag);
                break;
            case 3:
                fakeObj = new bool[3];
                // fakeObjects[0].tag = "Interactable";
                // fakeObjects[1].tag = "Interactable";
                break;
            case 4:
                fakeObj = new bool[4];
                // fakeObjects[0].tag = "Interactable";
                // fakeObjects[1].tag = "Interactable";
                // fakeObjects[2].tag = "Interactable";
                // Debug.Log(fakeObjects[2].name + "2 is " + fakeObjects[2].tag);
                break;
            case 5:
                fakeObj = new bool[5];
                // fakeObjects[0].tag = "Interactable";
                // fakeObjects[1].tag = "Interactable";
                // fakeObjects[2].tag = "Interactable";
                // fakeObjects[3].tag = "Interactable";
                // Debug.Log(fakeObjects[3].name + "3 is " + fakeObjects[3].tag);
                break;
            case 6:
                fakeObj = new bool[6];
                // fakeObjects[0].tag = "Interactable";
                // fakeObjects[1].tag = "Interactable";
                // fakeObjects[2].tag = "Interactable";
                // fakeObjects[3].tag = "Interactable";
                // fakeObjects[4].tag = "Interactable";
                // Debug.Log(fakeObjects[4].name + "4 is " + fakeObjects[4].tag);
                break;
            case 7:
                fakeObj = new bool[7];
                // fakeObjects[0].tag = "Interactable";
                // fakeObjects[1].tag = "Interactable";
                // fakeObjects[2].tag = "Interactable";
                // fakeObjects[3].tag = "Interactable";
                // fakeObjects[4].tag = "Interactable";
                // fakeObjects[5].tag = "Interactable";
                // Debug.Log(fakeObjects[5].name + "5 is " + fakeObjects[5].tag);
                break;
            default:
                fakeObj = new bool[0];
                break;
        }
    }

    void ResetRealObj()
    {
        for(int i = 0; i < 9; i++)
        {
            realObj[i] = false;
        }
    }

    bool AllRealObjPassed()
    {
        for(int i = 0; i < 9; i++)
        {
            if (!realObj[i]) return false;
        }
        return true;
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
