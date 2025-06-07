using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    
    private Button _button;
    private UiButton _uiButton;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _uiButton = GetComponent<UiButton>();
        if (_button)
            _button.onClick.AddListener(PlaySound);
        if(_uiButton)
            _uiButton.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (audioSource)
            audioSource.PlayOneShot(audioClip);
    }
}
