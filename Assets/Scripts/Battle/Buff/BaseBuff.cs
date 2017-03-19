using UnityEngine;
using System.Collections;

public class BaseBuff {

	#region Member

	BuffMgr.BuffData buffdata;

	FSM state = new FSM();
	StatePath active_state = new StatePath ("active");
	StatePath clear_state = new StatePath("clear");



	#endregion


	public BaseBuff(BuffMgr.BuffData _buffdata){
		buffdata = _buffdata;

		initFSM ();
	}

	void initFSM(){
		state.AddState (active_state, OnActiveEnter, OnActiveUpdate, OnActiveExit);
		state.AddState (clear_state, OnClearEnter);
		state.SetState (active_state);
	}

	void OnActiveEnter(){
		
	}
	void OnActiveUpdate(float dt){
		
	}
	void OnActiveExit(){
		
	}

	void OnClearEnter(){
		
	}

}
