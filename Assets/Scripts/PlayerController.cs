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

    public float jumpForce;
    public float gravity; // Periaatteessa turha
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
        if (playerAudio.time > 3.4f + Random.Range(-0.1f, 0.1f))
        {
            playerAudio.time = 0.5f + Random.Range(-0.1f, 0.1f);
        }

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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") && gameOver == false)
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 4f);
            explosionParticle.Play();
            Invoke("DoGameOver", 0.65f);
        }
    }

    private void DoGameOver()
    {
        playerAudio.PlayOneShot(gameOverSound, 4f);
        GameObject.Find("Canvas").GetComponent<MenuManager>().OpenMenu();
        int score = GameObject.Find("Score Text").GetComponent<Scoring>().Score;
        if (score != 0)
        {
            string name = SettingsManager.GetPlayerName();
            HighScoreManager.AddScoreToFile(score, name);
        }
    }
}
