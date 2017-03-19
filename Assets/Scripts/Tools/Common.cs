using UnityEngine;
using System.Collections;

#region MessageProvider 回调
public delegate void VoidMPCallbackObj(params object[] objs);
public delegate void VoidMPCallback();
public delegate int IntMPCallbackObj(params object[] objs);
public delegate float FloatMPCallbackObj(params object[] objs);
public delegate bool BoolMPCallbackObj(params object[] objs);
public delegate string StringMPCallbackObj(params object[] objs);
public delegate float FloatMPCallbackFloat(float f1);
public delegate float FloatMPCallbackFloatFloat(float f1, float f2);
#endregion

public delegate bool BoolDelegateActor(Actor _actor);
public delegate void VoidDelegate();
public delegate void VoidDelegateFloat(float f);
public delegate void VoidDelegateValueIntInt(ValueInt i1, int i2);
public delegate void VoidDelegateValueFloatFloat(ValueFloat i1, float i2);
public delegate void VoidDelegateBsaBsa(BattleStageActor bsa1, BattleStageActor bsa2);

public class Common  {


}

public class GamePath{
	public const string ModelPath = "Prefabs/";
	public const string EffectPath = "Effect/";
	public const string BattleUI = "Prefabs/UI/Battle/";
}
