using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[Serializable]
public class TotalSkillData{
	[SerializeField] 
	string ID;
	[SerializeField] 
	string MapId;
	[SerializeField] 
	string ConditionContent;

	public TotalSkillData(){}
	public string GetID() {
		return ID;
	}
	public string GetMapId() {
		return MapId;
	}
	public string GetConditionContent() {
		return ConditionContent;
	}
}



public class JSONTotalSkill{
	[SerializeField]
	List<TotalSkillData> data;
	const string filepath = "/Resources/JsonData/Data/TotalSkillData.txt";
	static JSONTotalSkill _instance;
	public static JSONTotalSkill instance{
		get{
			if(_instance == null){
				_instance = createInstance();
			}
			return _instance;
		}
	}
	static JSONTotalSkill createInstance(){
		StreamReader sr = new StreamReader(Application.dataPath + "/Resources/JsonData/Data/TotalSkillData.txt");
		string str = sr.ReadToEnd();
		var result = JsonUtility.FromJson<JSONTotalSkill> (str);
		return result; 
	}
	Dictionary<string, TotalSkillData> _dict;
	Dictionary<string, TotalSkillData> dict{
		get{
			if(_dict == null){
				initDict();
			}
			return _dict;
		}
	}
	void initDict(){
		_dict = new Dictionary<string, TotalSkillData> ();
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
	/// 映射ID
	/// <summary>
	public string GetMapId (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetMapId();
	}

	/// <summary>
	/// 条件内容
	/// <summary>
	public string GetConditionContent (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetConditionContent();
	}

}
