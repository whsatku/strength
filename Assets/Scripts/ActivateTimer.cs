using UnityEngine;
using System.Collections;

public class ActivateTimer : ActivateSwitch {

	public float time;
	public bool isFakeTimer;

	protected override void Activate(){
		bool val;
		Manager.instance.switches.TryGetValue (switchName, out val);
		if (val && switchName.Length > 0) {
			return;
		}
		
		Manager.instance.totalTime = time;
		Manager.instance.time = time;
		Manager.instance.isFakeTimer = isFakeTimer;
		Manager.instance.timerActive = true;
		if (switchName.Length > 0) {
			Manager.instance.switches [switchName] = true;
		}

		Type(activateText);
	}
}
