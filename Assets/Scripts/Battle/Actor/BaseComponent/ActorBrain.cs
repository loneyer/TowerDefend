using UnityEngine;
using System.Collections;

public class ActorBrain : ActorComponent {

	#region Member
	float birthTime;

	protected ActorEye eye;
	protected ActorMove foot;
	protected ActorHand hand;

	#endregion

	#region 重写

	protected override void OnAwake ()
	{
		base.OnAwake ();
		birthTime = Time.time;

		initFSM ();
		initComponent ();

		ToIdleState ();
	}

	protected override void OnBind ()
	{
		base.OnBind ();

	}

	protected override void OnUnbind ()
	{
		base.OnUnbind ();
	}

	protected override void OnDespawn ()
	{
		base.OnDespawn ();
	}

	#endregion

	#region FSM


	protected FSM _state = new FSM();
	protected StatePath _sleep_state = new StatePath("sleep");
	protected StatePath _idle_state = new StatePath("idle");
	protected StatePath _run_state = new StatePath("run");
	protected StatePath _waitAttack_state = new StatePath ("waitAttack");
	protected StatePath _attack_state = new StatePath("attack");


	protected void setState(StatePath _sp){
		if (_state.IsState (_sp)) {
			return;
		}

		_state.SetState (_sp);
	}

	void initFSM(){
		_state.AddState (_sleep_state, onSleepEnter);
		_state.AddState (_idle_state, onIdleEnter, onIdleUpdate);
		_state.AddState (_run_state, onRunEnter, onRunUpdate, onRunExit);
		_state.AddState (_waitAttack_state, onWaitAttackEnter, onWaitAttackUpdate, onWaitAttackExit);
		_state.AddState (_attack_state, onAttackEnter, onAttackUpdate, onAttackExit);
		_state.SetState (_sleep_state);
	}

	protected virtual void onSleepEnter(){
		
	}

	protected virtual void onIdleEnter(){
		
	}
	protected virtual void onIdleUpdate(float dt){

			
	}

	protected virtual void onRunEnter(){
		
	}
	protected virtual void onRunUpdate(float dt){
		


	}
	protected virtual void onRunExit(){
		
	}

	protected virtual void onWaitAttackEnter(){
	
	}
	protected virtual void onWaitAttackUpdate(float dt){
	
	}
	protected virtual void onWaitAttackExit(){
	}

	protected virtual void onAttackEnter(){
	
	}
	protected virtual void onAttackUpdate(float dt){
	
	}
	protected virtual void onAttackExit(){
	
	}

	#endregion

	#region Interface

	public void ToIdleState(){
		setState (_idle_state);
	}

	#endregion

	#region Private

	void initComponent(){
		gameObject.AddComponent<ActorBuffAndSkill> ();

		eye = gameObject.AddComponent<ActorEye> ();
		foot = gameObject.AddComponent <ActorMove> ();

		hand = gameObject.AddComponent<ActorHand> ();
	}




	#endregion

	#region Action

	protected bool isNearFootTarget(){
		float dis = zTools.DistanceZeroY (transform.position, foot.target);
		return dis < foot.endDistance ? true : false; 
	}

	protected void toAttack(){
		hand.Attack ();
	} 


	void updateThreatData(){
		if (Time.time - birthTime >= 0.5f) {
			birthTime = Time.time;
			eye.UpdateThreatDataBySeekDistance ();
			stageActor.threat.UpdateThreats ();
		}


	}
	#endregion

	#region Awake 等方法

	void Update(){
		_state.UpdateState (Time.deltaTime);

		updateThreatData ();
	}

	#endregion

}
