using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    [SerializeField] public Image muteButtonImage;
    [SerializeField] public Sprite muteSprite;
    [SerializeField] public Sprite unmuteSprite;
    private bool isMuted;
    // Start is called before the first frame update
    void Start()
    {
        isMuted = audioSource.mute;

    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        // Modifier l'image du bouton en fonction de l'état de sourdine
        muteButtonImage.sprite = isMuted ? muteSprite : unmuteSprite;
    }
}
