using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

	static T _instance;
	public static T instance{
		get{
			if (_instance == null)
				_instance = new GameObject (typeof(T).Name).AddComponent<T> ();
			return _instance;
		}
	}

}
