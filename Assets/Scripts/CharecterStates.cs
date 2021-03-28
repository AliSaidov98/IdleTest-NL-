using System;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle,
    GoToTree,
    CutTree,
    GoToHome,
    GrabLogs
}

public class CharecterStates : MonoBehaviour
{
    public Dictionary<string, bool> CharecterState = new Dictionary<string, bool>();

    private void Awake()
    {
        AssignStates();
    }

    private void AssignStates()
    {
        foreach(string day in Enum.GetNames(typeof(States))) {
            CharecterState.Add(day, false);
        }
    }

    public void SetCurrentState(string state)
    {
        foreach(string day in Enum.GetNames(typeof(States))) {
            
            if (state == day)
            {
                CharecterState[day] = true;
            }
            else
            {
                CharecterState[day] = false;
            }
            
        }

        /*foreach (var chState in CharecterState)
        {
            print(chState.Key + ": " + chState.Value);
        }*/
    }

    public string GetCurrentState()
    {
        foreach (var chState in CharecterState)
        {
            if (chState.Value == true)
            {
                return chState.Key;
            }
        }

        return null;
    }
}
