using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BaseDataAttribute))]
public class DataInspector : Editor {

	BaseData baseData;

	void OnEnable(){
		var bda = target as BaseDataAttribute;
		baseData = bda.stageActor.actordata;
	}


	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		foreach(var d in baseData.GetValueFloat()){
			EditorGUILayout.LabelField (d.Key + "   value:[" + d.Value.GetValue () + "] buff:[" + d.Value.GetBuffValue () +
			"] base:[" + d.Value.GetBaseValue () + "]");
		}

		Repaint ();
	}
}
