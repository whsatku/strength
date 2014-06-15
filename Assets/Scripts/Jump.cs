using UnityEngine;
using System.Collections;

public class Jump : ActivateSwitch {

	public string nextLevel;

	protected override bool CanActivate(){
		return true;
	}
	
	protected override void Activate(){
		Application.LoadLevel (nextLevel);
	}
}
