using UnityEngine;
using System.Collections;

public class SkillTrigger : MonoBehaviour {

	System.Action<Collider> onTriggerEtnerCB;
	System.Action<Collider> onTriggerUpdateCB;
	System.Action<Collider> onTriggerExitCB;

	public void BindTriggerEnter(System.Action<Collider> _enter){
		onTriggerEtnerCB += _enter;
	}
	public void BindTriggerUpdate(System.Action<Collider> _update){
		onTriggerUpdateCB += _update;
	}
	public void BindTriggerExit(System.Action<Collider> _exit){
		onTriggerExitCB += _exit;
	}

	public void UnbindTriggerEnter(System.Action<Collider> _enter){
		onTriggerEtnerCB -= _enter;
	}
	public void UnbindTriggerUpdate(System.Action<Collider> _update){
		onTriggerUpdateCB -= _update;
	}
	public void UnbindTriggerExit(System.Action<Collider> _exit){
		onTriggerExitCB -= _exit;
	}


	void OnTriggerEnter(Collider collisioner){
		if (onTriggerEtnerCB != null)
			onTriggerEtnerCB (collisioner);
	}
	void OnTriggerStay(Collider collisioner){
		if(onTriggerUpdateCB != null)
			onTriggerUpdateCB (collisioner);
	}
	void OnTriggerExit(Collider collisioner){
		if (onTriggerExitCB != null)
			onTriggerExitCB (collisioner);
	}

}
