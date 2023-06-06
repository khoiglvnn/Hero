using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.Storage;

public class AudioManager : BaseManager<AudioManager> 
{
    private const string BGM_VOLUME_KEY = "BGM_VOLUME_KEY";
    private const string SE_VOLUME_KEY = "SE_VOLUME_KEY";
    private const float BGM_VOLUME_DEFAULT = 0.2f;
    private const float SE_VOLUME_DEFAULT = 1f;

    public const float BMG_FADE_SPEED_RATE_HIGH = 0.9f;
    public const float BGM_FADE_SPEED_RATE_LOW = 0.3f;
    private float bgmFadeSpeedRate = BMG_FADE_SPEED_RATE_HIGH;

    private string nextBGMName;
    private string nextSEName;

    private bool isFadeOut = false;

    public AudioSource attackBGMSource;
    public AudioSource attackSESource;

    private Dictionary<string , AudioClip>bgmDic, secDic;

    public object AttachBGMSource { get; internal set; }

    protected override void Awake()
    {
        base.Awake();
        bgmDic= new Dictionary<string , AudioClip>();
        secDic= new Dictionary<string , AudioClip>();

        object[] bgmList = Resources.LoadAll<AudioClip>("Audio/BGM");
        object[] seList = Resources.LoadAll<AudioClip>("Audio/SE");

        foreach(AudioClip bgm in bgmList)
        {
            bgmDic[bgm.name] = bgm;
        }
        foreach(AudioClip se in seList)
        {
            secDic[se.name] = se;
        }
    }
    private void Start()
    {
        attackBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFAULT);
        attackSESource.volume = PlayerPrefs.GetFloat(SE_VOLUME_KEY, SE_VOLUME_DEFAULT);
    }

    public void PlaySE(string seName, float delay = 0.0f)
    {
        if(!secDic.ContainsKey(seName))
        {
            Debug.Log(seName + "There is no SE named");
            return;
        }

        nextSEName = seName;
        Invoke("DelayPlaySE", delay);
    }

    private void DelayPlaySE()
    {
        attackSESource.PlayOneShot(secDic[nextSEName] as AudioClip) ;
    }

    public void PlayBGM(string bgmName, float fadeSpeedRate = BMG_FADE_SPEED_RATE_HIGH)
    {
        if(!bgmDic.ContainsKey(bgmName)) 
        {
            Debug.Log(bgmName + "There is no BGM named");
            return;
        }
        if(!attackBGMSource.isPlaying)
        {
            nextBGMName = "";
            attackBGMSource.clip = bgmDic[bgmName] as AudioClip;
        }
    }
    public void FadeOutBGM(float fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
    {
        bgmFadeSpeedRate= fadeSpeedRate;
        isFadeOut = true;
    }
    private void Update()
    {
        if(!isFadeOut)
        {
            return;
        }

        attackBGMSource.volume -= Time.deltaTime * bgmFadeSpeedRate;
        if(attackBGMSource.volume <= 0)
        {
            attackBGMSource.Stop();
            attackBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFAULT);
            isFadeOut = false;

            if(!string.IsNullOrEmpty(nextBGMName))
            {
                PlayBGM(nextBGMName);
            }
        }
    }

    public void ChangeBGMVolume(float BGMVolume)
    {
        attackBGMSource.volume = BGMVolume;
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, BGMVolume);
    }
    public void ChangeSEVolume(float SEVolume)
    {
        attackSESource.volume = SEVolume;
        PlayerPrefs.SetFloat(SE_VOLUME_KEY, SEVolume);
    }

    public void MuteBGM(bool isMute)
    {
        attackBGMSource.mute = isMute;
        //ObscuredPrefs.SetBool(CONST.BGM)
    }
}
