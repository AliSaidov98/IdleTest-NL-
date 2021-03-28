using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MouseClicking : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private GameObject tree;
    
    RaycastHit _hit;

    private CharacterAction _characterAction;

    private void Awake()
    {
        _characterAction = FindObjectOfType<CharacterAction>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)/* && numOfTreesAvailable != 0*/)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.transform.CompareTag("Ground"))
                {
                    Instantiate(tree, _hit.point, Quaternion.identity);
                        
                    //если нужно вызывать на клик вместо апдейта
                    // _characterAction.AddTreesToList();
                }
            }
        }
    }
}
