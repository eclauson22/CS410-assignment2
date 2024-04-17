using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    public GameEnding gameEnding;

    // Added
    public GameObject explosionParticleEffect;
    // public AudioSource explosionAudio;

    public float turnSpeed = 20f;
    public float moveSpeed = 5f; // added this, move speed can also be modified later by the linear interpolation factor

    public GameObject gameOverScreen;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    float m_Timer;
    bool m_IsMoving;
    bool isGameOver = false;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }

            m_IsMoving = true;
            m_Timer = 0f;
        }
        else
        {
            m_AudioSource.Stop ();
            m_IsMoving = false;

            m_Timer += Time.deltaTime;

            if (m_Timer >= 5.0f && !isGameOver && !m_IsMoving)
            {
                isGameOver = true;
                ExplodePlayer();
                // gameEnding.CaughtPlayer();
            }

            
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        //need to calculate a target position to linear interpolate between target and current
        Vector3 targetPosition = transform.position + m_Movement * moveSpeed * Time.deltaTime;

        //the actual interpolation:
        m_Rigidbody.MovePosition(Vector3.Lerp(transform.position, targetPosition, 0.5f)); //0.5 is the linear interpolation factor, rn it takes the target destination, and gives you half of the vector needed to get there, halving your speed
        m_Rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, m_Rotation, 0.5f));
    }

    // CREDIT: help with ExplodePlayer and IENumerator functionality from ChatGPT
    void ExplodePlayer()
    {
        // instantiate explosion particle effect
        GameObject explosion = Instantiate(explosionParticleEffect, transform.position, Quaternion.identity);

        // get the duration of particle effect
        float particleDuration = explosion.GetComponent<ParticleSystem>().main.duration;

        // call game ending after particle effect finishes
        StartCoroutine(DelayedGameOver(particleDuration));
    }

    IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);

        // call game ending after particle effect finishes
        gameEnding.CaughtPlayer();
    }

    void OnAnimatorMove ()
    {
        // fixed with linear interpolation
    }
}