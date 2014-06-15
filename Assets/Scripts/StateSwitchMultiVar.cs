using UnityEngine;
using System.Collections;

public class StateSwitchMultiVar : MonoBehaviour {

	public string[] switchName;
	public bool negative;
	
	void Start () {
		Manager.instance.switchChanged += new Manager.SwitchChangeHandler(Update);
	}

	void OnDestroy(){
		Manager.instance.switchChanged -= new Manager.SwitchChangeHandler(Update);
	}
	
	// Update is called once per frame
	void Update () {
		bool value = true;
		foreach(string name in switchName){
			bool val;
			Manager.instance.switches.TryGetValue (name, out val);
			value = value && val;
		}
		if (negative) {
			value = !value;
		}
		gameObject.SetActive (value);
		if (renderer) {
			renderer.enabled = value;
		}
	}
}
