using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMovement : MonoBehaviour
{
    // Variables
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    public float minSpeed;
    public float maxSpeed;

    private float speed;

    public float secondsToMaxDifficulty;

    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Move to random place
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }
    Vector2 GetRandomPosition()
    {
        // Get random position on screen
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxX);
        return new Vector2(randomX, randomY);
    }
    
    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
