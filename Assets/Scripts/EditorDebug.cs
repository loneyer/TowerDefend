using UnityEngine;
using System.Collections;
#if EditorDebug
using UnityEditor;
#endif

public class EditorDebug {

	public static void Log(string str){
		#if EditorDebug
		Debug.Log(str);
		#endif
	}
	public static void Log(string str, GameObject go){
		#if EditorDebug
		if(Selection.activeGameObject == go)
			Debug.Log(str);
		#endif
	}
	public static void LogWaring(string str){
		#if EditorDebug
		Debug.LogWarning(str);
		#endif
	}
	public static void LogWaring(string str, GameObject go){
		#if EditorDebug
		if(Selection.activeGameObject == go)
			Debug.LogWarning(str);
		#endif
	}
	public static void LogError(string str){
		#if EditorDebug
		Debug.LogError(str);
		#endif
	}
	public static void LogError(string str, GameObject go){
		#if EditorDebug
		if(Selection.activeGameObject == go)
			Debug.LogError(str);
		#endif
	}

}
