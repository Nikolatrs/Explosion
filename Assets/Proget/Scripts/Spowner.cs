using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    public void SpawnFragment(ExplosiveObject recastObject)
    {
        var cubeInst = Instantiate(recastObject, recastObject.transform.position, recastObject.transform.rotation);
        cubeInst.transform.position += Random.insideUnitSphere * 0.1f;
        cubeInst.SetValue(recastObject.Factor);
        Distroy(recastObject);
    }

    public void Distroy (ExplosiveObject recastObject)
    {
        Destroy(recastObject.gameObject);
    }
}
