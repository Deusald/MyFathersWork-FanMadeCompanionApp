using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSpecialEvent : UIView
{
	public static ViewSpecialEvent instance;
	public AudioClip clip;
	public CanvasGroup cGroup;
	public AudioSource popUpAudioSource;

	private void Start() => instance = this;

	public void ShowEventPopup() => StartCoroutine(StartAnim());

	IEnumerator StartAnim()
	{
		yield return new WaitForEndOfFrame();
		base.Show();
		if (clip != null) SoundManager.Instance.OnOpenPopupPlayAudio(clip);
		float t = 0; 
		while (t < 1)
		{
			t += Time.fixedDeltaTime/2;
			popUpAudioSource.volume = t;
			cGroup.alpha = t;
			yield return new WaitForFixedUpdate();
		}
		yield return new WaitForSeconds(0.5f);
		while (t > 0)
		{
			t -= Time.fixedDeltaTime / 2;
			popUpAudioSource.volume = t;
			cGroup.alpha = t;
			yield return new WaitForFixedUpdate();
		}
		SoundManager.Instance.OnClosePopupStopAudio();
		yield return new WaitForEndOfFrame();
		base.Hide();
		
		popUpAudioSource.Stop();
		popUpAudioSource.volume = 1;
	}
}
