using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UIFollow {

	public static Camera cameraMain{
		get{ 
			return Camera.main;
		}
	}

	static Camera _uicamera;
	public static Camera uicamera{
		get{ 
			if (_uicamera == null)
				_uicamera = GameObject.Find("UICamera2D").GetComponent<Camera> ();
			if (_uicamera == null)
				Debug.LogError ("场景中没有 2D相机");
			 
			return _uicamera;
		}
	}

	Transform _uifollowParent;
	public Transform uifollowParent{
		get{
			if (_uifollowParent == null) {
				_uifollowParent = new GameObject ("uifollowParent").transform;
				_uifollowParent.parent = uicamera.transform;
				_uifollowParent.localScale = Vector3.one;
				_uifollowParent.localPosition = Vector3.zero;
			}

			return _uifollowParent;
		}
	}

	Dictionary<Transform,UIFollowData> follows = new Dictionary<Transform, UIFollowData>();
	List<UIFollowData> followsData = new List<UIFollowData>();

	public void AddFollower(Transform _model, Transform _follower){
		if (!follows.ContainsKey (_model)) {
			_follower.parent = uifollowParent;
			_follower.localScale = Vector3.one;
			var _data = new UIFollowData (_model, _follower);
			follows.Add (_model, _data);
			followsData.Add (_data);
		}
	}

	public void RemoveFollower(Transform _model){
		if(follows.ContainsKey(_model)){
			followsData.Remove (follows[_model]);
			follows.Remove (_model);
		}
	}

	public void LateUpdateFollowsPos(){
		for(int i = 0;i < followsData.Count;i++){
			followsData [i].LateUpdatePos ();
		}
	}

}

public struct UIFollowData{
	/// <summary>
	/// 目标
	/// </summary>
	public Transform target;
	/// <summary>
	/// 跟随者
	/// </summary>
	public Transform follower;
	/// <summary>
	/// 屏幕坐标
	/// </summary>
	public Vector3 screenPos;
	/// <summary>
	/// 视窗坐标
	/// </summary>
	public Vector3 viewPos;

	public UIFollowData(Transform _target, Transform _follower){
		target = _target;
		follower = _follower;
		screenPos = Vector3.zero;
		viewPos = Vector3.zero;
	}

	public void LateUpdatePos(){
		screenPos = UIFollow.cameraMain.WorldToScreenPoint (target.position);
		viewPos = UIFollow.uicamera.ScreenToWorldPoint (new Vector3 (screenPos.x, screenPos.y, UIFollow.uicamera.nearClipPlane));
		viewPos.z = 0;
		follower.position = viewPos;
	}
}
