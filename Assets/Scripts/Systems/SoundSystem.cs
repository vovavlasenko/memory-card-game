using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _matchSound;
    [SerializeField] private AudioClip _mismatchSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _revealSound;

    private void OnEnable()
    {
        Card.CardTouched += PlayRevealSound;
    }

    private void OnDisable()
    {
        Card.CardTouched -= PlayRevealSound;
    }

    public void PlayMatchSound()
    {
        _audioSource.PlayOneShot(_matchSound);
    }

    public void PlayMismatchSound()
    {
        _audioSource.PlayOneShot(_mismatchSound);
    }

    public void PlayButtonSound()
    {
        _audioSource.PlayOneShot(_buttonSound);
    }

    public void PlayGameOverSound()
    {
        _audioSource.PlayOneShot(_gameOverSound);
    }

    public void PlayRevealSound()
    {
        _audioSource.PlayOneShot(_revealSound);
    }

}
