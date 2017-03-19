using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager> {

	#region Member

	string prefabHPStr = "UIBlood";
	/// <summary>
	/// 所有的血条
	/// </summary>
	Dictionary<Transform, UIBlood> HPS = new Dictionary<Transform, UIBlood>();


	UIFollow uifollow = new UIFollow();
	#endregion

	#region Private

	/// <summary>
	/// 创建血条
	/// </summary>
	/// <param name="objs">Objects.</param>
	void createHP(object[] objs){
		Transform _model = (Transform)objs [0];
		if (!HPS.ContainsKey (_model)) {
			var go = ObjManager.instance.GetGameObject (GamePath.BattleUI, prefabHPStr).GetComponent<UIBlood> ();
			HPS.Add (_model, go);

			uifollow.AddFollower (_model, go.transform);
		}

		HPS [_model].InitHP (1.0f);
	}

	/// <summary>
	/// 更新血条
	/// </summary>
	/// <param name="objs">Objects.</param>
	void updateHP(object[] objs){
		Transform _model = (Transform)objs [0];
		float _percentage = (float)objs [1];

		if(!HPS.ContainsKey(_model))
			HPS.Add (_model, ObjManager.instance.GetGameObject (GamePath.BattleUI, prefabHPStr, _model).GetComponent<UIBlood> ());

		HPS [_model].UpdateHP (_percentage);
	}

	/// <summary>
	/// 移除血条
	/// </summary>
	/// <param name="objs">Objects.</param>
	void removeHP(object[] objs){
		Transform _model = (Transform)objs [0];
		if (HPS.ContainsKey (_model)) {
			HPS.Remove (_model);
			uifollow.RemoveFollower (_model);
			ObjManager.instance.Despawn (_model.gameObject);
		}
	}

	#endregion

	#region Interface

	public void Init(){
	
	}

	#endregion

	// Use this for initialization
	void Start () {
		MessageProvider.Instance.Bind (enBattleUIAction.enCreateHP, createHP);
		MessageProvider.Instance.Bind (enBattleUIAction.enUpdateHP, updateHP);
		MessageProvider.Instance.Bind (enBattleUIAction.enRemoveHP, removeHP);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		uifollow.LateUpdateFollowsPos ();
	}
}
