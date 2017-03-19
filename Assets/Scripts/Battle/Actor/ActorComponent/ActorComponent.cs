using UnityEngine;
using System.Collections;

public class ActorComponent : MonoBehaviour {

	#region Member

	BattleStageActor _actor;
	public BattleStageActor stageActor{
		get{
			if (_actor == null)
				_actor = GetComponent<BattleStageActor> ();
			return _actor;
		}
	}

	#endregion

	#region Awake 等方法

	void Awake(){
		OnBind ();
		OnAwake ();
	}

	void Start(){
		OnStart ();
	}


	#endregion


	#region 重写

	protected virtual void OnAwake(){
		
	}

	protected virtual void OnStart(){
		
	}

	protected virtual void OnBind(){
		stageActor.message.Bind (enActorState.onDie, OnDespawn);
	}

	protected virtual void OnUnbind(){
		
	}

	protected virtual void OnDespawn(){
		stageActor.message.Unbind (enActorState.onDie, OnDespawn);
	}

	#endregion

	#region 接口

	/// <summary>
	/// 绑定无参回调
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void Bind(System.Enum id, VoidMPCallback _cb){
		stageActor.message.Bind (id, _cb);
	}

	/// <summary>
	/// 绑定有参回调
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void Bind(System.Enum id, VoidMPCallbackObj _cb){
		stageActor.message.Bind (id, _cb);
	}

	/// <summary>
	/// 绑定返回整型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void BindInt(System.Enum id, IntMPCallbackObj _cb){
		stageActor.message.BindInt (id, _cb);
	}
	/// <summary>
	/// 绑定返回浮点型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void BindFloat(System.Enum id, FloatMPCallbackObj _cb){
		stageActor.message.BindFloat (id, _cb);
	}
	/// <summary>
	/// 绑定返回布尔型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void BindBool(System.Enum id, BoolMPCallbackObj _cb){
		stageActor.message.BindBool (id, _cb);
	}
	/// <summary>
	/// 绑定返回字符串
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void BindString(System.Enum id, StringMPCallbackObj _cb){
		stageActor.message.BindString (id, _cb);
	}


	/// <summary>
	/// 解绑有参回调
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void Unbind(System.Enum id, VoidMPCallbackObj _cb){
		stageActor.message.Unbind (id, _cb);
	}
	/// <summary>
	/// 解绑无参回调
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void Unbind(System.Enum id, VoidMPCallback _cb){
		stageActor.message.Unbind (id, _cb);
	}

	/// <summary>
	/// 解绑返回整型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void UnbindInt(System.Enum id, IntMPCallbackObj _cb){
		stageActor.message.UnbindInt (id, _cb);
	}
	/// <summary>
	/// 解绑返回浮点型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void UnbindFloat(System.Enum id, FloatMPCallbackObj _cb){
		stageActor.message.UnbindFloat (id, _cb);
	}
	/// <summary>
	/// 解绑返回布尔型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void UnbindBool(System.Enum id, BoolMPCallbackObj _cb){
		stageActor.message.UnbindBool (id, _cb);
	}
	/// <summary>
	/// 解绑返回字符串型
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="_cb">Cb.</param>
	protected void UnbindString(System.Enum id, StringMPCallbackObj _cb){
		stageActor.message.UnbindString (id, _cb);
	}

	/// <summary>
	/// 执行有参回调
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="objs">Objects.</param>
	protected void Execute(System.Enum id, object[] objs){
		stageActor.message.Execute (id, objs);
	}
	/// <summary>
	/// 执行无参回调
	/// </summary>
	/// <param name="id">Identifier.</param>
	protected void Execute(System.Enum id){
		stageActor.message.Execute (id);
	}

	/// <summary>
	/// 执行返回整型
	/// </summary>
	/// <returns>The int.</returns>
	/// <param name="id">Identifier.</param>
	/// <param name="objs">Objects.</param>
	protected int ExecuteInt(System.Enum id, object[] objs){
		return stageActor.message.ExecuteInt (id, objs);
	}
	/// <summary>
	/// 执行返回浮点型
	/// </summary>
	/// <returns>The float.</returns>
	/// <param name="id">Identifier.</param>
	/// <param name="objs">Objects.</param>
	protected float ExecuteFloat(System.Enum id, object[] objs){
		return stageActor.message.ExecuteFloat (id, objs);
	}
	/// <summary>
	/// 执行返回布尔型
	/// </summary>
	/// <returns><c>true</c>, if bool was executed, <c>false</c> otherwise.</returns>
	/// <param name="id">Identifier.</param>
	/// <param name="objs">Objects.</param>
	protected bool ExecuteBool(System.Enum id, object[] objs){
		return stageActor.message.ExecuteBool (id, objs);
	}
	/// <summary>
	/// 执行返回字符串型
	/// </summary>
	/// <returns><c>true</c>, if string was executed, <c>false</c> otherwise.</returns>
	/// <param name="id">Identifier.</param>
	/// <param name="objs">Objects.</param>
	protected string ExecuteString(System.Enum id, object[] objs){
		return stageActor.message.ExecuteString (id, objs);
	}


	#endregion


}
