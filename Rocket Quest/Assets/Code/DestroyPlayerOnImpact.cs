using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerOnImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rocket>())
        {
            collision.gameObject.GetComponent<Rocket>().Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rocket>())
        {
            collision.gameObject.GetComponent<Rocket>().Explode();
        }
    }
}
