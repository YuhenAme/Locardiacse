using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    public class AudioSystemInstance : SystemInstance<AudioSystemInstance>
    {
        [Header("音效系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {
            //设置属性
            [Header("音乐音量"), Range(0, 1.0f)]
            public float musicVolum = 1.0f;

            [Header("音效音量"), Range(0, 1.0f)]
            public float soundVolum = 1.0f;

            [Header("音乐淡出时间"), Range(0.1f, 2.0f)]
            public float musicFadeOutTime = 1.0f;
        }
        public Setting setting;
    }
}
namespace GameSystem
{
    public static class AudioSystem
    {
        //获取实例
        private static GameSystemInstance.AudioSystemInstance Instance { get { return GameSystemInstance.AudioSystemInstance.Instance; } }
        //获取设置参数
        private static GameSystemInstance.AudioSystemInstance.Setting Setting{ get { return Instance.setting; } }

        private static AudioSource musicSource = null;

        //方法
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="cilp">音效片段</param>
        /// <param name="source">播放源</param>
        public static void Play(AudioClip audio,MonoBehaviour source)
        {
            Instance.StartCoroutine(play(audio, Instance));
        }
        static  IEnumerator play(AudioClip clip,MonoBehaviour source)
        {
            //加上组件
            AudioSource _source = source.gameObject.AddComponent<AudioSource>();
            _source.clip = clip;
            _source.volume = Setting.soundVolum;
            _source.Play();
            yield return new WaitForSeconds(clip.length);
            MonoBehaviour.Destroy(_source);
            yield return 0;
        }
        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="music"></param>
        public static void PlayMusic(AudioClip music)
        {
            Instance.StartCoroutine(playMusic(music));
        }
        static IEnumerator playMusic(AudioClip clip)
        {
            if(musicSource != null)
            {
                float volum = Setting.musicVolum;
                while (volum > 0)
                {
                    musicSource.volume = volum;
                    volum -= Time.deltaTime * Setting.musicFadeOutTime;
                    yield return 0;
                }
                MonoBehaviour.Destroy(musicSource);
            }
            if(clip == null)
            {
                musicSource = null;
            }
            else
            {
                musicSource = Instance.gameObject.AddComponent<AudioSource>();
                musicSource.clip = clip;
                musicSource.volume = Setting.musicVolum;
                musicSource.loop = true;
                musicSource.Play();
            }
            yield return 0;
        }
        /// <summary>
        /// 设置音效音量
        /// </summary>
        /// <param name="v"></param>
        public static void SetSoundVolum(float v)
        {
            Setting.soundVolum = v;
        }
        /// <summary>
        /// 设置音乐音量
        /// </summary>
        /// <param name="v"></param>
        public static void SetMusicVolum(float v)
        {
            Setting.musicVolum = v;
            musicSource.volume = v;
        }
    }
}
