using UnityEngine;
using System.Collections;

public class meteor_md : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "shot")
        {
            Destroy(collision.gameObject);
        }
    }
}