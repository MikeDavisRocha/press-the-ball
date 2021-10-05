using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallColor {
    Blue,
    Green,
    LightBlue,
    Orange,
    Pink,
    Purple,
    Red,
    Yellow    
}

public class Ball : MonoBehaviour
{
    public BallColor ballColor = BallColor.Red;

    private BallSpawner ballSpawner;
    private ScoreManager scoreManager;
    private TimerManager timerManager;
        
    private Rigidbody2D rb;
    private Vector3 direction;
    public float moveSpeed = 20f;
    private int initialXDirection = 10, initialYDirection = 10;
    private float minRandomValue = 1.1f, maxRandomValue = 1.2f;

    private void Awake()
    {
        ballSpawner = GameObject.FindObjectOfType<BallSpawner>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        timerManager = GameObject.FindObjectOfType<TimerManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        direction = new Vector3(initialXDirection, initialYDirection, 0);
        rb.velocity = direction * moveSpeed;
    }

    public void CheckAnswer(Ball ball)
    {
        SoundManager.instance.PlayTapOnBallSound();
        //SoundManager.instance.Vibration();
        if (ballSpawner.GetTheCorrectAnswer().ballColor == ball.ballColor)
        {
            if (ballSpawner.DecreaseTotalBallToPress() == 0)
            {
                scoreManager.AddScore();
                SoundManager.instance.PlayHitOneScoreSound();
                if (scoreManager.GetScore() % 5 == 0)
                {
                    ballSpawner.IncreaseMaxBall();
                    minRandomValue += 0.1f;
                    maxRandomValue += 0.1f;
                }
                SoundManager.instance.StopFiveSecondsLeftAudio();
                scoreManager.SaveScore();
                ballSpawner.RemoveWrongBalls();
                ballSpawner.CreateRandomBalls();
                timerManager.ResetTime();
                SoundManager.instance.isLastFiveSecondsRunning = false;
            }
        }
        else
        {
            scoreManager.SaveScore();
            scoreManager.SaveHighScore();
            SoundManager.instance.StopFiveSecondsLeftAudio();
            LevelManager.instance.LoadLoseScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            float randoness = Random.Range(minRandomValue, maxRandomValue);
            Vector2 wallNormal = other.contacts[0].normal;
            direction = Vector2.Reflect(rb.velocity, wallNormal).normalized;
            direction = new Vector3(direction.x * randoness, direction.y * randoness, direction.z);
            rb.velocity = direction * Mathf.Pow(moveSpeed, 2);            
        }
    }
}
