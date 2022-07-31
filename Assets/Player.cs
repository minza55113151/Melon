using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private GameObject[] ballPrefabs;

    private Camera cam;
    private Vector3 mainPosition;
    private GameObject ball;

    private void Awake()
    {
        instance = this;
        cam = Camera.main;
        mainPosition = transform.position;
    }
    private void Start()
    {
        SpawnBall();
    }
    private void Update()
    {
        if (GameManager.instance.isGameOver)
            return;
        if (Input.GetMouseButton(0))
        {
            //set pos by mouse press
            Vector3 mousePos = Input.mousePosition;
            Vector3 mousePosInWorld = cam.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(mousePosInWorld.x, transform.position.y, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //deploy ball
            DeployBall();
            
            //set pos back
            transform.position = mainPosition;
            
            //create new ball
            SpawnBall();
        }
    }
    private void SpawnBall()
    {
        ball = Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], transform.position, Quaternion.identity, transform);
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        ball.GetComponent<CircleCollider2D>().enabled = false;
    }
    private void DeployBall()
    {
        ball.transform.parent = null;
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        ball.GetComponent<CircleCollider2D>().enabled = true;
    }
}
