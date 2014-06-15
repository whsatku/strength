using UnityEngine;
using System.Collections;

public class SetTimer : MonoBehaviour {

	public float time;
	public string switchName;
	public bool isFakeTimer;

	// Use this for initialization
	void Start () {
		bool val;
		Manager.instance.switches.TryGetValue (switchName, out val);
		if (val && switchName.Length > 0) {
			return;
		}

		Manager.instance.totalTime = time;
		Manager.instance.time = time;
		Manager.instance.timerActive = time > 0;
		Manager.instance.isFakeTimer = isFakeTimer;
		if (switchName.Length > 0) {
			Manager.instance.switches [switchName] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
