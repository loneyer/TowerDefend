using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[Serializable]
public class ChallengeData{
	[SerializeField] 
	string ID;
	[SerializeField] 
	string ChallengeName;
	[SerializeField] 
	string MonsterData;

	public ChallengeData(){}
	public string GetID() {
		return ID;
	}
	public string GetChallengeName() {
		return ChallengeName;
	}
	public string GetMonsterData() {
		return MonsterData;
	}
}



public class JSONChallenge{
	[SerializeField]
	List<ChallengeData> data;
	const string filepath = "/Resources/JsonData/Data/ChallengeData.txt";
	static JSONChallenge _instance;
	public static JSONChallenge instance{
		get{
			if(_instance == null){
				_instance = createInstance();
			}
			return _instance;
		}
	}
	static JSONChallenge createInstance(){
		StreamReader sr = new StreamReader(Application.dataPath + "/Resources/JsonData/Data/ChallengeData.txt");
		string str = sr.ReadToEnd();
		var result = JsonUtility.FromJson<JSONChallenge> (str);
		return result; 
	}
	Dictionary<string, ChallengeData> _dict;
	Dictionary<string, ChallengeData> dict{
		get{
			if(_dict == null){
				initDict();
			}
			return _dict;
		}
	}
	void initDict(){
		_dict = new Dictionary<string, ChallengeData> ();
		for(int i = 0;i < data.Count;i++){
			if(_dict.ContainsKey(data[i].GetID())){
				EditorDebug.LogError( filepath + " 包含相同ID [" + data[i].GetID());
				continue;
			} 
		_dict.Add(data[i].GetID(), data[i]);
		}
	}

	/// <summary>
	/// 唯一识别
	/// <summary>
	public string GetID (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetID();
	}

	/// <summary>
	/// 关卡名称
	/// <summary>
	public string GetChallengeName (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetChallengeName();
	}

	/// <summary>
	/// 怪物数据
	/// <summary>
	public string GetMonsterData (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetMonsterData();
	}

}
