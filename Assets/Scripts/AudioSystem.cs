using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音效系统
/// </summary>
public class AudioSystem : MonoBehaviour {

    [Header("音乐音量"),Range(0,1.0f)]
    public float musicVolum = 1.0f;

    [Header("音乐淡出时间"),Range(0.1f,2.0f)]
    public float musicFadeOutTime = 1.0f;

    private AudioSource musicSource = null;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();

    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioClip"></param>
    public void Play(AudioClip audioClip)
    {
        StartCoroutine(play(audioClip));
    }
    IEnumerator play(AudioClip audioClip)
    {
        AudioSource _audioSource = this.gameObject.AddComponent<AudioSource>();

        _audioSource.clip = audioClip;
        _audioSource.volume = musicVolum;
        _audioSource.Play();
        yield return new  WaitForSeconds(audioClip.length);
        Destroy(_audioSource);
        yield return 0;
    }

    /// <summary>
    /// 播放音乐
    /// </summary>
    /// <param name="audioClip"></param>
    public void PlayMusic(AudioClip audioClip)
    {
        StartCoroutine(playMusic(audioClip));
    }
    IEnumerator playMusic(AudioClip audioClip)
    {
        if(musicSource != null)
        {
            //将已有的bgm淡出
            float volum = musicVolum;
            while (volum > 0)
            {
                musicSource.volume = volum;
                volum -= Time.deltaTime * musicFadeOutTime;
                yield return 0;
            }
            Destroy(musicSource);
        }

        if(audioClip == null)
        {
            musicSource = null;
        }
        else
        {
            musicSource = this.gameObject.AddComponent<AudioSource>();
            musicSource.clip = audioClip;
            musicSource.volume = musicVolum;
            musicSource.loop = true;
            musicSource.Play();
        }

        yield return 0;
    }
    
    /// <summary>
    /// 获取到音乐片段
    /// </summary>
    /// <param name="clipName"></param>
    /// <returns></returns>
    public AudioClip GetAudioClip(string clipName)
    {
        return Resources.Load<AudioClip>(clipName);
    }


}
