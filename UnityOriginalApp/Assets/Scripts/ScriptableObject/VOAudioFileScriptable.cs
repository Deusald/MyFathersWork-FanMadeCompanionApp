using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VOAudio", menuName = "ScriptableObjects/VOAudioScriptableObject", order = 1)]
public class VOAudioFileScriptable : ScriptableObject
{
    [Header("Male Voice")]
    public List<AudioData> MaleAudioDatas = new List<AudioData>();
    [Header("Female Voice")]
    public List<AudioData> FemaleAudioDatas = new List<AudioData>();
}

[System.Serializable]
public class AudioData
{
    public string PassageName;
    public AudioClip clip;
}
