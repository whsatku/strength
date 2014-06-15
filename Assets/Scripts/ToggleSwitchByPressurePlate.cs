using UnityEngine;
using System.Collections.Generic;

public class ToggleSwitchByPressurePlate : MonoBehaviour {

	public string switchName;
	public Sprite activeSprite;
	public Sprite disabledSprite;

	new private SpriteRenderer renderer;
	private List<Collider2D> objectsOn = new List<Collider2D>();

	// Use this for initialization
	void Start () {
		renderer = (SpriteRenderer) GetComponent ("SpriteRenderer");
	}
	
	// Update is called once per frame
	void Update () {
		bool val;
		Manager.instance.switches.TryGetValue (switchName, out val);
		renderer.sprite = val ? activeSprite : disabledSprite;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!objectsOn.Contains(col)) {
			objectsOn.Add(col);
			if(audio){
				audio.Play();
			}
		}
		if (objectsOn.Count > 0) {
			Manager.instance.switches[switchName] = true;
			Manager.instance.fireSwitchChanged();
		}
	}

	void OnTriggerExit2D(Collider2D col){
		objectsOn.Remove(col);
		if(audio){
			audio.Play();
		}
		if (objectsOn.Count == 0) {
			Manager.instance.switches [switchName] = false;
			Manager.instance.fireSwitchChanged ();
		}
	}
}
