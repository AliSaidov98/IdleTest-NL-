using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroying : MonoBehaviour
{
    [NonSerialized]
    public int Health = 3;
    
    private GameObject _tree = null;
    private GameObject _log = null;

    private CharacterAction _characterAction;

    private void Awake()
    {
        _tree = transform.GetChild(0).gameObject;
        _log = transform.GetChild(1).gameObject;
        
        _characterAction = FindObjectOfType<CharacterAction>();
    }


    public IEnumerator LogAppearing()
    {
        _characterAction.DestroyedTree(_tree);
        yield return new WaitForSeconds(2.5f);
        _tree.SetActive(false);
        _log.transform.position = _tree.transform.position;
        _log.SetActive(true);
        _characterAction.GrabLogsAnim();
        
    }

    public void DestroyLogs()
    {
        
    }
}
