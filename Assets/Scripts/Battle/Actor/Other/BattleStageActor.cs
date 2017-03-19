using UnityEngine;
using System.Collections;

public class BattleStageActor : Actor {

	#region Member

	enEnterStageWay enterStageWay;
	public Threat threat;

	public BattleStageActor currentThreatTarget{
		get{
			return threat.currentThreatData.Value.target;
		}
	}

	ActorBuffAndSkill _cachedBuffAndSkill;
	public ActorBuffAndSkill buffAndSkill{
		get{ 
			if (_cachedBuffAndSkill == null)
				_cachedBuffAndSkill = GetComponent<ActorBuffAndSkill> ();

			if (_cachedBuffAndSkill == null)
				return null;
			return _cachedBuffAndSkill;
		}
	} 

	MyObj _myobj;
	public MyObj myobj{
		get{
			if (_myobj == null)
				_myobj = GetComponentInChildren<MyObj> ();

			return _myobj;
		}
	}

	#endregion

	#region Interface

	public void EnterStage(enEnterStageWay way){
		enterStageWay = way;
		EnterStageBegin ();
	}

	public void SetPosition(Vector3 pos){
		Vector3 v3 = new Vector3 (pos.x, 0, pos.z);
		transform.localPosition = v3;	
	}

	#endregion

	#region Condition

	public bool DifferentCamp(Actor _act){
		return !(actordata.actorCamp == _act.actordata.actorCamp);
	}

	/// <summary>
	/// 与_act的距离是否小于指定长度
	/// </summary>
	/// <returns><c>true</c>, if less length was distanced, <c>false</c> otherwise.</returns>
	/// <param name="_act">Act.</param>
	/// <param name="_length">Length.</param>
	public bool DistanceLessLength(Actor _act, float _length){
		float dis = zTools.DistanceZeroY (_act.transform.position, transform.position);
		return dis <= _length;
	}

	#endregion

	#region EnterStage

	protected virtual void EnterStageBegin(){
		switch(enterStageWay){
		case enEnterStageWay.enAppearance:
			EnterStageFinish ();
			break;
		case enEnterStageWay.enByComing:

			break;
		}
	}

	protected virtual void EnterStageFinish(){
		InitComponent ();
	}

	protected virtual void InitComponent(){

	}

	#endregion

	public Threat GetThreat(){
		return threat;
	}

	#region Awake 等方法

	protected override void OnAwake ()
	{
		base.OnAwake ();
		threat = new Threat (this);
	}

	#endregion
}
