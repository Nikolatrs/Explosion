using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class CubeDivisibilityCalculator : MonoBehaviour
{
    [SerializeField] private Spowner _spowner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private float radius;
    [SerializeField] private float forse;

    private int _minQuantity = 2;
    private int _maxQuantity = 6;


    private void OnEnable()
    {
        _raycaster.HitObject += _raycaster_HitObject;
    }


    private void OnDisable()
    {
        _raycaster.HitObject -= _raycaster_HitObject;
    }

    private void _raycaster_HitObject(ExplosiveObject cube)
    {
        int randomQuantity = Random.Range(_minQuantity, _maxQuantity + 1);
        int randomProcent = Random.Range(0, 100);

        if (randomProcent < cube.Procent)
            for (int i = 0; i < randomQuantity; i++)
                _spowner.SpawnFragment(cube);
        else
        {
            _exploder.PushingFpragment(cube, radius, forse);
            _spowner.Distroy(cube);
        }
    }

}
