using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Explosion : MonoBehaviour
{
    public void Calculation(ExplosiveObject recastObject)
    {

        int randomQuantity = Random.Range(2, 6);
        int randomProcent = Random.Range(0, 100);

        if (randomProcent < recastObject.Procent)
        {
            for (int i = 0; i < randomQuantity; i++)
            {
                Create(recastObject);
            }
        }

       recastObject.DestroyObject();
    }

    private void Create(ExplosiveObject recastObject)
    {
        var cubeInst = Instantiate(recastObject, recastObject.transform.position, recastObject.transform.rotation);
        cubeInst.transform.position += Random.insideUnitSphere * 0.1f;
        cubeInst.SetProcent(recastObject.Procent);
        cubeInst.SetScale();
    }
}
