using UnityEngine;
using System.Collections;

public class AutoTyper : MonoBehaviour {

	private string text = "";
	private int typePos = 0;
	private float completionTime = 0;
	private float lastCharacterTime = 0;
	public GUISkin skin;

	public void SetText(string msg){
		text = msg;
		completionTime = Time.time;
		typePos = 0;
	}

	void Update(){
		if (Time.time - lastCharacterTime > 0.04) {
			typePos++;
			lastCharacterTime = Time.time;
		}
		if (typePos == text.Length) {
			completionTime = Time.time;
		}
	}

	void OnGUI(){
		GUI.skin = skin;
		if (text.Length == 0 || Time.time - completionTime > 3) {
			return;
		}
		GUI.Label (new Rect(Screen.width - Screen.width/2, 10, Screen.width / 2, 100), text.Substring(0, Mathf.Min(typePos, text.Length)));
	}
}
