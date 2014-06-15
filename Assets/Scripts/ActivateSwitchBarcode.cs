using UnityEngine;
using System.Collections;

public class ActivateSwitchBarcode : ActivateSwitch {

	public string barcodeName;

	protected override bool CanActivate(){
		return base.CanActivate () && Manager.instance.barcodeName == barcodeName;
	}
}
