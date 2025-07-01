using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ExplosiveObject _prefab;
    [SerializeField] private ExplosiveFragmentSpawner _explosiveFragmentSpawner;
    [SerializeField] private Camera _camera;
    [SerializeField] private InputManager _inputManager;
    

    private Ray _ray;

    private void OnEnable()
    {
        _inputManager.LeftClicK += _inputManager_LeftClicK;
    }

    private void OnDisable()
    {
        _inputManager.LeftClicK -= _inputManager_LeftClicK;
    }

    private void _inputManager_LeftClicK()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
            if (hit.transform.TryGetComponent(out ExplosiveObject entityExcption))
            {
                _explosiveFragmentSpawner.Split(entityExcption);

                Destroy(entityExcption.gameObject);
            }
    }


}
