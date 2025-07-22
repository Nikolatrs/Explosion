using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void PushingFpragment(ExplosiveObject recastObject, float radius, float forse)
    {
        Vector3 objectPosition = recastObject.transform.position;
        Collider[] fragments = Physics.OverlapSphere(objectPosition, recastObject.ExplosionRadius);

        foreach (var fragment in fragments)
            if (fragment.attachedRigidbody != null)
                fragment.attachedRigidbody.AddExplosionForce(recastObject.ExplosionForse, objectPosition, recastObject.ExplosionRadius);
    }
}
