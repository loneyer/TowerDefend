using UnityEngine;
using System.Collections;
using UnityEditor;

public class SkillEditor : EditorWindow {

	public static void Init(){
		GetWindow<SkillEditor> ("技能编辑器");


	}

	void OnGUI(){
		GUILayout.BeginHorizontal ();
		leftPanel ();
		rightPanel ();

		GUILayout.EndHorizontal ();
	}

	void leftPanel(){
//		GUILayout.butt
	}
	void rightPanel(){
		
	}


}
