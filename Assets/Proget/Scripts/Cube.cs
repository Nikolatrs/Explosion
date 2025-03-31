using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{

    public int Procent { get; set; } = 100;
    public Rigidbody Rigidbody { get; set; }

    public event Action<Cube> CubeDestroid;

    private void Awake()
    {
        RandomColor();
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnMouseUpAsButton()
    {
        CubeDestroid?.Invoke(this);
        Destroy(gameObject);
    }

    private void RandomColor()
    {
        var color = Random.ColorHSV();
        var cubeRenderer = this.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", color);
    }
}
