using UnityEngine;
using System.Collections;

public class Copyable : DisplayText {

	public Manager.CopyAbilities abilityName;

	private bool canCopy = false;

	public override void OnTriggerEnter2D(Collider2D col){
		base.OnTriggerEnter2D (col);
		if(col.gameObject.tag.Contains("Player")){
			canCopy = true;
		}
	}

	public override void OnTriggerExit2D(Collider2D col){
		base.OnTriggerExit2D (col);
		if(col.gameObject.tag.Contains("Player")){
			canCopy = false;
		}
	}

	void OnGUI(){
		GUI.skin = Resources.Load<GUISkin> ("GUI");
		if (canCopy) {
			if(GUI.Button(new Rect(Screen.width - 10 - Manager.buttonSize.x, Screen.height - 10 - Manager.buttonSize.y, Manager.buttonSize.x, Manager.buttonSize.y), "Extract")){
				Copy();
			}
		}
	}

	protected virtual void Copy(){
		Manager.instance.ability = abilityName;
		Type("You extracted "+abilityName.ToString());
		canCopy = false;
	}

}
