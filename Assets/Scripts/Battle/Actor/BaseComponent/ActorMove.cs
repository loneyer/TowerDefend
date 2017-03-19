using UnityEngine;
using System.Collections;

public class ActorMove : ActorComponent {

	#region Member

	int _curMoveIndex = 0;
	public Vector3 target;
	public bool canMove = false;
	float smooth = 20.0f;

	public float endDistance = 0.1f;

	float cachedMoveSpeed;

	#endregion

	#region FSM

	FSM _state = new FSM();
	StatePath _sleep_state = new StatePath("sleep");
	StatePath _searchTarget_state = new StatePath("searchTarget");
	StatePath _run_state = new StatePath("run");

	void setState(StatePath _sp){
		if (_state.IsState (_sp))
			return;

		_state.SetState (_sp);
	}

	void initFSM(){
		_state.AddState (_sleep_state, onSleepEnter);	
		_state.AddState (_searchTarget_state, onSearchTargetEnter);
		_state.AddState (_run_state, onRunEnter, onRunUpdate);
		_state.SetState (_sleep_state);
	}

	void onSleepEnter(){
	}

	void onSearchTargetEnter(){
		target = EnemyPointManager.instance.GetNextPos (_curMoveIndex);
		_curMoveIndex++;

		if (target == Vector3.zero)
			setState (_sleep_state);
		else {
			setState (_run_state);
		}
	}


	void onRunEnter(){
	}
	void onRunUpdate(float dt){
		if (!canMove)
			return;
		transform.LookAt (target);
		transform.position = Vector3.MoveTowards (transform.position, target, dt * smooth * cachedMoveSpeed);
	}

	#endregion

	#region Interface

	public void ToSearchState(){
		setState (_searchTarget_state);
	}



	#endregion


	#region Private

	bool isNearFootTarget(){
		float dis = zTools.DistanceZeroY (transform.position, target);
		return dis < endDistance ? true : false; 
	}


	#endregion

	#region Callback

	void onMoveSpeedChange(ValueFloat v1, float v2){
		cachedMoveSpeed = v1.GetValue ();
	}

	#endregion

	#region 重写

	protected override void OnBind ()
	{
		base.OnBind ();

		stageActor.actordata.AddValueChange (Tags.MoveSpeed, onMoveSpeedChange);
	}

	protected override void OnUnbind ()
	{
		base.OnUnbind ();
	}

	#endregion

	#region Awake 等方法

	protected override void OnAwake ()
	{
		base.OnAwake ();
		initFSM ();
		cachedMoveSpeed = stageActor.actordata.GetValue (Tags.MoveSpeed);
	}

	void Update(){

		_state.UpdateState (Time.deltaTime);
	}


	#endregion
}
