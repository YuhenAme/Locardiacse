// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrAtk2Die : FSMTransition {
    public TrAtk2Die(FSMstate nowState) : base(nowState){ }
    public override bool isValid()
    {
        // 应该是最高优先级的转换，当生命值为0时直接死亡。

        return false;
    }
}
