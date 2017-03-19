using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjManager : MonoBehaviour {
	public class cachedGOStruct
	{
		public bool isShowing;
		public float delayDespawn;
		public float timer;
		public string path;
		public string name;
		public GameObject go;

		public bool IsEquals(string _path, string _name){
			if (path.Equals (_path) && name.Equals (_name))
				return true;
			return false;
		}
	}


	#region Member

	static ObjManager _instance;
	public static ObjManager instance{
		get{
			if (_instance == null) {
				_instance = new GameObject ("ObjManager").AddComponent<ObjManager> ();
				_instance.transform.position = Vector3.one * 2000;
			}
			return _instance;
		}
	}

	List<cachedGOStruct> cachedGO =new List<cachedGOStruct>();

	bool canUpdate = true;
	#endregion

	#region Interface

	public GameObject GetGameObject(string path, string name, Transform defaultParent = null, float delayDespawn = -1){
		for(int i = 0;i < cachedGO.Count;i++){
			if(cachedGO[i].IsEquals(path, name) && !cachedGO[i].isShowing){
				cachedGO [i].delayDespawn = delayDespawn;
				cachedGO [i].timer = 0;
				cachedGO [i].isShowing = true;
				if (defaultParent != null) {
					cachedGO [i].go.transform.parent = defaultParent;
					cachedGO [i].go.transform.localPosition = Vector3.zero;
				}

				cachedGO [i].go.SetActive (true);
				return cachedGO [i].go;
			}
		}

		// 缓存中没有对应的数据
		return CreateGameObject(path, name, defaultParent, delayDespawn);

	}



	public void Despawn(GameObject _go){
		for(int i = 0;i < cachedGO.Count;i++){
			if (cachedGO [i].go == _go && cachedGO[i].isShowing) {
				cachedGO [i].go.transform.parent = transform;
				cachedGO [i].go.transform.localPosition = Vector3.zero;
				cachedGO [i].go.transform.localScale = Vector3.one;
				cachedGO [i].go.SetActive (false);
				cachedGO [i].isShowing = false;
				return;
			}
		}

		Debug.Log ("回收错误  物体名字 :[" + _go.name);
	}

	#endregion

	#region Private

	GameObject CreateGameObject(string path, string name, Transform defaultParent, float delayDespawn){
		var tGO = Resources.Load<GameObject>(path + name);
		var GO = GameObject.Instantiate<GameObject> (tGO);
	

		if (defaultParent == null)
			GO.transform.parent = transform;
		else
			GO.transform.parent = defaultParent;

		GO.transform.localPosition = Vector3.zero;
		GO.transform.localScale = Vector3.one;

		var cgoStruct = new cachedGOStruct ();
		cgoStruct.path = path;
		cgoStruct.name = name;
		cgoStruct.timer = 0;
		cgoStruct.isShowing = true;
		cgoStruct.go = GO;
		cgoStruct.delayDespawn = delayDespawn;
		cachedGO.Add (cgoStruct);
		return cgoStruct.go;
	}

	#endregion

	#region Awake 等方法

	void Awake(){
		transform.position = new Vector3 (1000,0,1000);
	}
	
	// Update is called once per frame
	void Update () {
		if (!canUpdate)
			return;

		for(int i = 0;i < cachedGO.Count;i++){
			if(cachedGO[i].isShowing && cachedGO[i].delayDespawn > -1){
				cachedGO [i].timer += Time.deltaTime;

				if (cachedGO [i].timer >= cachedGO [i].delayDespawn) {
					Despawn (cachedGO[i].go);
				}
			}
		}

	}

	#endregion
}
