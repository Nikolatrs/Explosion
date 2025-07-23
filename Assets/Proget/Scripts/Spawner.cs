using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnFragment(ExplosiveObject recastObject)
    {
        int randomQuantity = Random.Range(_minQuantity, _maxQuantity + 1);


        var cubeInst = Instantiate(recastObject, recastObject.transform.position += Random.insideUnitSphere * 0.1f, recastObject.transform.rotation);
        //cubeInst.transform.position += Random.insideUnitSphere * 0.1f;
        cubeInst.SetValue(recastObject.Factor);
        DestroyObgect(recastObject);
    }

    public void DestroyObgect (ExplosiveObject recastObject)
    {
        Destroy(recastObject.gameObject);
    }
}
