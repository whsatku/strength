using UnityEngine;
using System.Collections;

public class ActivateSwitch : DisplayText {

	public string label;
	public string activateText;
	public string switchName;
	public bool switchValue;
	public bool toggle;
	public int buttonIndex;
	public Manager.CopyAbilities requireAbility;

	private bool canUse;
	
	public override void OnTriggerEnter2D(Collider2D col){
		base.OnTriggerEnter2D (col);
		if(col.gameObject.tag.Contains("Player")){
			if(CanActivate()){
				canUse = true;
			}
		}
	}
	
	public override void OnTriggerExit2D(Collider2D col){
		base.OnTriggerExit2D (col);
		if(col.gameObject.tag.Contains("Player")){
			if(CanActivate()){
				canUse = false;
			}
		}
	}
	
	void OnGUI(){
		GUI.skin = Resources.Load<GUISkin> ("GUI");
		if (canUse) {
			if(GUI.Button(new Rect(Screen.width - ((Manager.buttonSize.x+10) * (buttonIndex+1)), Screen.height - 10 - Manager.buttonSize.y, Manager.buttonSize.x, Manager.buttonSize.y), label)){
				Activate();
			}
		}
	}

	protected virtual bool CanActivate(){
		return requireAbility == Manager.CopyAbilities.NO || requireAbility == Manager.instance.ability;
	}

	protected virtual void Activate(){
		if(toggle){
			bool value;
			Manager.instance.switches.TryGetValue(switchName, out value);
			value = !value;
			Manager.instance.switches[switchName] = value;
		}else{
			Manager.instance.switches[switchName] = switchValue;
		}
		Manager.instance.fireSwitchChanged();
		Type(activateText);
		if (audio) {
			AudioSource.PlayClipAtPoint(audio.clip, transform.position);
		}
	}
}
