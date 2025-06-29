using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ExplosiveObject : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForse;

    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private int _dividerProcent = 2;
    private int _dividerScale = 2;

    private int _factor = 2;

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

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void SetValue(int procentPerent)
    {
        procentPerent /= _dividerProcent;
        Procent = procentPerent;
        transform.localScale /= _dividerScale;

        _explosionRadius *= _factor;
        _explosionForse *= _factor;
    }

    public void PushingFpragment()
    {
        Collider[] fragments = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var fragment in fragments)
            if (fragment.attachedRigidbody != null)
                fragment.attachedRigidbody.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
    }

}
