using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectItem : MonoBehaviour
{
    //Variables
    [SerializeField] AudioClip sfx_colleted;
    
    AudioSource itemAudio;

    void Start()
    {
        itemAudio = GetComponent<AudioSource>(); //Reference the AudioSource component
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Check if the player has collected the item
        {
            GetComponent<SpriteRenderer>().enabled = false; //Disable item sprite
            itemAudio.PlayOneShot(sfx_colleted); //Play collected SFX
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //Play Collected Animation

            FindObjectOfType<ItemManager>().AllItemsCollected(); // Call the item manager
            Destroy(gameObject, 0.2f);
        }
    }
}
