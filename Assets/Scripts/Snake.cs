using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    public float speed = 40f;
    private int score = 0;

    public Text scoreText;
    public AudioClip bitingAnApple2Sec;
    private AudioSource audioSource;
    void Start()
    {
        Debug.Log("Game Started!");
        UpdateScoreText();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
            transform.Translate(movement * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -7f);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Debug.Log("Collision detected with Food");
            Destroy(collision.gameObject);
            score++;
            UpdateScoreText();
            Debug.Log("Score updated to: " + score);

            if (bitingAnApple2Sec != null && audioSource != null)
            {
                Debug.Log("Playing sound...");
                audioSource.PlayOneShot(bitingAnApple2Sec);
            }
            else
            {
                Debug.LogError("AudioClip or AudioSource is null!");
            }
        }
    }


    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
