using Assets.Script;
using UnityEngine;

public class AudioMannager : MonoBehaviour
{
    [SerializeField] float musicDuck;
    public static AudioMannager Instance;
    public AudioSource musicAudioSource;
    [SerializeField] AudioSource fxAudioSource;
    [SerializeField] AudioSource uiAudioSource;
    [Header("Game Music")]
    public AudioClip[] arraySound = new AudioClip[7];
    public AudioClip ShopAudio;
    [Header("FX sound")]
    public AudioClip JumpFX;
    public AudioClip AddDificultyFX;
    public AudioClip CoinFX;
    public AudioClip RedCoinFX;
    public AudioClip OpenBarrierFX;
    public AudioClip FailBarrierFX;
    public AudioClip LavaFX;
    public AudioClip CutFX;
    [Header("UI sound")]
    [SerializeField] AudioClip clickUI;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        uiAudioSource.clip = clickUI;
    }

    // Update is called once per frame
    void Update()
    {
        musicAudioSource.volume = StaticOptions.MasterVolume/musicDuck;
        fxAudioSource.volume = StaticOptions.MasterVolume;
        uiAudioSource.volume = StaticOptions.MasterVolume;
    }

    public void PlayMusic(AudioClip music)
    {
        musicAudioSource.loop = true;
        musicAudioSource.clip = music;
        musicAudioSource.Play();

    }
    public void PlayMusic(int musicIndex)
    {
        musicAudioSource.loop = true;
        musicAudioSource.clip = arraySound[musicIndex];
        musicAudioSource.Play();

    }
    public void PlayFX(AudioClip fxSound)
    {
        fxAudioSource.clip = fxSound;
        fxAudioSource.Play();
    }
    public void ClickUI()
    {
        uiAudioSource.volume = StaticOptions.MasterVolume;
        uiAudioSource.Play();
    }
}
