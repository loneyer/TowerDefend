using UnityEngine;
using System.Collections;

public class UIBlood : MonoBehaviour {

	#region Member

	UISlider hpSlider;

	bool hpShowed;

	#endregion

	#region Interface

	/// <summary>
	/// 初始化血条
	/// </summary>
	/// <param name="f">F.</param>
	public void InitHP(float f){
		hpSlider.value = f;
		hpSlider.gameObject.SetActive (false);
		hpShowed = false;
	}

	/// <summary>
	/// 更新血条
	/// </summary>
	/// <param name="f">F.</param>
	public void UpdateHP(float f){
		if (!hpShowed) {
			hpSlider.gameObject.SetActive (true);
			hpShowed = true;
		}

		hpSlider.value = f;
	}

	#endregion


	#region Awake 等方法

	void Awake(){
		hpSlider = GetComponentInChildren<UISlider> ();
	}

	#endregion
}
