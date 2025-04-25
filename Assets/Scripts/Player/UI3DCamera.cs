using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class UI3DCamera : MonoBehaviour
{
    private Camera _camera,_mainCamera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _mainCamera = Camera.main;

    }
    
    private void FixedUpdate()
    {
        _camera.fieldOfView = _mainCamera.fieldOfView;
    }
}
