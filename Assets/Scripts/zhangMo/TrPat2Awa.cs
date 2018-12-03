// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrPat2Awa : FSMTransition {
    public TrPat2Awa(FSMstate nowState) : base(nowState){ }
    public override bool isValid()
    {
        // 当玩家进入视线范围时返回true，进入追逐
        return false;
    }
}
