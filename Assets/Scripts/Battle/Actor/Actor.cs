using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	#region Member

	ActorData _actordata;
	public ActorData actordata{
		get{ 
			if (_actordata == null)
				_actordata = new ActorData ();
			return _actordata;
		}

	}

	string _actorId;
	public string actorId{
		get { 
			return _actorId;
		}
	}

	BuffMgr _buffMgr;
	public BuffMgr buffMgr{
		get{ 
			if (_buffMgr == null)
				_buffMgr = new BuffMgr ();
			return _buffMgr;
		}
	}



	public ActorMessageProvider message = new ActorMessageProvider();

	#endregion

	#region Interface

	public void Init(string id){
		_actorId = id;
		actordata.actorTr = transform;

		InitData ();
	}

	#endregion



	#region Awake 等方法

	void Awake(){
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


	public virtual void InitData(){
		OnBind ();
	}



	protected virtual void OnBind(){
		message.Bind (enActorState.onDie, OnDespawn);
	}

	protected virtual void OnUnbind(){
		message.Unbind (enActorState.onDie, OnDespawn);
	}

	protected virtual void OnDespawn(){
		OnUnbind ();
	}
	#endregion

}
