using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    /*   Мой вариант:
    public new GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3( camera.transform.position.x, camera.transform.position.y, 0);
    }
    */
    // Вариант Робокода:
    public float shiftDistance = 10.5f;
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        Vector3 transformPosition = transform.position;
        if (transformPosition.y - _mainCamera.transform.position.y <= -shiftDistance)
            transformPosition.y = _mainCamera.transform.position.y;
        transform.position = transformPosition;
    }
}
