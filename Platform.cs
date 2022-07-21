using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    private Camera _mainCamera;
    public GameObject _particle;
    private void Start()
    { 
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (_mainCamera.transform.position.y - transform.position.y > 6)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.relativeVelocity.y <= 0f){
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null) {
                playerRb.velocity = Vector2.up*jumpForce;
                Vector2 position = new Vector2(other.transform.position.x, other.transform.position.y - 0.5f);
                Instantiate(_particle, position, Quaternion.identity);
                Destroy(gameObject, 5f);
            }
        }
        
    }
}
