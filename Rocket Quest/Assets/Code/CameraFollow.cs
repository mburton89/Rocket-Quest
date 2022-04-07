using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector2 rbVelocity = target.GetComponent<Rigidbody2D>().velocity;
        Vector3 velocity = new Vector3(rbVelocity.x, rbVelocity.y, 0f);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }

}