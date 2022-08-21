using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCheck : MonoBehaviour
{
    public float timeOut;

    float time = 0f;
    SpriteRenderer sr;

    int inLine = 0;

    List<GameObject> colliderBall;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        colliderBall = new List<GameObject>();
    }

    private void Update()
    {
        if (colliderBall.Count == 0)
        {
            time = 0f;
        }
        else
        {
            bool isplus = true;
            for (int i = 0; i < colliderBall.Count; i++)
            {
                if (colliderBall[i].GetComponent<Rigidbody2D>().velocity.magnitude > 0.5f || colliderBall[i].GetComponent<Ball>().newSpawn)
                {
                    isplus = false;
                    break;
                }
            }
            if (isplus)
            {
                time += Time.deltaTime;
            }
        }
        if (time > timeOut)
        {
            GameManager.instance.GameOver();
        }
        sr.color = new Color(255f, 0f, 0f, time / timeOut);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //add ball to colliderBall
            colliderBall.Add(collision.gameObject);
        }
    }
/*    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            time += Time.deltaTime;
        }
*//*        if (time > timeOut)
        {
            GameManager.instance.GameOver();
        }
        sr.color = new Color(255f, 0f, 0f, time / timeOut);*//*
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            colliderBall.Remove(collision.gameObject);
        }
/*        if (inLine == 0)
        {
            time = 0f;
            sr.color = new Color(255f, 0f, 0f, time / timeOut);
        }*/
        
    }
}
