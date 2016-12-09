using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleSetting : MonoBehaviour {
	public bool isOn = false;

	Vector2 startSize = new Vector2(100f,0);
	Vector2 endSize = new Vector2 (100f,377f);

	RectTransform settingBase;

	void Awake() {
		settingBase = transform.FindChild ("Base").GetComponent<RectTransform>();
		if (isOn) {
			settingBase.gameObject.SetActive (true);
			settingBase.sizeDelta = endSize;
		} else {
			settingBase.sizeDelta = startSize;
			settingBase.gameObject.SetActive (false);
		}
	}

	public void Toggle() {
		if (!isToggling) {
			StartCoroutine (toggleAnimation ());
		}
	}

	bool isToggling = false;
	IEnumerator toggleAnimation() {
		isToggling = true;

		if (isOn) {
			float t = 0f;
			while (t < 1f) {
				t += Time.deltaTime * 5f;
				settingBase.sizeDelta = Vector2.Lerp (endSize, startSize, t);
				yield return null;
			}
			settingBase.sizeDelta = startSize;
			settingBase.gameObject.SetActive (false);
		} else {
			settingBase.gameObject.SetActive (true);
			float t = 0f;
			while (t < 1f) {
				t += Time.deltaTime * 5f;
				settingBase.sizeDelta = Vector2.Lerp (startSize, endSize, t);
				yield return null;
			}
			settingBase.sizeDelta = endSize;
		}

		isOn = !isOn;

		yield return null;
		isToggling = false;
	}
}
