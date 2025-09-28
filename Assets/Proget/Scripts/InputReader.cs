using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftClicked;

    private int _leftMouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
            LeftClicked?.Invoke();
    }
}
