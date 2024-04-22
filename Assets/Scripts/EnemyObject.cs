using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the player has collided with the object
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(collision.gameObject, 0.2f); //Destroy player gameobject
            SceneManager.LoadScene("GameOverMenu"); //Loads Game Over scene
        }
    }
}
