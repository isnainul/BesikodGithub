using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public AudioMixer audioMixer;

	public Toggle toggleAudio;
	public Toggle toggleMusic;

	void Start () {
		GetSettings();
	}

	void GetSettings () {
		toggleAudio.isOn = DataHelper.GetValue (DataHelper.AUDIO_ON);
		toggleMusic.isOn = DataHelper.GetValue (DataHelper.MUSIC_ON);

		audioMixer.SetFloat ("sfxVol", toggleAudio.isOn ? -80f:0f);
		audioMixer.SetFloat ("musicVol", toggleMusic.isOn ? -80f:0f);
	}

	public void UpdateToggleAudio() {
		audioMixer.SetFloat ("sfxVol", toggleAudio.isOn ? -80f:0f);
		DataHelper.SetValue (DataHelper.AUDIO_ON,toggleAudio.isOn);
	}

	public void UpdateToggleMusic() {
		audioMixer.SetFloat ("musicVol", toggleMusic.isOn ? -80f:0f);
		DataHelper.SetValue (DataHelper.MUSIC_ON,toggleMusic.isOn);
	}

	public void Play() {
		SceneManager.LoadScene ("Level1");
	}
}
