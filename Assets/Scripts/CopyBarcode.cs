using UnityEngine;
using System.Collections;

public class CopyBarcode : Copyable {

	public string barcodeName;

	protected override void Copy(){
		base.Copy ();
		Manager.instance.barcodeName = barcodeName;

		if (barcodeName == "bar1") {
			bool val;
			Manager.instance.switches.TryGetValue ("bar1 activate", out val);
			if (val) {
				return;
			}
			
			Manager.instance.totalTime = 90;
			Manager.instance.time = 90;
			Manager.instance.isFakeTimer = false;
			Manager.instance.timerActive = true;
			Manager.instance.switches ["bar1 activate"] = true;
		}
	}
}
