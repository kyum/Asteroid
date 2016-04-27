using UnityEngine;
using System.Collections;

public class bolt_move : MonoBehaviour
{
    public float speed;
    public GameObject meteor_med;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnBecameInvisible() { Destroy(gameObject); }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == meteor_med.name)
        {
            Destroy(collision.gameObject);
        }
    }
}