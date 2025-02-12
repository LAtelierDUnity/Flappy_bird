using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource _audioSourceDeadSound;
    [SerializeField]
    private AudioSource _audioSourceFlySound;
    [SerializeField]
    private AudioSource _audioSourceWinPointSound;
    [SerializeField]
    private AudioClip _soundHit;
    [SerializeField]
    private AudioClip _soundDead;
    [SerializeField]
    private AudioClip _soundWinPoint;
    [SerializeField]
    private AudioClip _soundFly;
    [SerializeField]
    private AudioClip _soundLoadScene;



    private void Awake()
    {
        instance = this;
    }


    public IEnumerator PlayDeadSound()
    {
        _audioSourceDeadSound.clip = _soundHit;
        _audioSourceDeadSound.Play();

        yield return new WaitForSeconds(_soundHit.length);

        _audioSourceDeadSound.clip = _soundDead;
        _audioSourceDeadSound.Play();

    }
    public void PlayFlySound()
    {
        _audioSourceFlySound.clip = _soundFly;
        _audioSourceFlySound.Play();
    }

    public void PlayWinpointSound()
    {
        _audioSourceWinPointSound.clip = _soundWinPoint;
        _audioSourceWinPointSound.Play();
    }

    public void PlayLoadSoundScene()
    {
        _audioSourceDeadSound.clip = _soundLoadScene;
        _audioSourceDeadSound.Play();
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
    }
}
