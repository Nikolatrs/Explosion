using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    private int _minQuantity = 2;
    private int _maxQuantity = 6;
    private int divider = 4;

    private Vector3 CalculatePositionBox(ExplosiveObject recastObject)
    {
        Vector3 position = ColculatePositon(recastObject);
        bool isPositionOccupied = Physics.CheckBox(position, recastObject.transform.lossyScale);

        while (!isPositionOccupied)
        {
            position = ColculatePositon(recastObject);
            isPositionOccupied = Physics.CheckBox(position, recastObject.transform.lossyScale);
        }

        return position;
    }

    public void SpawnFragment(ExplosiveObject recastObject)
    {
        int quantity = Random.Range(_minQuantity, _maxQuantity);
        List<Rigidbody> cubes = new();

        for (int i = 0; i < quantity; i++)
        {
            var position = CalculatePositionBox(recastObject);
            var cubeInst = Instantiate(recastObject, position, recastObject.transform.rotation);
            cubeInst.SetValue(recastObject.Factor);
            cubes.Add(cubeInst.GetComponent<Rigidbody>());
        }

        _exploder.PushingFpragment(cubes, recastObject);
        DestroyObgect(recastObject);
    }

    public void DestroyObgect(ExplosiveObject recastObject)
    {
        Destroy(recastObject.gameObject);
    }

    private Vector3 ColculatePositon(ExplosiveObject recastObject)
    {
        Vector3 position = recastObject.transform.position + Random.insideUnitSphere * recastObject.transform.localScale.x;

        while (position.y < recastObject.transform.localScale.x / divider)
            position = recastObject.transform.position + Random.insideUnitSphere * recastObject.transform.localScale.x;

        return position;
    }
}
