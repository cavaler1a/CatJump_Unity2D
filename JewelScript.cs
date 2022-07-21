using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JewelScript : MonoBehaviour
{
    private Camera _mainCamera;
    public GameObject _particle, he;


    private void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (_mainCamera.transform.position.y - transform.position.y > 6)
            Destroy(gameObject);
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerScript>() != null)
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            Instantiate(_particle, position, Quaternion.identity);
            Destroy(gameObject);

        }
        }
    }

