using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject creditsMenuCanvas;
    [SerializeField] AudioClip sfx_confirm;
    [SerializeField] AudioClip sfx_cancel;

    AudioSource menuAudio;

    private void Start()
    {
        menuAudio = GetComponent<AudioSource>(); //Reference the AudioSource component
    }

    //Main Menu controls
    public void DisplayCredits()
    {
        menuAudio.PlayOneShot(sfx_confirm);
        mainMenuCanvas.SetActive(false);
        creditsMenuCanvas.SetActive(true);
    }

    public void DisplayMainMenu()
    {
        menuAudio.PlayOneShot(sfx_cancel);
        mainMenuCanvas.SetActive(true);
        creditsMenuCanvas.SetActive(false);
    }


    //Win and Game Over Scenes Controls
    public void PlayGame()
    {
        menuAudio.PlayOneShot(sfx_confirm);
        SceneManager.LoadScene("Level1");
    }

    public void BackToMainMenu()
    {
        menuAudio.PlayOneShot(sfx_cancel);
        SceneManager.LoadScene("MainMenu");
    }
}
