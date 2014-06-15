using UnityEngine;
using System.Collections;

public class Slideshow : MonoBehaviour {

	public Texture2D[] slides;
	public float duration = 2;
	public string nextScene;
	
	private int slideIndex = 0;
	private float lastChange;

	// Use this for initialization
	void Start () {
		lastChange = Time.time;
		if (collider2D) {
			BoxCollider2D box = (BoxCollider2D)collider2D;
			box.size = new Vector2 (Screen.width, Screen.height);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastChange > duration) {
			NextSlide ();
		}
	}

	void OnGUI(){
		Texture2D image = slides [slideIndex];
		GUI.skin = Resources.Load<GUISkin> ("GUI");

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image, ScaleMode.ScaleToFit);

		if (GUI.Button (new Rect(Screen.width - 10 - 120, Screen.height - 10 - 120, 120, 120), "Skip")) {
			slideIndex = 99999;
			NextSlide();
		}
	}

	void OnMouseDown(){
		NextSlide ();
	}

	void NextSlide(){
		slideIndex++;
		lastChange = Time.time;
		if(slideIndex > slides.Length - 1){
			if(nextScene.Length > 0){
				Application.LoadLevel(nextScene);
				slideIndex = slides.Length - 1;
			}else{
				slideIndex = 0;
			}
		}
	}
}
