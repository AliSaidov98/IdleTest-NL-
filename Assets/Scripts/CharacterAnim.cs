using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator animator;
    private CharecterStates _charecterStates;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _charecterStates = GetComponent<CharecterStates>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walk", _charecterStates.CharecterState[States.GoToTree.ToString()]);
        
        if(!animator.GetBool("walk"))
            animator.SetBool("walk", _charecterStates.CharecterState[States.GoToHome.ToString()]);

        animator.SetBool("cut", _charecterStates.CharecterState[States.CutTree.ToString()]);

        animator.SetBool("grabLogs", _charecterStates.CharecterState[States.GrabLogs.ToString()]);
    }
}
