using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class TriggerForBreathalyzer : MonoBehaviour
{    
    [Header("Колличество секунд для того что бы подуть в алкотестер")]
    [SerializeField] private int _sec;
    [Header("Установить ссылку на индикатор заполнения прогресса алкотестера")]
    [SerializeField] private Image _fulled;
    [Header("Установить ссылку на UI индикатора")]
    [SerializeField] private GameObject _indicator;
    [Header("Источник звука")]
    [SerializeField] private AudioSource _audioSource;
    [Header("Звук выдоха")]
    [SerializeField] private AudioClip _breathAudioClip;

    private const string NAME_BREATHALYZER = "Breathalyzer";
    private float _currentSeconds;
    private UnityEvent _breathingIntoTubeComplete = new UnityEvent();
    private Collider _collider;
    public UnityEvent BreathingIntoTubeComplete { get => _breathingIntoTubeComplete; }

    private void Awake() => _collider = GetComponent<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == NAME_BREATHALYZER)
        {
            _indicator.gameObject.SetActive(true);
            _audioSource.clip = _breathAudioClip;
            _audioSource.Play();
        }
    }
    private void OnTriggerStay(Collider other) { if(other.name == NAME_BREATHALYZER) Fulled(); }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == NAME_BREATHALYZER)
        {
            _indicator.gameObject.SetActive(false);
            _audioSource.Stop();
            _currentSeconds = 0;
        }
    }

    public void Fulled() { 
        _currentSeconds += 1 * Time.deltaTime;
        _fulled.fillAmount = Mathf.Clamp(_currentSeconds * 1 / _sec, 0, _sec);
        if (_currentSeconds >= _sec) { 
            _collider.enabled = false;
            _indicator.gameObject.SetActive(false);
            _breathingIntoTubeComplete?.Invoke();
        } 
    }   
}
