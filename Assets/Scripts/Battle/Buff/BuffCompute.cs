using UnityEngine;
using System.Collections;
using JSON;

public class BuffCompute {
	BuffMgr.BuffData buffData;

	string attributeTyte; // 属性类型 (基础值还是过程值)
	string computeAttribute; // 计算的属性 (血量,攻击力等)
	string computeTarget; // 计算的对象 (攻击方,被攻击方,无)
	string targetAttribute; // 对象的属性 (血量,攻击力等， 若计算的对象为空则该项也为空)
	int computeValue; // 值
	bool isReturn; // 值是否可返回

	public BuffCompute(BuffMgr.BuffData _bd, int _lv){
		buffData = _bd;
		string _buffId = buffData.buffId; 
		attributeTyte = JSONBuffData.instance.GetAttributeType (_buffId);
		computeAttribute = JSONBuffData.instance.GetComputeAttribute (_buffId);
		computeTarget = JSONBuffData.instance.GetComputeTarget (_buffId);
		targetAttribute = JSONBuffData.instance.GetTargetAttribute (_buffId);
		computeValue = JSONBuffData.instance.GetValue (_buffId);
		isReturn = JSONBuffData.instance.GetIsReturn (_buffId);
	}

	#region Interface

	/// <summary>
	/// Buff 开始.
	/// </summary>
	/// <returns>The begin.</returns>
	public float BuffBegin(){
		float value = 0;

		baseCompute (buffData.hiterData, buffData.attackerData, ref value);

		buffData.hiterData.AddValue (computeAttribute, value, attributeTyte);

		return value;
	}

	 /// <summary>
	 /// buff 结束
	 /// </summary>
	 /// <returns>The finish.</returns>
	public float BuffFinish(){
		if (!isReturn)
			return 0;

		float value = 0;
		baseCompute (buffData.hiterData, buffData.attackerData, ref value);

		value = -value;
		buffData.hiterData.AddValue (computeAttribute, value, attributeTyte);

		return value;
	}


	#endregion

	void baseCompute(BaseData _hiter, BaseData _attacker, ref float _value){
		_value = computeValue;
		if (computeTarget == "Hiter") {
			_value = _hiter.GetValue (targetAttribute) * _value;
		} else if (computeTarget == "Attacker") {
			_value = _attacker.GetValue (targetAttribute) * _value;
		} else {
			_value = _value;
		}
	}

}
