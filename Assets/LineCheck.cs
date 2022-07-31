using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCheck : MonoBehaviour
{
    public float timeOut = 3f;

    float time = 0f;
    SpriteRenderer sr;

    int inLine = 0;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            inLine++;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            time += Time.deltaTime;
        }
        if (time > 3f)
        {
            GameManager.instance.GameOver();
        }
        sr.color = new Color(255f, 0f, 0f, time / timeOut);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            inLine--;
        }
        if (inLine == 0)
        {
            time = 0f;
            sr.color = new Color(255f, 0f, 0f, time / timeOut);
        }
        
    }
}
