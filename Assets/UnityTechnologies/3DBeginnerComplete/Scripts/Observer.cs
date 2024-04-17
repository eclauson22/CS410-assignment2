using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// have sound play in larger radius 

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    //public float detectionRadius = 5.0f; //how far away the enemy will be able to detect
    public float detectionAngle = 90.0f;
    //bool m_IsPlayerInRange;
    public AudioSource explosionAudio;


    /*void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }*/



    void Update ()
    {/*
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if (Physics.Raycast (ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer ();
                }
            }
        }*/
        LookForPlayer();

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    // Restart the game when the R key is pressed
        //    gameManager.RestartGame();
        //}
    }

    void LookForPlayer()
    {
        Vector3 enemyPosition = transform.position;
        Vector3 toPlayer = player.position - enemyPosition;

        toPlayer.y = 0;

        if (toPlayer.magnitude <= 1) // the number is how far away the enemy detects the player
        {
            if (Vector3.Dot(toPlayer.normalized, transform.forward) > Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
            {
            gameEnding.CaughtPlayer();
            }
        }

        else if (toPlayer.magnitude <= 3) // the number is how far away the enemy detects the player
        {
            if (Vector3.Dot(toPlayer.normalized, transform.forward) > Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
            {
                // Play noise
                if (explosionAudio != null)
                {
                    explosionAudio.Play();
                    
                }
                Debug.Log("TEST");
            }
        }
    }
}

