using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[Serializable]
public class BointModelCardData{
	[SerializeField] 
	string ID;
	[SerializeField] 
	string Name;
	[SerializeField] 
	string ModeName;
	[SerializeField] 
	float HP;
	[SerializeField] 
	float AttackValue;
	[SerializeField] 
	float MoveSpeed;
	[SerializeField] 
	float SeekDistance;
	[SerializeField] 
	List<int> Skills;

	public BointModelCardData(){}
	public string GetID() {
		return ID;
	}
	public string GetName() {
		return Name;
	}
	public string GetModeName() {
		return ModeName;
	}
	public float GetHP() {
		return HP;
	}
	public float GetAttackValue() {
		return AttackValue;
	}
	public float GetMoveSpeed() {
		return MoveSpeed;
	}
	public float GetSeekDistance() {
		return SeekDistance;
	}
	public List<int> GetSkills() {
		return Skills;
	}
}



public class JSONBointModelCard{
	[SerializeField]
	List<BointModelCardData> data;
	const string filepath = "/Resources/JsonData/Data/BointModelCardData.txt";
	static JSONBointModelCard _instance;
	public static JSONBointModelCard instance{
		get{
			if(_instance == null){
				_instance = createInstance();
			}
			return _instance;
		}
	}
	static JSONBointModelCard createInstance(){
		StreamReader sr = new StreamReader(Application.dataPath + "/Resources/JsonData/Data/BointModelCardData.txt");
		string str = sr.ReadToEnd();
		var result = JsonUtility.FromJson<JSONBointModelCard> (str);
		return result; 
	}
	Dictionary<string, BointModelCardData> _dict;
	Dictionary<string, BointModelCardData> dict{
		get{
			if(_dict == null){
				initDict();
			}
			return _dict;
		}
	}
	void initDict(){
		_dict = new Dictionary<string, BointModelCardData> ();
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
	/// 名字
	/// <summary>
	public string GetName (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetName();
	}

	/// <summary>
	/// 模型名称
	/// <summary>
	public string GetModeName (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetModeName();
	}

	/// <summary>
	/// 血量
	/// <summary>
	public float GetHP (string ID){
		if(!dict.ContainsKey(ID))
			return 0;
		return dict[ID].GetHP();
	}

	/// <summary>
	/// 攻击力
	/// <summary>
	public float GetAttackValue (string ID){
		if(!dict.ContainsKey(ID))
			return 0;
		return dict[ID].GetAttackValue();
	}

	/// <summary>
	/// 移动速度
	/// <summary>
	public float GetMoveSpeed (string ID){
		if(!dict.ContainsKey(ID))
			return 0;
		return dict[ID].GetMoveSpeed();
	}

	/// <summary>
	/// 监视距离
	/// <summary>
	public float GetSeekDistance (string ID){
		if(!dict.ContainsKey(ID))
			return 0;
		return dict[ID].GetSeekDistance();
	}

	/// <summary>
	/// 携带技能
	/// <summary>
	public List<int> GetSkills (string ID){
		if(!dict.ContainsKey(ID))
			return null;
		return dict[ID].GetSkills();
	}

}
