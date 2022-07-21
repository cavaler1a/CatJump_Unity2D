using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 10f;
    private float _directionMove;
    private Rigidbody2D _playerRb;
    // Сбор монеток
    //private int _jewelCount;
    // Для смены анимаций
    private Animator _playerAnimator;
    private int _state = 0;
    // партикл
    public GameObject _particle;
    // CANVAS
    public Text JewelText;
    private int JewelCount = 0;
    private Camera _mainCamera;
    // Панель проиграша
    public GameObject gameOverPanel;
    public Text gameScore;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        // Для смены анимаций
        _playerAnimator = GetComponent<Animator>();

        // запись в текст
        JewelText = GameObject.Find("Text").GetComponent<Text>();
        JewelText.text = JewelCount.ToString();

        _mainCamera = FindObjectOfType<Camera>();
    }

    void LateUpdate()
    {
        JewelText.text = JewelCount.ToString();
    }

    void Update()
    {
        // для работы в редакторе
        #if UNITY_EDITOR
                _directionMove = Input.GetAxis("Horizontal") * movementSpeed;
        // для работы на телефоне
        #elif UNITY_ANDROID
                _directionMove = Input.acceleration.x * movementSpeed;
        #endif
        // Для смены анимаций
        _playerAnimator.SetInteger("state", _state);

        if (_mainCamera.transform.position.y - transform.position.y > 6)
        {
            // Перезапуск сцены
            // SceneManager.LoadScene(0);

            // Активация панели проиграша
            gameOverPanel.SetActive(true);
            gameScore.text = Convert.ToString(JewelCount);
            // gameScore.text = JewelCount.ToString(); 
        }
    }
    void FixedUpdate()
    {
        Vector2 velocity = _playerRb.velocity;
        velocity.x = _directionMove;
        _playerRb.velocity = velocity;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Platform>() != null)
        {
            if (other.relativeVelocity.y >= 0)
                _state = 0;
            Vector2 position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            Instantiate(_particle, position, Quaternion.identity);
        }
        /*
        if (other.gameObject.GetComponent<JewelScript>() != null)
        {
             JewelCount++;
            Debug.Log(JewelCount);
            JewelText.text = JewelCount.ToString();
            
        }
        */
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Platform>() != null)
            _state = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<JewelScript>() != null)
        {
            JewelCount++;
            //Debug.Log(JewelCount);
            JewelText.text = JewelCount.ToString();

        }
    }
}
