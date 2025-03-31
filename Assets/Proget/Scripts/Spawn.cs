using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Cube> _explousionObject;

    private void OnEnable()
    {
        foreach (var item in _explousionObject)
        {
            item.CubeDestroid += Explosion;
        }
    }

    private void Explosion(Cube cube)
    {
        cube.CubeDestroid -= Explosion;
        CalculationSpawn(cube);
    }

    private void CalculationSpawn(Cube cube)
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue < cube.Procent)
        {
            int procent = cube.Procent /= 2;
            cube.transform.localScale *= 0.5f;
            int quantity = Random.Range(1, 6);

            for (int i = 1; i <= quantity; i++)
            {
                SpawnCube(cube, procent);
            }
        }
    }

    private void SpawnCube (Cube cube, int procent)
    {
        Cube ObjectCube = Instantiate(cube);
        ObjectCube.transform.position += Random.insideUnitSphere * 0.1f;
        ObjectCube.Procent = procent;
        ObjectCube.CubeDestroid += Explosion;
    }
}


