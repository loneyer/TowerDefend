using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseSkillClip : MonoBehaviour{

	#region Member
	protected string skillMapId;
	protected SkillData skillData;

	GameObject fireEffect;
	GameObject firingEffect;
	GameObject fireFinishEffect;

	string fireEffectStr = "effect_normalSkill";
	string firingEffectStr = "effect_normalSkill";
	string fireFinishEffectStr = "effect_normalSkill";

	SkillTrigger[] skillTriggers;
	

	#endregion

	#region FSM
	FSM _state = new FSM();

	protected StatePath fire_state = new StatePath("Fire");
	protected StatePath firing_state = new StatePath("Firing");
	protected StatePath fireFinish_state = new StatePath("FireFinish");
	protected StatePath destory_state = new StatePath("Destory");

	protected void setState(StatePath _sp){
		if (_state.IsState (_sp))
			return;

		_state.SetState (_sp);
	}

	void initFSM(){
		_state.AddState (fire_state, onFireEnter, onFireUpdate, onFireExit);
		_state.AddState (firing_state, onFiringEnter, onFiringUpdate, onFiringExit);
		_state.AddState (fireFinish_state, onFireFinishEnter, onFireFinishUpdate, onFireFinishExit);
		_state.AddState (destory_state, onDestoryEnter, onDestoryUpdate, onDestoryExit);
		_state.SetState (fire_state);
	}

	protected virtual void onFireEnter(){
		if (fireEffectStr != "") {
			fireEffect = ObjManager.instance.GetGameObject (GamePath.EffectPath, fireEffectStr, transform);
			bindSkillTrigger ();
		}
	}
	protected virtual void onFireUpdate(float dt){
		
	}
	protected virtual void onFireExit(){
		if (fireEffect != null) {
			unbindSkillTrigger ();
			ObjManager.instance.Despawn (fireEffect);
			fireEffect = null;
		}
	}

	protected virtual void onFiringEnter(){
		if (firingEffectStr != "") {
			firingEffect = ObjManager.instance.GetGameObject (GamePath.EffectPath, firingEffectStr, transform);
			bindSkillTrigger ();
		}
	}
	protected virtual void onFiringUpdate(float dt){
		
	}
	protected virtual void onFiringExit(){
		if (firingEffect != null) {
			ObjManager.instance.Despawn (firingEffect);
			firingEffect = null;
			unbindSkillTrigger ();
		}
	}

	protected virtual void onFireFinishEnter(){
		if (fireFinishEffectStr != "") {
			fireFinishEffect = ObjManager.instance.GetGameObject (GamePath.EffectPath, fireFinishEffectStr, transform);
			bindSkillTrigger ();
		}
	}
	protected virtual void onFireFinishUpdate(float dt){
		
	}
	protected virtual void onFireFinishExit(){
		if (fireFinishEffect != null) {
			unbindSkillTrigger ();
			ObjManager.instance.Despawn (fireFinishEffect);
			fireFinishEffect = null;
		}
	}

	protected virtual void onDestoryEnter(){
		if (fireEffect != null)
			ObjManager.instance.Despawn (fireEffect);
		
		if (firingEffect != null)
			ObjManager.instance.Despawn (firingEffect);
		
		if (fireFinishEffect != null)
			ObjManager.instance.Despawn (fireFinishEffect);

		GameObject.Destroy (gameObject);

	}
	protected virtual void onDestoryUpdate(float dt){
	
	}
	protected virtual void onDestoryExit(){
		
	}

	#endregion

	#region Private

	void bindSkillTrigger(){
		skillTriggers = GetComponentsInChildren<SkillTrigger> ();

		for(int i = 0;i < skillTriggers.Length;i++){
			skillTriggers [i].BindTriggerEnter (onSkillTriggerEnter);
			skillTriggers [i].BindTriggerUpdate (onSkillTriggerStay);
			skillTriggers [i].BindTriggerExit (onSkillTriggerExit);
		}
	}
	void unbindSkillTrigger(){
		for(int i = 0;i < skillTriggers.Length;i++){
			skillTriggers [i].UnbindTriggerEnter (onSkillTriggerEnter);
			skillTriggers [i].UnbindTriggerUpdate (onSkillTriggerStay);
			skillTriggers [i].UnbindTriggerExit (onSkillTriggerExit);
		}
	}

	protected virtual void onSkillTriggerEnter(Collider _collider){
	}
	protected virtual void onSkillTriggerStay(Collider _collider){
	
	}
	protected virtual void onSkillTriggerExit(Collider _collider){
	
	}

	#endregion

	#region Interface

	public void Init(SkillData _sd){
		skillData = _sd;
		skillData.buffs = new string[] { "30001" };
		skillData.compareContent = enCampCompare.enDifferent;
		skillData.lockTarget = true;
		initFSM ();
	}

	#endregion

	#region Awake 等方法

	void Update(){
		_state.UpdateState (Time.deltaTime);
	}

	#endregion
}

public struct SkillData{
	/// <summary>
	/// 技能表中的id
	/// </summary>
	public string skillId;
	/// <summary>
	/// 攻击者数据
	/// </summary>
	public ActorData attackerData;
	/// <summary>
	/// 被攻击者数据
	/// </summary>
	public ActorData hiterData;
	/// <summary>
	/// 目标坐标
	/// </summary>
	public Vector3 targetPos;
	/// <summary>
	/// 技能伤害比率
	/// </summary>
	public int power;
	/// <summary>
	/// 添加的buff
	/// </summary>
	public string[] buffs;
	/// <summary>
	/// 阵营过滤
	/// </summary>
	public enCampCompare compareContent;
	/// <summary>
	/// 是否锁定目标
	/// </summary>
	public bool lockTarget;
}






public interface ISkillEnter{
	void OnSkillEnter (SkillData skillData);
}