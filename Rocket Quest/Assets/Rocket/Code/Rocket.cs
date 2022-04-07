using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float turnSpeed;

    [SerializeField] private KeyCode _thrust;
    [SerializeField] private KeyCode _turnLeft;
    [SerializeField] private KeyCode _turnRight;

    private Rigidbody2D _rigidBody2D;

    [HideInInspector] ParticleSystem thrustParticles;

    [SerializeField] AudioSource thrustSound;

    [HideInInspector] public bool shouldThrust;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        thrustParticles = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKey(_thrust) || shouldThrust)
        {
            Thrust();
        }
        if (Input.GetKeyUp(_thrust))
        {
            thrustSound.volume = 0;
        }

        if (Input.GetKey(_turnLeft))
        {
            TurnLeft();
        }
        else if (Input.GetKey(_turnRight))
        {
            TurnRight();
        }
    }

    void FixedUpdate()
    {
        if (_rigidBody2D.velocity.magnitude > maxSpeed)
        {
            _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        _rigidBody2D.AddRelativeForce(Vector3.up * acceleration * Time.deltaTime);
        thrustParticles.Emit(1);
        thrustSound.volume = 1;
    }

    void TurnLeft()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime, Space.Self);
    }

    void TurnRight()
    {
        transform.Rotate(0, 0, -turnSpeed * Time.deltaTime, Space.Self);
    }

    public void Explode()
    {
        //ScreenShakeManager.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        SessionManager.Instance.RestartWithDelay();
        Destroy(gameObject);
    }
}
