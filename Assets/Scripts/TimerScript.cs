using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public GUISkin skin;

	private int frameState = 0;
	private float lastTick = 0;

	// Use this for initialization
	void Start () {
		Manager.instance.time = Manager.instance.totalTime;
		lastTick = Time.time;
	}

	void OnGUI(){
		GUI.skin = skin;

		if (!Manager.instance.timerActive) {
			return;
		}

		GUIStyle style = new GUIStyle (skin.box);
		style.normal.background = Resources.Load<Texture2D> ("Timer/Frame"+(frameState+1).ToString());

		GUI.Box (new Rect (10, 10, 200, 80), FormatTime(), style);
	}

	void Update () {
		if (!Manager.instance.timerActive) {
			return;
		}

		Manager.instance.time -= Time.deltaTime;
		if (Manager.instance.time <= 0) {
			if(Manager.instance.isFakeTimer){
				AutoTyper typer = (AutoTyper) Camera.main.GetComponent("AutoTyper");
				typer.SetText("HA HA HA HA HA HA HA HA HA HA");
				Manager.instance.isFakeTimer = false;
			}else{
				Manager.instance.Reset();
				Application.LoadLevel(Application.loadedLevelName);
			}
			Manager.instance.timerActive = false;
		}
		if (Time.time - lastTick > 1) {
			frameState = ++frameState % 2;
			lastTick = Time.time;
		}
	}

	string FormatTime(){
		float t = Manager.instance.time;
		int min = Mathf.FloorToInt (t / 60);
		t -= min * 60;
		int sec = Mathf.FloorToInt (t);
		int msec = (int) ((t - sec) * 1000);
		return string.Format ("{0:D2}:{1:D2}.{2:D3}", min, sec, msec);
	}
}
