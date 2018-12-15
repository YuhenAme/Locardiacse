using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 反正哪个状态都会死，不如any to die 好了。
public class TrAny2Die : FSMTransition {

	public TrAny2Die(FSMstate nowState):base(nowState){ }

}
