using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class CubeDivisibilityCalculator : MonoBehaviour
{
    [SerializeField] private Spawner _spowner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    private int _minQuantity = 2;
    private int _maxQuantity = 6;

        private void OnEnable()
    {
        _raycaster.HitObject += RaycasterHitObject;
    }


    private void OnDisable()
    {
        _raycaster.HitObject -= RaycasterHitObject;
    }

    private void RaycasterHitObject(ExplosiveObject cube)
    {
        int randomProcent = Random.Range(0, 100);

        if (randomProcent < cube.Procent)
        {
                _spowner.SpawnFragment(cube);

        }
        else
        {
            _exploder.PushingFpragment(cube);
        }
            _spowner.DestroyObgect(cube);
    }

}
