using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 消息中心
/// </summary>
public class MessageProvider{

	static MessageProvider _instance;
	public static MessageProvider Instance{
		get{ 
			if(_instance == null){
				_instance = new MessageProvider ();
			}
			return _instance;
		}

	}




	#region 有参回调

	Dictionary<System.Enum, MessagerObj> messageObj = new Dictionary<System.Enum, MessagerObj>();

	public void Bind(System.Enum id, VoidMPCallbackObj _cb){
		if (!messageObj.ContainsKey (id)) {
			MessagerObj mgr = new MessagerObj (null);
			messageObj.Add (id, mgr);
		}

		messageObj [id].BindCallback (_cb);
	}

	public void Unbind(System.Enum id, VoidMPCallbackObj _cb){
		if(messageObj.ContainsKey(id)){
			messageObj [id].UnbindCallback (_cb);
		}
	}

	public void Execute(System.Enum id, params object[] objs){
		if (messageObj.ContainsKey (id)) {
			messageObj [id].Execute (objs);
		}
	}

	#endregion

	#region 无参回调

	Dictionary<System.Enum, Message> message = new Dictionary<System.Enum, Message>();

	public void Bind(System.Enum id, VoidMPCallback _cb){
		if (!message.ContainsKey (id)) {
			Message mgr = new Message (null);
			message.Add (id, mgr);
		}

		message [id].BindCallback (_cb);
	}

	public void Unbind(System.Enum id, VoidMPCallback _cb){
		if(message.ContainsKey(id)){
			message [id].UnbindCallback (_cb);
		}
	}

	public void Execute(System.Enum id){
		if (message.ContainsKey (id)) {
			message [id].Execute ();
		}
	}

	#endregion

	#region 返回整型 

	Dictionary<System.Enum, IntMPCallbackObj> intMessageObj = new Dictionary<System.Enum, IntMPCallbackObj>();

	public void BindInt(System.Enum id, IntMPCallbackObj _cb){
		if (!intMessageObj.ContainsKey (id)) {
			intMessageObj.Add (id, _cb);
		} else {
			intMessageObj [id] += _cb;
		}
	}

	public void UnbindInt(System.Enum id, IntMPCallbackObj _cb){
		if (!intMessageObj.ContainsKey (id)) {
			intMessageObj.Add (id, _cb);
		} else {
			intMessageObj [id] += _cb;
		}
	}

	public int ExecuteInt(System.Enum id, params object[] objs){
		if (intMessageObj.ContainsKey (id)) {
			return intMessageObj [id] (objs);
		}
		return -1;
	}


	#endregion

	#region 返回浮点型 

	Dictionary<System.Enum, FloatMPCallbackObj> flaotMessageObj = new Dictionary<System.Enum, FloatMPCallbackObj>();

	public void BindFloat(System.Enum id, FloatMPCallbackObj _cb){
		if (!flaotMessageObj.ContainsKey (id)) {
			flaotMessageObj.Add (id, _cb);
		} else {
			flaotMessageObj [id] += _cb;
		}
	}

	public void UnbindFloat(System.Enum id, FloatMPCallbackObj _cb){
		if (!flaotMessageObj.ContainsKey (id)) {
			flaotMessageObj.Add (id, _cb);
		} else {
			flaotMessageObj [id] += _cb;
		}
	}

	public float ExecuteFloat(System.Enum id, params object[] objs){
		if (flaotMessageObj.ContainsKey (id)) {
			return flaotMessageObj [id] (objs);
		}
		return -1;
	}


	#endregion

	#region 返回布尔型

	Dictionary<System.Enum, BoolMPCallbackObj> boolMessageObj = new Dictionary<System.Enum, BoolMPCallbackObj>();

	public void BindBool(System.Enum id, BoolMPCallbackObj _cb){
		if (!boolMessageObj.ContainsKey (id)) {
			boolMessageObj.Add (id, _cb);
		} else {
			boolMessageObj [id] += _cb;
		}
	}

	public void UnbindBool(System.Enum id, BoolMPCallbackObj _cb){
		if (!boolMessageObj.ContainsKey (id)) {
			boolMessageObj.Add (id, _cb);
		} else {
			boolMessageObj [id] += _cb;
		}
	}

	public bool ExecuteBool(System.Enum id, params object[] objs){
		if (boolMessageObj.ContainsKey (id)) {
			return boolMessageObj [id] (objs);
		}
		return false;
	}


	#endregion

	#region 返回字符串

	Dictionary<System.Enum, StringMPCallbackObj> stringMessageObj = new Dictionary<System.Enum, StringMPCallbackObj>();

	public void BindString(System.Enum id, StringMPCallbackObj _cb){
		if (!stringMessageObj.ContainsKey (id)) {
			stringMessageObj.Add (id, _cb);
		} else {
			stringMessageObj [id] += _cb;
		}
	}

	public void UnbindString(System.Enum id, StringMPCallbackObj _cb){
		if (!stringMessageObj.ContainsKey (id)) {
			stringMessageObj.Add (id, _cb);
		} else {
			stringMessageObj [id] += _cb;
		}
	}

	public string ExecuteString (System.Enum id, params object[] objs){
		if (stringMessageObj.ContainsKey (id)) {
			return stringMessageObj [id] (objs);
		}
		return "";
	}


	#endregion

	#region 返回浮点型 参数 (float) 消耗低

	Dictionary<System.Enum, FloatMPCallbackFloat> flaotMessageFloat = new Dictionary<System.Enum, FloatMPCallbackFloat>();

	public void BindFloat(System.Enum id, FloatMPCallbackFloat _cb){
		if (!flaotMessageFloat.ContainsKey (id)) {
			flaotMessageFloat.Add (id, _cb);
		} else {
			flaotMessageFloat [id] += _cb;
		}
	}

	public void UnbindFloat(System.Enum id, FloatMPCallbackFloat _cb){
		if (!flaotMessageFloat.ContainsKey (id)) {
			flaotMessageFloat.Add (id, _cb);
		} else {
			flaotMessageFloat [id] += _cb;
		}
	}

	public float ExecuteFloat (System.Enum id, float f1){
		if (flaotMessageFloat.ContainsKey (id)) {
			return flaotMessageFloat [id] (f1);
		}
		return -1;
	}

	#endregion

	#region 返回浮点型 参数 (float, float) 消耗低

	Dictionary<System.Enum, FloatMPCallbackFloatFloat> floatMessageFloat = new Dictionary<System.Enum, FloatMPCallbackFloatFloat>();

	public void BindFloat(System.Enum id, FloatMPCallbackFloatFloat _cb){
		if (!floatMessageFloat.ContainsKey (id)) {
			floatMessageFloat.Add (id, _cb);
		} else {
			floatMessageFloat [id] += _cb;
		}
	}

	public void UnbindFloat(System.Enum id, FloatMPCallbackFloatFloat _cb){
		if (!floatMessageFloat.ContainsKey (id)) {
			floatMessageFloat.Add (id, _cb);
		} else {
			floatMessageFloat [id] += _cb;
		}
	}

	public float ExecuteFloat (System.Enum id, float f1, float f2){
		if (floatMessageFloat.ContainsKey (id)) {
			return floatMessageFloat [id] (f1, f2);
		}
		return -1;
	}

	#endregion
}

/// <summary>
/// Actor类
/// </summary>
public class ActorMessageProvider{
	#region 有参回调

	Dictionary<System.Enum, MessagerObj> messageObj = new Dictionary<System.Enum, MessagerObj>();

	public void Bind(System.Enum id, VoidMPCallbackObj _cb){
		if (!messageObj.ContainsKey (id)) {
			MessagerObj mgr = new MessagerObj (null);
			messageObj.Add (id, mgr);
		}

		messageObj [id].BindCallback (_cb);
	}

	public void Unbind(System.Enum id, VoidMPCallbackObj _cb){
		if(messageObj.ContainsKey(id)){
			messageObj [id].UnbindCallback (_cb);
		}
	}

	public void Execute(System.Enum id, params object[] objs){
		if (messageObj.ContainsKey (id)) {
			messageObj [id].Execute (objs);
		}
	}

	#endregion

	#region 无参回调

	Dictionary<System.Enum, Message> message = new Dictionary<System.Enum, Message>();

	public void Bind(System.Enum id, VoidMPCallback _cb){
		if (!message.ContainsKey (id)) {
			Message mgr = new Message (null);
			message.Add (id, mgr);
		}

		message [id].BindCallback (_cb);
	}

	public void Unbind(System.Enum id, VoidMPCallback _cb){
		if(message.ContainsKey(id)){
			message [id].UnbindCallback (_cb);
		}
	}

	public void Execute(System.Enum id){
		if (message.ContainsKey (id)) {
			message [id].Execute ();
		}
	}

	#endregion

	#region 返回整型 

	Dictionary<System.Enum, IntMPCallbackObj> intMessageObj = new Dictionary<System.Enum, IntMPCallbackObj>();

	public void BindInt(System.Enum id, IntMPCallbackObj _cb){
		if (!intMessageObj.ContainsKey (id)) {
			intMessageObj.Add (id, _cb);
		} else {
			intMessageObj [id] += _cb;
		}
	}

	public void UnbindInt(System.Enum id, IntMPCallbackObj _cb){
		if (!intMessageObj.ContainsKey (id)) {
			intMessageObj.Add (id, _cb);
		} else {
			intMessageObj [id] += _cb;
		}
	}

	public int ExecuteInt(System.Enum id, params object[] objs){
		if (intMessageObj.ContainsKey (id)) {
			return intMessageObj [id] (objs);
		}
		return -1;
	}


	#endregion

	#region 返回浮点型 

	Dictionary<System.Enum, FloatMPCallbackObj> flaotMessageObj = new Dictionary<System.Enum, FloatMPCallbackObj>();

	public void BindFloat(System.Enum id, FloatMPCallbackObj _cb){
		if (!flaotMessageObj.ContainsKey (id)) {
			flaotMessageObj.Add (id, _cb);
		} else {
			flaotMessageObj [id] += _cb;
		}
	}

	public void UnbindFloat(System.Enum id, FloatMPCallbackObj _cb){
		if (!flaotMessageObj.ContainsKey (id)) {
			flaotMessageObj.Add (id, _cb);
		} else {
			flaotMessageObj [id] += _cb;
		}
	}

	public float ExecuteFloat(System.Enum id, params object[] objs){
		if (flaotMessageObj.ContainsKey (id)) {
			return flaotMessageObj [id] (objs);
		}
		return -1;
	}


	#endregion

	#region 返回布尔型

	Dictionary<System.Enum, BoolMPCallbackObj> boolMessageObj = new Dictionary<System.Enum, BoolMPCallbackObj>();

	public void BindBool(System.Enum id, BoolMPCallbackObj _cb){
		if (!boolMessageObj.ContainsKey (id)) {
			boolMessageObj.Add (id, _cb);
		} else {
			boolMessageObj [id] += _cb;
		}
	}

	public void UnbindBool(System.Enum id, BoolMPCallbackObj _cb){
		if (!boolMessageObj.ContainsKey (id)) {
			boolMessageObj.Add (id, _cb);
		} else {
			boolMessageObj [id] += _cb;
		}
	}

	public bool ExecuteBool(System.Enum id, params object[] objs){
		if (boolMessageObj.ContainsKey (id)) {
			return boolMessageObj [id] (objs);
		}
		return false;
	}


	#endregion

	#region 返回字符串

	Dictionary<System.Enum, StringMPCallbackObj> stringMessageObj = new Dictionary<System.Enum, StringMPCallbackObj>();

	public void BindString(System.Enum id, StringMPCallbackObj _cb){
		if (!stringMessageObj.ContainsKey (id)) {
			stringMessageObj.Add (id, _cb);
		} else {
			stringMessageObj [id] += _cb;
		}
	}

	public void UnbindString(System.Enum id, StringMPCallbackObj _cb){
		if (!stringMessageObj.ContainsKey (id)) {
			stringMessageObj.Add (id, _cb);
		} else {
			stringMessageObj [id] += _cb;
		}
	}

	public string ExecuteString (System.Enum id, params object[] objs){
		if (stringMessageObj.ContainsKey (id)) {
			return stringMessageObj [id] (objs);
		}
		return "";
	}


	#endregion

	#region 返回浮点型 参数 (float) 消耗低

	Dictionary<System.Enum, FloatMPCallbackFloat> flaotMessageFloat = new Dictionary<System.Enum, FloatMPCallbackFloat>();

	public void BindFloat(System.Enum id, FloatMPCallbackFloat _cb){
		if (!flaotMessageFloat.ContainsKey (id)) {
			flaotMessageFloat.Add (id, _cb);
		} else {
			flaotMessageFloat [id] += _cb;
		}
	}

	public void UnbindFloat(System.Enum id, FloatMPCallbackFloat _cb){
		if (!flaotMessageFloat.ContainsKey (id)) {
			flaotMessageFloat.Add (id, _cb);
		} else {
			flaotMessageFloat [id] += _cb;
		}
	}

	public float ExecuteFloat (System.Enum id, float f1){
		if (flaotMessageFloat.ContainsKey (id)) {
			return flaotMessageFloat [id] (f1);
		}
		return -1;
	}

	#endregion

	#region 返回浮点型 参数 (float, float) 消耗低

	Dictionary<System.Enum, FloatMPCallbackFloatFloat> floatMessageFloat = new Dictionary<System.Enum, FloatMPCallbackFloatFloat>();

	public void BindFloat(System.Enum id, FloatMPCallbackFloatFloat _cb){
		if (!floatMessageFloat.ContainsKey (id)) {
			floatMessageFloat.Add (id, _cb);
		} else {
			floatMessageFloat [id] += _cb;
		}
	}

	public void UnbindFloat(System.Enum id, FloatMPCallbackFloatFloat _cb){
		if (!floatMessageFloat.ContainsKey (id)) {
			floatMessageFloat.Add (id, _cb);
		} else {
			floatMessageFloat [id] += _cb;
		}
	}

	public float ExecuteFloat (System.Enum id, float f1, float f2){
		if (floatMessageFloat.ContainsKey (id)) {
			return floatMessageFloat [id] (f1, f2);
		}
		return -1;
	}

	#endregion
}

/// <summary>
///  有参回调
/// </summary>
class MessagerObj{
	public VoidMPCallbackObj callback;

	public MessagerObj(VoidMPCallbackObj _cb){
		callback = _cb;
	}

	public void BindCallback(VoidMPCallbackObj _cb){
		callback += _cb;
	}

	public void UnbindCallback(VoidMPCallbackObj _cb){
		callback -= _cb;
	}

	public void Execute(object[] objs){
		if (callback != null)
			callback (objs);
	}
}

/// <summary>
/// 无参回调
/// </summary>
class Message{
	public VoidMPCallback callback;

	public Message (VoidMPCallback _cb){
		callback = _cb;
	}

	public void BindCallback(VoidMPCallback _cb){
		callback += _cb;
	}

	public void UnbindCallback(VoidMPCallback _cb){
		callback -= _cb;
	}

	public void Execute(){
		if (callback != null)
			callback ();
	}
}