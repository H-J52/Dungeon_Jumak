using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    [SerializeField]
    private GameObject grandmaSpeechBox;

    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private string cookingSound;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        PlayCookingSound();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grandmaSpeechBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grandmaSpeechBox.SetActive(false);
    }

    //---cookingSound ���� �Լ�---//
    private void PlayCookingSound()
    {
        if (!audioManager.IsPlaying(cookingSound))
        {
            audioManager.Play(cookingSound);
            audioManager.SetLoop(cookingSound);
            audioManager.Setvolume(cookingSound, 0.2f);
        }
    }
}
