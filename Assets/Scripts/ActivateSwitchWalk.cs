using UnityEngine;
using System.Collections;

public class ActivateSwitchWalk : DisplayText {
	
	public string switchName;
	public bool switchValue;
	public bool offOnLeave;

	public override void OnTriggerEnter2D(Collider2D col){
		base.OnTriggerEnter2D (col);
		if(col.gameObject.tag.Contains("Player")){
			Manager.instance.switches[switchName] = switchValue;
			Manager.instance.fireSwitchChanged();
			if(audio){
				AudioSource.PlayClipAtPoint(audio.clip, transform.position);
			}
		}
	}

	public override void OnTriggerExit2D(Collider2D col){
		base.OnTriggerExit2D (col);
		if(col.gameObject.tag.Contains("Player") && offOnLeave){
			Manager.instance.switches[switchName] = false;
			Manager.instance.fireSwitchChanged();
			if(audio){
				AudioSource.PlayClipAtPoint(audio.clip, transform.position);
			}
		}
	}
}
