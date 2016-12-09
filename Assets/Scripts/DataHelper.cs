using UnityEngine;
using System.Collections;

public class DataHelper : MonoBehaviour {
	public const string FIRST_LAUNCH = "firstlaunch";
	public const string AUDIO_ON = "audioOn";
	public const string MUSIC_ON = "musicOn";

	public static void SetValue(string key, bool value) {
		PlayerPrefs.SetInt (key,value ? 1 : 0);
	}

	public static bool GetValue(string key) {
		return PlayerPrefs.GetInt(key,0) == 0 ? false : true;
	}
}
