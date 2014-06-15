using UnityEngine;
using System.Collections;

public class RemoveParentByAbility : MonoBehaviour {

	public Manager.CopyAbilities abilityName;

	private bool canUse;

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player") && Manager.instance.ability == abilityName){
			canUse = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag.Contains("Player") && Manager.instance.ability == abilityName){
			canUse = false;
		}
	}
	
	void OnGUI(){
		GUI.skin = Resources.Load<GUISkin> ("GUI");
		if (canUse) {
			if(GUI.Button(new Rect(Screen.width - 10 - Manager.buttonSize.x, Screen.height - 10 - Manager.buttonSize.y, Manager.buttonSize.x, Manager.buttonSize.y), abilityName.ToString())){
				Manager.instance.ability = abilityName;
				AutoTyper typer = (AutoTyper) Camera.main.GetComponent("AutoTyper");
				typer.SetText("You used "+abilityName.ToString()+"\n"+transform.parent.gameObject.name+" destroyed");
				if(audio){
					AudioSource.PlayClipAtPoint(audio.clip, transform.position);
				}
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
