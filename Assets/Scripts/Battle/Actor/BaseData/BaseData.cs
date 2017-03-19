using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseData {

	Dictionary<string, ValueFloat> valuefloat = new Dictionary<string, ValueFloat>();

	#region Interface

	public Dictionary<string, ValueFloat> GetValueFloat(){
		return valuefloat;		
	}

	public float GetValue(string key){
		if (!valuefloat.ContainsKey (key)) {
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		return valuefloat [key].GetValue ();
	}

	public float GetFloatQ(string key){
		if (!valuefloat.ContainsKey (key)) {
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		return valuefloat [key].GetValue () / 1000;
	}

	public void SetValue(string key, float value, string type){
		if (!valuefloat.ContainsKey (key)) {
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		if (type == "Base")
			valuefloat [key].AddBaseValue (value);
		else if (type == "Buff")
			valuefloat [key].AddBuffValue (value);
	}

	public void SetMaxValue(string key, float value){
		if (!valuefloat.ContainsKey (key)) {
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		valuefloat [key].SetMaxValue (value);
	}

	public void SetMinValue(string key, float value){
		if (!valuefloat.ContainsKey (key)) {
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		valuefloat [key].SetMinValue (value);
	}

	public void AddValue (string key, float value, string type){
		if (!valuefloat.ContainsKey (key)) {
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		if (type == "Base")
			valuefloat [key].AddBaseValue (value);
		else if (type == "Buff")
			valuefloat [key].AddBuffValue (value);
	}

	public void AddValueChange(string key, VoidDelegateValueFloatFloat _cb){
		if(!valuefloat.ContainsKey(key)){
			var vi = new ValueFloat ();
			valuefloat.Add (key, vi);
		}

		valuefloat [key].AddValueChangeCB (_cb);
	}

	#endregion
}
	

public class ValueFloat{
	float _basevalue;
	float _buffvalue;

	float maxvalue = float.MaxValue;
	float minvalue = float.MinValue;

	VoidDelegateValueFloatFloat _onValueChange;

	#region Interface

	/// <summary>
	/// 获取总值
	/// </summary>
	/// <returns>The value.</returns>
	public float GetValue(){
		return _basevalue + _buffvalue;
	}

	/// <summary>
	/// 获取基础值
	/// </summary>
	/// <returns>The base value.</returns>
	public float GetBaseValue(){
		return _basevalue;
	}

	/// <summary>
	/// 获取过程值
	/// </summary>
	/// <returns>The buff value.</returns>
	public float GetBuffValue(){
		return _buffvalue;
	}

	/// <summary>
	/// 添加基础值
	/// </summary>
	/// <param name="value">Value.</param>
	public void AddBaseValue(float value){
		_basevalue += value;

		onValueChange (this, value);
	}

	/// <summary>
	/// 添加buff值
	/// </summary>
	/// <param name="value">Value.</param>
	public void AddBuffValue(float value){
		_buffvalue += value;

		onValueChange (this, value);
	}

	/// <summary>
	/// 添加值改变时的回调
	/// </summary>
	/// <param name="_cb">Cb.</param>
	public void AddValueChangeCB(VoidDelegateValueFloatFloat _cb){
		if (_cb != null)
			_onValueChange += _cb;
	}

	public void SetMaxValue(float value){
		maxvalue = value;
	}
	public void SetMinValue(float value){
		minvalue = value;
	}

	/// <summary>
	/// 获取当前值的百分比
	/// </summary>
	/// <returns>The proportion.</returns>
	public float GetProportion(){
		if (maxvalue == float.MaxValue)
			return 1.0f;

		float result = GetValue () / maxvalue;
		result = Mathf.Clamp (result, 0, 1.0f);
		return result;
	}

	#endregion

	void onValueChange(ValueFloat v1, float v2){
		if (_onValueChange != null)
			_onValueChange (v1, v2);
	}
}

public class ValueInt{
	int _basevalue;
	int _buffvalue;

	int maxvalue = int.MaxValue;
	int minvalue = int.MinValue;

	VoidDelegateValueIntInt _onValueChange;

	#region Interface

	/// <summary>
	/// 获取总值
	/// </summary>
	/// <returns>The value.</returns>
	public int GetValue(){
		return _basevalue + _buffvalue;
	}

	/// <summary>
	/// 获取基础值
	/// </summary>
	/// <returns>The base value.</returns>
	public int GetBaseValue(){
		return _basevalue;
	}

	/// <summary>
	/// 获取过程值
	/// </summary>
	/// <returns>The buff value.</returns>
	public int GetBuffValue(){
		return _buffvalue;
	}

	/// <summary>
	/// 添加基础值
	/// </summary>
	/// <param name="value">Value.</param>
	public void AddBaseValue(int value){
		_basevalue += value;

		onValueChange (this, value);
	}

	/// <summary>
	/// 添加buff值
	/// </summary>
	/// <param name="value">Value.</param>
	public void AddBuffValue(int value){
		_buffvalue += value;

		onValueChange (this, value);
	}

	/// <summary>
	/// 添加值改变时的回调
	/// </summary>
	/// <param name="_cb">Cb.</param>
	public void AddValueChangeCB(VoidDelegateValueIntInt _cb){
		if (_cb != null)
			_onValueChange += _cb;
	}

	public void SetMaxValue(int value){
		maxvalue = value;
	}
	public void SetMinValue(int value){
		minvalue = value;
	}

	/// <summary>
	/// 获取当前值的百分比
	/// </summary>
	/// <returns>The proportion.</returns>
	public float GetProportion(){
		if (maxvalue == int.MaxValue)
			return 1.0f;

		float result = GetValue () / (maxvalue * 1.0f);
		result = Mathf.Clamp (result, 0, maxvalue);
		return result;
	}

	#endregion

	void onValueChange(ValueInt v1, int v2){
		if (_onValueChange != null)
			_onValueChange (v1, v2);
	}

}
