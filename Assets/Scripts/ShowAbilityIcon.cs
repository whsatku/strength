using UnityEngine;
using System.Collections;

public class ShowAbilityIcon : MonoBehaviour {

	void OnGUI(){
		string iconName = "";

		switch(Manager.instance.ability){
		case Manager.CopyAbilities.WATER:
			iconName = "Abilities/Water";
			break;
		case Manager.CopyAbilities.BARCODE:
			iconName = "Abilities/Barcode";
			break;
		case Manager.CopyAbilities.DRILL:
			iconName = "Abilities/Drill";
			break;
		case Manager.CopyAbilities.LIGHT:
			iconName = "Abilities/Light";
			break;
		}

		if (iconName.Length > 0) {
			Texture2D image = Resources.Load<Texture2D>(iconName);
			GUI.Label(new Rect(Screen.width - 10 - image.width, 70, image.width, image.height), image);
		}
	}
}
