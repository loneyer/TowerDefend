using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Threat {
	#region Member
	BattleStageActor stageActor;

	/// <summary>
	/// 初始仇恨值
	/// </summary>
	float initThreatValue = 100; 
//	/// <summary>
//	/// 仇恨增长比率
//	/// </summary>
//	float rate = 2.0f;

	[SerializeField]
	List<ThreatData> threats = new List<ThreatData>();
	[SerializeField]
	List<BattleStageActor> targets = new List<BattleStageActor>();

	Nullable<ThreatData> _currentThreatData;
	public Nullable<ThreatData> currentThreatData{
		get{ 
			return _currentThreatData;
		}	

		set{ 
			if (_currentThreatData == null || value == null) {
				var now = value == null ? null : value.Value.target;
				var old = _currentThreatData == null ? null : _currentThreatData.Value.target;
				_currentThreatData = value;
				if(onFirstTargetChange != null)
					onFirstTargetChange (now, old);
				return;
			}


			if (_currentThreatData.Value.target != value.Value.target) {
				var now = value.Value.target;
				var old = _currentThreatData.Value.target;
				_currentThreatData = value;
				if(onFirstTargetChange != null)
					onFirstTargetChange (now, old);
			}
				
		}
	}


	public VoidDelegateBsaBsa onFirstTargetChange;

	#endregion

	public Threat(BattleStageActor bsa){
		stageActor = bsa;
	}

	#region Interface

	public List<BattleStageActor> GetAllTargets(){
		return targets;
	}

	/// <summary>
	/// 检查仇恨列表中是否有该目标
	/// </summary>
	/// <returns><c>true</c>, if has threat was checked, <c>false</c> otherwise.</returns>
	/// <param name="bsa">Bsa.</param>
	public bool CheckHasThreat(BattleStageActor bsa){
		if (targets.Contains (bsa))
			return true;
		return false;
	}

	/// <summary>
	/// 添加仇恨目标
	/// </summary>
	/// <param name="bsa">Bsa.</param>
	public void AddThreatTarget(BattleStageActor bsa){
		if (targets.Contains (bsa))
			return;

		addThreatData (bsa);

		sort ();
	}

	/// <summary>
	/// 添加受击仇恨值
	/// </summary>
	public void AddHitValue(BattleStageActor bsa, int v){
		if (!targets.Contains (bsa))
			addThreatData (bsa);

		float v1 = v * 1.0f;
		for(int i = 0;i < threats.Count;i++){
			if (threats [i].target == bsa) {
				var tStruct = threats [i];
				tStruct.AddHitValue (v1);
				threats [i] = tStruct;
			}
			
		}

		sort ();
	}

	/// <summary>
	/// 移除仇恨目标
	/// </summary>
	/// <param name="bsa">Bsa.</param>
	public void RemoveThreatTarget(BattleStageActor bsa){
		if (!targets.Contains (bsa))
			return;

		for(int i = 0;i < threats.Count;i++){
			if (threats [i].target == bsa) {
				threats.RemoveAt (i);
				break;
			}
		}
		targets.Remove (bsa);

		sort ();
	}

	/// <summary>
	/// 刷新仇恨数据
	/// </summary>
	public void UpdateThreats(){
		if (threats.Count <= 0)
			return;

		for(int i = 0;i < threats.Count;i++){
			if (threats [i].target == null) {
				threats.RemoveAt (i);
				targets.RemoveAt (i);
				i--;
				continue;
			}
			var tStruct = threats [i];
			tStruct.SetDistanceValue (zTools.DistanceZeroY (threats[i].target.transform.position, stageActor.transform.position));
			threats [i] = tStruct;
		}

		sort ();
	}




	#endregion

	#region Private

	/// <summary>
	/// 添加仇恨数据
	/// </summary>
	/// <param name="bsa">Bsa.</param>
	void addThreatData(BattleStageActor bsa){
		Debug.Log ("addThreatData  ");

		ThreatData td = new ThreatData (bsa, initThreatValue);
		threats.Add (td);
		targets.Add (bsa);
	}

	/// <summary>
	/// 按仇恨值冒泡排序
	/// </summary>
	void sort(){
		if (threats.Count <= 0) {
			currentThreatData = null;
			return;
		}

		for(int i = 0;i < (threats.Count - 1);i++){
			if (threats [i + 1].GetValue() > threats [i].GetValue()) {
				var temp = threats [i];
				threats [i] = threats[i + 1];
				threats [i + 1] = temp;
			}
		}

		currentThreatData = threats [0];
	}

	#endregion 

}

[Serializable]
public struct ThreatData{
	/// <summary>
	/// 仇恨对象
	/// </summary>
	public BattleStageActor target;
	/// <summary>
	/// 受击仇恨值
	/// </summary>
	float hitValue;
	/// <summary>
	/// 距离仇恨值
	/// </summary>
	float distanceValue;
	/// <summary>
	/// 初始仇恨值
	/// </summary>
	float initValue;

	public ThreatData(BattleStageActor bsa, float v1){
		target = bsa;
		initValue = v1;
		distanceValue = 0;
		hitValue = 0;
	}

	public float GetValue(){
		return distanceValue + initValue + hitValue;
	}

	public void AddHitValue(float v1){
		hitValue += v1;
	}

	public void SetDistanceValue(float v1){
		distanceValue = v1;
	}
}
