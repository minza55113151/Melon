using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager instance;
    [SerializeField] private GameObject[] ballPrefabs;
    private void Awake()
    {
        instance = this;
    }

    public void BallHit(GameObject ball1, GameObject ball2)
    {
        if (ball1 == null || ball2 == null)
        {
            Debug.Log("NULL!!");
            return;
        }
        Vector3 spawnPoint = ball1.transform.position;
        int level = ball1.GetComponent<Ball>().id;
        ball1.GetComponent<Ball>().Destroy(spawnPoint);
        ball2.GetComponent<Ball>().Destroy(spawnPoint);
        StartCoroutine(SpawnBall(level, spawnPoint));        
    }
    private IEnumerator SpawnBall(int level, Vector3 spawnPoint)
    {
        yield return new WaitForSeconds(0.1f);
        GameObject ball = Instantiate(ballPrefabs[level], spawnPoint, Quaternion.identity);
        ball.GetComponent<Ball>().ballDeploy();
    }
}
