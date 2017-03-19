using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class BuffMgr {


	#region Member

	Dictionary<string, BuffCompute> buffs = new Dictionary<string, BuffCompute>();

	#endregion


	#region Interface

	/// <summary>
	/// 添加buff
	/// </summary>
	/// <param name="_buffdata">Buffdata.</param>
	public void AddBuff(BuffData _buffdata){
		#if EditorDebug
		EditorDebug.Log ("添加buffId :[" + _buffdata.buffId + "] name :[" + JSONBuffData.instance.GetName(_buffdata.buffId) + "  attacker :[" + _buffdata.attackerData.logName + "]  hiter :[" + _buffdata.hiterData.logName + "]");
		#endif	


		BuffCompute _bb = new BuffCompute (_buffdata, 1);

		_bb.BuffBegin ();
	}

	/// <summary>
	/// 移除buff
	/// </summary>
	/// <param name="_buffId">Buff identifier.</param>
	public void RemoveBuff(string _buffId){
		if (!buffs.ContainsKey (_buffId))
			return;

		buffs [_buffId].BuffFinish ();
		buffs.Remove (_buffId);
	}

	/// <summary>
	/// 检查是否有某个buff
	/// </summary>
	/// <param name="_buffId">Buff identifier.</param>
	public bool CheckHasBuff(string _buffId){
		if (buffs.ContainsKey (_buffId))
			return true;
		return false;
	}



	#endregion


	public struct BuffData{
		/// <summary>
		/// buffID
		/// </summary>
		public string buffId;
		/// <summary>
		/// 攻击方
		/// </summary>
		public ActorData attackerData;
		/// <summary>
		/// 被攻击方
		/// </summary>
		public ActorData hiterData;
		/// <summary>
		/// 伤害比例
		/// </summary>
		public int power;
	}
}
