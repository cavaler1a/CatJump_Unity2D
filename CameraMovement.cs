using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 100f;
    private Transform _target;
    void Start()
    {
        _target = FindObjectOfType<PlayerScript>().GetComponent<Transform>();
    }
    void Update()
    {
        if (_target.position.y > gameObject.transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            gameObject.transform.position = Vector3.Lerp(transform.position, newPos, speed);
        }
    }
}
