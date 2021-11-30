using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip gameOverSound;

    //public AudioClip jumpSound;

    public AudioClip carSound;
    public float jumpForce;
    public float gravity;
    public bool isOnGround = true;

    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.down * gravity;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameOver == false)
        {
            gameOver = true;
            DoGameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAudio.PlayOneShot(carSound, 0.1f);
        }
        else if (collision.gameObject.CompareTag("Obstacle") && gameOver == false)
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1f);
            explosionParticle.Play();
            Invoke("DoGameOver", 0.3f);
        }
    }

    private void DoGameOver()
    {
        playerAudio.PlayOneShot(gameOverSound);
        GameObject.Find("Canvas").GetComponent<MenuManager>().OpenMenu();
        int score = GameObject.Find("Score Text").GetComponent<Scoring>().Score;
        if (score != 0)
        {
            string name = SettingsManager.GetPlayerName();
            HighScoreManager.AddScoreToFile(score, name);
        }
    }
}
