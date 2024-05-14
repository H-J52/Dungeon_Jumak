using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private PlayerServing playerServing;

    private void Start()
    {
        playerServing = GetComponent<PlayerServing>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Gukbab"))
        {
            playerServing.PickUpGukBab(other.gameObject);
        }
        else if (other.gameObject.tag.Contains("Pajeon"))
        {
            playerServing.PickUpPajeon(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Table_L"))
        {
            playerServing.PlaceFoodOnTable(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Table_R"))
        {
            playerServing.PlaceFoodOnTable(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Trash"))
        {
            playerServing.ThrowAwayFood();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }

}