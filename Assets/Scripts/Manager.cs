using UnityEngine;
using System.Collections.Generic;

public class Manager {

	public delegate void SwitchChangeHandler();

	public float totalTime = 0;
	public float time;
	public bool timerActive = false;
	public bool isFakeTimer;
	public CopyAbilities ability = CopyAbilities.NO;
	public Dictionary<string, bool> switches = new Dictionary<string, bool>();
	public string barcodeName = "";

	public Dictionary<string, Vector2> objectState = new Dictionary<string, Vector2>();

	public static Vector2 buttonSize = new Vector2(250, 100);

	public event SwitchChangeHandler switchChanged;

	public static Manager instance = new Manager();

	public void fireSwitchChanged(){
		switchChanged ();
	}

	public enum CopyAbilities {
		NO,
		WATER,
		DRILL,
		BARCODE,
		LIGHT
	};

	public void Reset(){
		switches.Clear ();
		ability = CopyAbilities.NO;
		barcodeName = string.Empty;
	}

}
