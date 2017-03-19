using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class FSM {

	[SerializeField]
	StatePath currentState;
	[SerializeField]
	StatePath lastState;
	public float stateTime;

	[SerializeField]
	Dictionary<string, StatePath> allState = new Dictionary<string, StatePath>();

	/// <summary>
	/// 添加状态
	/// </summary>
	/// <param name="_s">S.</param>
	/// <param name="_enter">Enter.</param>
	/// <param name="_update">Update.</param>
	/// <param name="_leave">Leave.</param>
	public void AddState(StatePath _s, VoidDelegate _enter = null, VoidDelegateFloat _update = null, VoidDelegate _leave = null){
		if(!allState.ContainsKey(_s.stateName)){
			_s.BindStateMethod (_enter, _update, _leave);
			allState.Add (_s.stateName, _s);
		}

	}

	/// <summary>
	/// 设置状态
	/// </summary>
	/// <param name="_s">S.</param>
	public void SetState(StatePath _s){
		if (!allState.ContainsKey(_s.stateName) || currentState == _s)
			return;

		if(currentState != null)
			currentState.ExecuteLeave ();
		

		lastState = currentState;
		currentState = _s;
		stateTime = 0;
		currentState.ExecuteEnter ();

	}

	/// <summary>
	/// 是否是当前状态
	/// </summary>
	/// <returns><c>true</c> if this instance is state the specified _s; otherwise, <c>false</c>.</returns>
	/// <param name="_s">S.</param>
	public bool IsState(StatePath _s){
		if (currentState.stateName == _s.stateName) {
			return true;
		}


		return false;
	}

	/// <summary>
	/// 返回上个状态
	/// </summary>
	/// <returns>The state.</returns>
	public StatePath LastState(){
		return lastState;
	}

	/// <summary>
	/// 设置为上个状态
	/// </summary>
	public void ToLastState(){
		if (currentState == lastState)
			return;

		currentState.ExecuteLeave ();
		lastState.ExecuteEnter();
		StatePath cachedCurrentState = currentState;
		currentState = lastState;
		lastState = cachedCurrentState;
		stateTime = 0;
	}

	/// <summary>
	/// 更新状态
	/// </summary>
	/// <param name="dt">Dt.</param>
	public void UpdateState(float dt){
		stateTime += dt;
		currentState.ExecuteUpdate (dt);
	}
}
