using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    float movementSpeed;

    public void Init(Vector3 newDirection, float newMovementSpeed)
    {
        direction = newDirection;
        movementSpeed = newMovementSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}
