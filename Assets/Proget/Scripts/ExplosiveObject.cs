using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ExplosiveObject : MonoBehaviour
{
    private Renderer _renderer;
    private int _factorProcent = 2;
    private int _factorForse = 2;
    private int _factorTransform = 2;

    [field: SerializeField] public float ExplosionRadius { get; private set; } = 10;
    [field: SerializeField] public float ExplosionForse { get; private set; } = 300;
    [field: SerializeField] public int Procent { get; private set; } = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetValue()
    {
        Procent /= _factorProcent;
        transform.localScale /= _factorTransform;
        ExplosionRadius *= _factorForse;
        ExplosionForse *= _factorForse;
    }
}
