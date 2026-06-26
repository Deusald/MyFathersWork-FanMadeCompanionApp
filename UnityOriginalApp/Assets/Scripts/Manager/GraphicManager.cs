using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicManager : MonoBehaviour
{
    public static GraphicManager instance;

    private ParticleSystem[] particleSystems;
    private int particleCount = 333;
    private int qualityLevelNumber = 3;
	[HideInInspector]
	public List<Toggle> toggleList = new List<Toggle>();
	[HideInInspector]
	public List<Toggle> toggleListPause = new List<Toggle>();
	[HideInInspector]
	public List<Toggle> toggleListPauseHub = new List<Toggle>();

    private void Awake()
    {
        instance = this;
        particleSystems = FindObjectsOfType<ParticleSystem>();
    }


	void Start() => Quality();

    public void Quality()
    {
        qualityLevelNumber = PlayerPrefs.GetInt("QualityLevel", 1);
        toggleList[qualityLevelNumber - 1].isOn = true;
        toggleListPause[qualityLevelNumber - 1].isOn = true;
        toggleListPauseHub[qualityLevelNumber - 1].isOn = true;
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].maxParticles = particleCount*qualityLevelNumber;
        }
    }

	public void GetQualityIndex(int qualityIndex) => qualityLevelNumber = qualityIndex;


	public void OnConfirmation()
    {
        PlayerPrefs.SetInt("QualityLevel", qualityLevelNumber);
        QualitySettings.SetQualityLevel(qualityLevelNumber);
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].maxParticles = particleCount * qualityLevelNumber;
        }
    }

}
