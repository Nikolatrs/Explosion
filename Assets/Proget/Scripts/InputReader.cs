using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftClicked?.Invoke();
    }
}
