using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BallSpawner : MonoBehaviour
{
    int minBallsToPress = 1;
    int maxBalls = 5;
    public GameObject[] ballsToPressPrefab;
    public List<Ball> ballsInGamePrefab;
    private BallToPress ballToPress;
    public RectTransform ballsInGameTransform;
    int totalBallsToPress;


    private void Start()
    {
        CreateRandomBalls();
    }    

    public void CreateRandomBalls()
    {
        // Create a random number of balls between 3 and 5;
        totalBallsToPress = Random.Range(minBallsToPress, maxBalls + 1);
        int totalBallNotToPress = maxBalls - totalBallsToPress;

        int indexBallToPress = Random.Range(0, ballsToPressPrefab.Length);
 
        DeactivateAllBallsToPress();
        ActivateTheSortedBall(indexBallToPress);

        for (int i = 0; i < totalBallsToPress; i++)
        {
            Ball ball = Instantiate(ballsInGamePrefab[indexBallToPress], ballsInGameTransform, false);
            ball.transform.localPosition = new Vector3(Random.Range(0, ballsInGameTransform.rect.width), Random.Range(0, ballsInGameTransform.rect.height), 0);
        }

        var ballsNotToPress = ballsInGamePrefab.Where(ball => ball.ballColor != ballToPress.ballColor);
        
        for(int i = 0; i < totalBallNotToPress; i++)
        {
            Ball[] balls = ballsNotToPress.ToArray();
            int indexBallNotToPress = Random.Range(0, balls.Length);
            Ball ball = Instantiate(balls[i], ballsInGameTransform, false);
            ball.transform.localPosition = new Vector3(Random.Range(0, ballsInGameTransform.rect.width), Random.Range(0, ballsInGameTransform.rect.height), 0);
        }
    }
    
    public int DecreaseTotalBallToPress()
    {
        return --totalBallsToPress;
    }

    public void IncreaseMaxBall()
    {
        maxBalls++;
    }
    
    public void RemoveWrongBalls()
    {
        foreach (Transform ballTransform in ballsInGameTransform)
        {
            ballTransform.gameObject.SetActive(false);
        }
    }

    public BallToPress GetTheCorrectAnswer()
    {
        return ballToPress.GetComponent<BallToPress>();
    }

    private BallToPress ReturnBallToPress(GameObject ballToPress)
    {
        return ballToPress.GetComponent<BallToPress>();
    }

    private void ActivateTheSortedBall(int indexBallToPress)
    {
        for (int i = 0; i < ballsToPressPrefab.Length; i++)
        {
            if (i == indexBallToPress)
            {
                ballsToPressPrefab[i].SetActive(true);
                ballToPress = ReturnBallToPress(ballsToPressPrefab[i]);                
            }
        }
    }

    private void DeactivateAllBallsToPress()
    {
        for (int i = 0; i < ballsToPressPrefab.Length; i++)
        {
            ballsToPressPrefab[i].SetActive(false);
        }
    }
}
