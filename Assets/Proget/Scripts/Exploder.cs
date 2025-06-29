using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ExplosiveObject _prefab;
    [SerializeField] private ExplosiveFragmentSpawner _spownExplosion;
    [SerializeField] private Camera _camera;

    private Ray _ray;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
            if (hit.transform.TryGetComponent(out ExplosiveObject entityExcption))
                _spownExplosion.Split(entityExcption);

    }
}
