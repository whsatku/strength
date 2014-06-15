using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {

	public Sprite soundOn;
	public Sprite soundOff;

	new private SpriteRenderer renderer;
	
	// Use this for initialization
	void Start () {
		renderer = (SpriteRenderer) GetComponent("SpriteRenderer");
	}

	void Update(){
		renderer.sprite = AudioListener.volume == 0 ? soundOff : soundOn;
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			AudioListener.volume = AudioListener.volume == 0 ? 100 : 0;
		}
	}
}
