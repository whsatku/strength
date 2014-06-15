using UnityEngine;
using System.Collections;

public class DisplayText : MonoBehaviour {

	public string displayText;

	public virtual void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player") && displayText.Length > 0){
			Type(displayText);
		}
	}
	
	public virtual void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player") && displayText.Length > 0){
			Type("");
		}
	}

	protected void Type(string text){
		AutoTyper typer = (AutoTyper) Camera.main.GetComponent("AutoTyper");
		typer.SetText(text);
	}
}
