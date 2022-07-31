using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int id;
    private void Start()
    {
        Vector3 target = transform.localScale;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartCoroutine(Scale(transform.localScale, target, 0.1f));
        GameManager.instance.AddScore(id);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (collision.gameObject.GetComponent<Ball>().id == id)
            {
                if (GetComponent<Rigidbody2D>().velocity.magnitude < collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
                {
                    BallManager.instance.BallHit(gameObject, collision.gameObject);
                }
            }
        }
    }
    public void Destroy(Vector3 pos)
    {
        //disable collider
        GetComponent<CircleCollider2D>().enabled = false;
        //destroy rb
        Destroy(GetComponent<Rigidbody2D>());
        //scale
        StartCoroutine(Scale(transform.localScale, Vector3.zero, 0.1f));
        //move
        StartCoroutine(Position(transform.position, pos, 0.1f));
        Invoke("DestroyDelay", 0.1f);
        
    }
    private void DestroyDelay()
    {
        Destroy(gameObject);
    }
    private IEnumerator Scale(Vector3 a, Vector3 b, float t)
    {
        float time = 0f;
        while(time < t)
        {
            transform.localScale = Vector3.Lerp(a, b, time / t);
            time += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator Position(Vector3 a, Vector3 b, float t)
    {
        float time = 0f;
        while (time < t)
        {
            transform.position = Vector3.Lerp(a, b, time / t);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
