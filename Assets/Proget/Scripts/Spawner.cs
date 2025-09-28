using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _minQuantity = 2;
    private int _maxQuantity = 6;
    private int _scaleFactor = 2;

    public void CreationFragment(ExplosiveObject recastObject)
    {
        int quantity = Random.Range(_minQuantity, _maxQuantity);
        List<Vector3> shiftVectors = new List<Vector3>(8)
        {
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f)
        };

        List<Rigidbody> listCubes = new();

        for (int i = 0; i < quantity; i++)
        {
            Vector3 shirt = shiftVectors[Random.Range(0, shiftVectors.Count - 1)];
            Vector3 positionCube = recastObject.transform.position + ((shirt) * (recastObject.transform.localScale.x / _scaleFactor));
            shiftVectors.Remove(shirt);
            var cubeInst = Instantiate(recastObject, positionCube, recastObject.transform.rotation);
            cubeInst.SetValue();
            listCubes.Add(cubeInst.GetComponent<Rigidbody>());
        }

        foreach (var fragment in listCubes)
            fragment.AddExplosionForce(recastObject.ExplosionForse, recastObject.transform.position, recastObject.ExplosionRadius);

        DestroyObgect(recastObject);
    }

    public void DestroyObgect(ExplosiveObject recastObject)
    {
        Destroy(recastObject.gameObject);
    }
}
