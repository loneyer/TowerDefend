using UnityEngine;
using System.Collections;
using UnityEditor;

public class ChangeTowerMaterial : EditorWindow {

	Material towerMaterial;

	[MenuItem("zTools/ChangeTowerMaterial")]
	public static void Init(){
		GetWindow<ChangeTowerMaterial> ("ChangeTowerMaterial").Show();
	}

	void OnGUI(){
		
	}

}
