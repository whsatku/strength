using UnityEngine;
using System.Collections;

public class ShowPicture : MonoBehaviour {

	public Sprite sprite;
	public Transform attachTarget;

	private GameObject picture;
	
	// Use this for initialization
	void Start () {
		picture = new GameObject ();
		picture.AddComponent("SpriteRenderer");
		SpriteRenderer renderer = picture.GetComponent<SpriteRenderer> ();
		renderer.sprite = sprite;
		renderer.sortingLayerName = "Picture";
		picture.transform.position = attachTarget.transform.position;
		picture.renderer.enabled = false;
	}
	
	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player")){
			picture.renderer.enabled = true;
		}
	}
	
	public void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player")){
			picture.renderer.enabled = false;
		}
	}
}
