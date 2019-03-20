using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WDLockstep
{
    public static class LockStep
    {

        public static void Parse(List<string> frames) {
            int length = frames.Count;
            for (int i = 0; i < length; i++) {
                ParseFrameData(frames[i]);
            }
        }
        private static void ParseFrameData(string frameData) {
            if (frameData.StartsWith("Begin=>"))
            {
                // 刚启动游戏
                OutputMsgMgr.Instance.Begin(100);
            }
            else if (frameData.StartsWith("Add=>")) {
                // 添加玩家
                string tmp1 = frameData.Substring(5);
                string[] tmp2 = tmp1.Split(';');
                var unit = CreateUnit(System.Convert.ToInt64(tmp2[0]), new FixVector3(System.Convert.ToInt64(tmp2[1]), 0, System.Convert.ToInt64(tmp2[2])), FixVector3.one);
                MApplication.AddUnit(unit);
            }
        }
        /// <summary>
        /// 创建单位
        /// </summary>
        /// <param name="posi">坐标</param>
        /// <param name="rote">朝向</param>
        public static Unit CreateUnit(long uid, FixVector3 posi, FixVector3 rote)
        {
            Unit unit = UnitPool.Spawn();
            unit.LPosition = posi;
            unit.LRotation = rote;
            unit.Index = uid;
            RenderMgr.RenderPosition(unit);
            return unit;
        }
    }
}