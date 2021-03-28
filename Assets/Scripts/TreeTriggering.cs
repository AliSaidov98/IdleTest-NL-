using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTriggering : MonoBehaviour
{
    private ParticleSystem _treeParticleSystem = null;
    
    private int _cutCount = 0;
    
    private Rigidbody _treeRb;
    private TreeDestroying _treeDestroying;

    private CharecterStates _charecterStates;
    private CharacterAction _characterAction;
    
    private void Awake()
    {
        _treeParticleSystem = FindObjectOfType<ParticleSystem>();
        _charecterStates = FindObjectOfType<CharecterStates>();
        _characterAction = FindObjectOfType<CharacterAction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _characterAction._currentTree.gameObject)
        {
            print("triggerTime ");
            
            if (other.CompareTag("Tree") && _charecterStates.GetCurrentState() == States.CutTree.ToString())
            {
                print(_charecterStates.GetCurrentState());
            
                _treeParticleSystem.transform.position = transform.position;
                _treeParticleSystem.Play();

                if (_cutCount == 0)
                {
                    SetUpComponents(other);
                }

                CuttingTree();
            }
        }
        
       
    }

    private void CuttingTree()
    {
        if (_treeDestroying.Health <= 0)
        {
            _treeRb.AddForce(transform.right * 2f, ForceMode.Impulse);
            StartCoroutine(_treeDestroying.LogAppearing());
            _cutCount = 0;
        }
        else
        {
            _treeRb.AddForce(transform.right * 0.2f, ForceMode.Impulse);
        }
        
        _treeDestroying.Health--;
    }

    private void SetUpComponents(Collider other)
    {
        _treeRb = other.GetComponent<Rigidbody>();
        _treeDestroying = other.transform.parent.GetComponent<TreeDestroying>();

        _treeRb.isKinematic = false;
        
        _cutCount++;
    }
}
