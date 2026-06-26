using System;
using System.Collections;
using System.Collections.Generic;
using Cradle.Players;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    // Audio players components.
    [HideInInspector] public AudioSource EffectsSource;
    [HideInInspector] public AudioSource MusicSource;
    [HideInInspector] public AudioSource ClickSource;
    [HideInInspector] public AudioSource MayorSource;
    [HideInInspector] public AudioSource BankLibrarySource;
    [HideInInspector] public AudioSource PopupAudioSource;
    [HideInInspector] public AudioSource EndGameAudioSource;
    [HideInInspector] public AudioSource VOSource;
    public AudioClip thunderVoxStoryClip;

    [HideInInspector]
    public Slider volumeSlider, musicSlider, volumeSliderPause, musicSliderPause;
    [HideInInspector]
    public Slider volumeSliderPauseHub, musicSliderPauseHub;

    [HideInInspector] public float _music = 1, _volume = 1;

    private IEnumerator VOEffects = null;
    private AudioClip VOTempClip = null;

    // Initialize the instance.
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        _volume = PlayerPrefs.GetFloat("volume", 1);
        _music = PlayerPrefs.GetFloat("Music", 1);
        volumeSlider.value = _volume;
        musicSlider.value = _music;
        volumeSliderPause.value = _volume;
        musicSliderPause.value = _music;
        volumeSliderPauseHub.value = _volume;
        musicSliderPauseHub.value = _music;
    }

    private void OnEnable()
    {
        PassageTracker.s_OnPlayVO += OnVOPlayOneTime;
        PassageTracker.s_OnStopVO += OnVOStop;
        TwineTMProLinkHandler.s_OnClickSFX += OnPlayClickToContinue;
    }

    private void OnDisable()
    {
        PassageTracker.s_OnPlayVO -= OnVOPlayOneTime;
        PassageTracker.s_OnStopVO -= OnVOStop;
        TwineTMProLinkHandler.s_OnClickSFX -= OnPlayClickToContinue;
    }

    public void OnPlayClickToContinue() => ClickSource.Play();

    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.loop = true;
        EffectsSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }
    public void Stop() => EffectsSource.Stop();
    public void StopMusic() => MusicSource.Stop();

    public void PlayOneTime(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.loop = false;
        EffectsSource.Play();
    }

    public void OnVOPlayOneTime(AudioClip clip)
    {
        if (!VOSource.isPlaying)
        {
            //VOSource.clip = clip;
            //VOSource.Play();
            VOTempClip = clip;
            if (VOEffects != null)
                StopCoroutine(VOEffects);
            VOEffects = Delay(clip);
            StartCoroutine(VOEffects);
        }

    }
    IEnumerator Delay(AudioClip _clip)
    {
        ViewGenerationEnding.S_OnScroll?.Invoke(_clip.length);
        VOSource.clip = thunderVoxStoryClip;
        VOSource.Play();
        yield return new WaitForSeconds(4.5f);
        ViewGenerationEnding.instance.endingScrollBar.value = 1;
        VOSource.Stop();
        VOSource.clip = _clip;
        VOSource.Play();
    }

    public void OnVOStop()
    {
        if (VOSource.isPlaying)
        {
            VOSource.Stop();
            VOTempClip = null;
            if (VOEffects != null)
                StopCoroutine(VOEffects);
        }
    }

    public void OnVOPause()
    {
        if (VOSource.isPlaying)
        {
            VOSource.Pause();
            if (VOEffects != null)
                StopCoroutine(VOEffects);
        }
    }

    public void OnVOResume()
    {
        if (!VOSource.isPlaying)
        {
            if (VOSource.clip == thunderVoxStoryClip && VOTempClip != null)
            {
                VOSource.clip = VOTempClip;
                VOSource.Play();
            }
            else
                VOSource.UnPause();
        }
    }

    public void OnOpenPopupPlayAudio(AudioClip clip)
    {
        PopupAudioSource.clip = clip;
        PopupAudioSource.loop = false;
        PopupAudioSource.Play();
    }

    public void OnClosePopupStopAudio() => PopupAudioSource.Stop();

    public void OnsliderChange(Slider volume)
    {
        volumeSlider.value = volume.value;
        volumeSliderPause.value = volume.value;
        volumeSliderPauseHub.value = volume.value;
        AudioListener.volume = volume.value;
        _volume = volume.value;
    }
    public void OnMusicsliderChange(Slider volume)
    {
        musicSlider.value = volume.value;
        musicSliderPause.value = volume.value;
        musicSliderPauseHub.value = volume.value;
        MusicSource.volume = volume.value;
        _music = volume.value;
    }

    public void PlayAudioSource(AudioSource As) => As.Play();

    public void OnConfirmation()
    {
        PlayerPrefs.SetFloat("Music", _music);
        PlayerPrefs.SetFloat("volume", _volume);
    }

    public void OnReturnToTitleBtn()
    {
        _volume = PlayerPrefs.GetFloat("volume", 1);
        _music = PlayerPrefs.GetFloat("Music", 1);
        volumeSlider.value = _volume;
        volumeSliderPause.value = _volume;
        volumeSliderPauseHub.value = _volume;
        AudioListener.volume = _volume;
        musicSlider.value = _music;
        musicSliderPause.value = _music;
        musicSliderPauseHub.value = _music;
        MusicSource.volume = _music;
    }
}