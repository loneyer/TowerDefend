using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class StatePath {
	public string stateName;

	VoidDelegate onEnter;
	VoidDelegateFloat onUpdate;
	VoidDelegate onLeave;

	public StatePath(string _name){
		stateName = _name;
	}

	public void BindStateMethod(VoidDelegate _enter, VoidDelegateFloat _update, VoidDelegate _leave){
		onEnter = _enter;
		onUpdate = _update;
		onLeave = _leave;
	}

	public void ExecuteEnter(){
		if (onEnter != null)
			onEnter ();
	}

	public void ExecuteUpdate(float dt){
		if (onUpdate != null)
			onUpdate (dt);
	}

	public void ExecuteLeave(){
		if (onLeave != null)
			onLeave ();
	}



}
