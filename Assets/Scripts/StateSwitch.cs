using UnityEngine;
using System.Collections;

public class StateSwitch : MonoBehaviour {

	public string switchName;
	public bool negative;
	
	void Start () {
		Manager.instance.switchChanged += new Manager.SwitchChangeHandler(Update);
	}

	void OnDestroy(){
		Manager.instance.switchChanged -= new Manager.SwitchChangeHandler(Update);
	}
	
	// Update is called once per frame
	void Update () {
		bool value;
		Manager.instance.switches.TryGetValue (switchName, out value);
		if (negative) {
			value = !value;
		}
		gameObject.SetActive (value);
		if (renderer) {
			renderer.enabled = value;
		}
	}
}
