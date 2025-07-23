using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    public event Action<ExplosiveObject> HitObject;

    private void OnEnable()
    {
        _inputReader.LeftClicked += LeftClicked;
    }

    private void OnDisable()
    {
        _inputReader.LeftClicked -= LeftClicked;
    }

    private void LeftClicked()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            if (hit.transform.TryGetComponent(out ExplosiveObject entityExcption))
            {
                HitObject?.Invoke(entityExcption);
            }
    }
}
