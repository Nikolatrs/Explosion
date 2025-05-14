using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ExplosiveObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private int _dividerProcent = 2;
    private int _dividerScale = 2;

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
    }
}
