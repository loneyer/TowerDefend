using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[Serializable]
public class BuffDataData{
	[SerializeField] 
	string ID;
	[SerializeField] 
	string Name;
	[SerializeField] 
	bool IsReturn;
	[SerializeField] 
	string AttributeType;
	[SerializeField] 
	string ComputeAttribute;
	[SerializeField] 
	string ComputeTarget;
	[SerializeField] 
	string TargetAttribute;
	[SerializeField] 
	int Value;

	public BuffDataData(){}
	public string GetID() {
		return ID;
	}
	public string GetName() {
		return Name;
	}
	public bool GetIsReturn() {
		return IsReturn;
	}
	public string GetAttributeType() {
		return AttributeType;
	}
	public string GetComputeAttribute() {
		return ComputeAttribute;
	}
	public string GetComputeTarget() {
		return ComputeTarget;
	}
	public string GetTargetAttribute() {
		return TargetAttribute;
	}
	public int GetValue() {
		return Value;
	}
}



public class JSONBuffData{
	[SerializeField]
	List<BuffDataData> data;
	const string filepath = "/Resources/JsonData/Data/BuffDataData.txt";
	static JSONBuffData _instance;
	public static JSONBuffData instance{
		get{
			if(_instance == null){
				_instance = createInstance();
			}
			return _instance;
		}
	}
	static JSONBuffData createInstance(){
		StreamReader sr = new StreamReader(Application.dataPath + "/Resources/JsonData/Data/BuffDataData.txt");
		string str = sr.ReadToEnd();
		var result = JsonUtility.FromJson<JSONBuffData> (str);
		return result; 
	}
	Dictionary<string, BuffDataData> _dict;
	Dictionary<string, BuffDataData> dict{
		get{
			if(_dict == null){
				initDict();
			}
			return _dict;
		}
	}
	void initDict(){
		_dict = new Dictionary<string, BuffDataData> ();
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
	/// 名称
	/// <summary>
	public string GetName (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetName();
	}

	/// <summary>
	/// 是否返回
	/// <summary>
	public bool GetIsReturn (string ID){
		if(!dict.ContainsKey(ID))
			return false;
		return dict[ID].GetIsReturn();
	}

	/// <summary>
	/// 属性类型
	/// <summary>
	public string GetAttributeType (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetAttributeType();
	}

	/// <summary>
	/// 计算的属性
	/// <summary>
	public string GetComputeAttribute (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetComputeAttribute();
	}

	/// <summary>
	/// 计算的对象
	/// <summary>
	public string GetComputeTarget (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetComputeTarget();
	}

	/// <summary>
	/// 对象的属性
	/// <summary>
	public string GetTargetAttribute (string ID){
		if(!dict.ContainsKey(ID))
			return "";
		return dict[ID].GetTargetAttribute();
	}

	/// <summary>
	/// 值
	/// <summary>
	public int GetValue (string ID){
		if(!dict.ContainsKey(ID))
			return 0;
		return dict[ID].GetValue();
	}

}
