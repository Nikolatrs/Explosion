using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class ExplosiveFragmentSpawner : MonoBehaviour
{
    private int _minQuantity = 2;
    private int _maxQuantity = 6;

    public void Split(ExplosiveObject recastObject)
    {
        int randomQuantity = Random.Range(_minQuantity, _maxQuantity + 1);
        int randomProcent = Random.Range(0, 100);

        if (randomProcent < recastObject.Procent)
            for (int i = 0; i < randomQuantity; i++)
                SpawnFragment(recastObject);
        else
            PushingFpragment(recastObject, recastObject.ExplosionRadius, recastObject.ExplosionForse);
    }

    private void SpawnFragment(ExplosiveObject recastObject)
    {
        var cubeInst = Instantiate(recastObject, recastObject.transform.position, recastObject.transform.rotation);
        cubeInst.transform.position += Random.insideUnitSphere * 0.1f;
        cubeInst.SetValue(recastObject.Factor);
    }

    public void PushingFpragment(ExplosiveObject recastObject, float radius, float forse)
    {
        Vector3 objectPosition = recastObject.transform.position;
        Collider[] fragments = Physics.OverlapSphere(objectPosition, radius);

        foreach (var fragment in fragments)
            if (fragment.attachedRigidbody != null)
                fragment.attachedRigidbody.AddExplosionForce(forse, objectPosition, radius);
    }
}
