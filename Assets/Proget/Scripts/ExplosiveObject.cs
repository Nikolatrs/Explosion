using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ExplosiveObject : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public int Factor { get; private set; } = 2;
    public float ExplosionRadius { get; private set; } = 10;
    public float ExplosionForse { get; private set; } = 300;
    public int Procent { get; private set; } = 100;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetValue(int factor)
    {
        Procent /= factor;
        transform.localScale /= factor;
        ExplosionRadius *= factor;
        ExplosionForse *= factor;

        Factor = factor * 2;
    }
}
