using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniGameBgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obestacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        MiniGameObstacle[] obstacles = GameObject.FindObjectsOfType<MiniGameObstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obestacleCount = obstacles.Length;

        for (int i = 0; i < obestacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obestacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        MiniGameObstacle obstacle = collision.GetComponent<MiniGameObstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obestacleCount);
        }
    }
}