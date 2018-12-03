// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrAwa2Atk : FSMTransition {
    public TrAwa2Atk(FSMstate nowState) : base(nowState){ }


    public override bool isValid()
    {
        // 当进入攻击范围内时，返回true

        return false;
    }
}
