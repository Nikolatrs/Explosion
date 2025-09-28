using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void PushingFpragment(ExplosiveObject recastObject)
    {
        foreach (var fragment in GetFragnent(recastObject))
            fragment.AddExplosionForce(recastObject.ExplosionForse, recastObject.transform.position, recastObject.ExplosionRadius);
    }

    public List<Rigidbody> GetFragnent(ExplosiveObject recastObject)
    {
        Vector3 objectPosition = recastObject.transform.position;
        Collider[] hits = Physics.OverlapSphere(objectPosition, recastObject.ExplosionRadius);

        List<Rigidbody> fragments = new();

        foreach (var hit in hits)
            if (hit.attachedRigidbody != null)
                fragments.Add(hit.attachedRigidbody);

        return fragments;
    }
}
