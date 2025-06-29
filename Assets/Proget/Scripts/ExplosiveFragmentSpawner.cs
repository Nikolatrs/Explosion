using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ExplosiveFragmentSpawner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;

    private int _minQuantity = 2;
    private int _maxQuantity = 6;

    public void Split(ExplosiveObject recastObject)
    {
        int randomQuantity = Random.Range(_minQuantity, _maxQuantity + 1);
        int randomProcent = Random.Range(0, 100);

        if (randomProcent < recastObject.Procent)
        {
            for (int i = 0; i < randomQuantity; i++)
                SpawnFragment(recastObject);
        }
        else
        {
            recastObject.PushingFpragment();
        }

            recastObject.DestroyObject();
        }

        private void SpawnFragment(ExplosiveObject recastObject)
        {
            var cubeInst = Instantiate(recastObject, recastObject.transform.position, recastObject.transform.rotation);
            cubeInst.transform.position += Random.insideUnitSphere * 0.1f;
            cubeInst.SetValue(recastObject.Procent);
        }


    }
