using System;
using System.Collections.Generic;
using UnityEngine;

namespace WDLockstep
{
    /// <summary>
    /// 项目的第一个启动的文件
    /// 主要是为了创建用于做同步的单位,项目并不采用ECS+Lockstep,只是为公司的项目写的一个示范用的demo
    /// </summary>
    public class MApplication : UnityEngine.MonoBehaviour
    {
        #region 编辑器允许编辑的属性
        #endregion

        [Header("以下属性不要编辑")]
        #region 编辑器开放的属性
        /// <summary>
        /// 当前操作单位
        /// </summary>
        [Header("当前操作单位")]
        public Unit CurUnit;
        [Header("玩家id")]
        public int CurIndex = 1;
        #endregion
        private List<string> frames = new List<string>();
        /// <summary>
        /// 单例，这里就不写成接口的singleton了
        /// </summary>
        static MApplication _instance = null;
        /// <summary>
        /// 战斗是否开启
        /// </summary>
        private bool isJoyGame = false;
        #region default method
        private void Awake()
        {
            _instance = this;
        }

        public static void AddUnit(Unit unit)
        {
            if (unit.Index == _instance.CurIndex) {
                _instance.CurUnit = unit;
            }
        }

        private void Update()
        {
            frames = WDClient.GetFrames();
            if (frames.Count > 0) {
                LockStep.Parse(frames);
            }
        }
        private void OnGUI()
        {
            if (isJoyGame == false) {
                if (GUI.Button(new Rect(0, 0, 100, 100), "加入游戏"))
                {
                    WDClient.Instance.Send(string.Format("Add=>{0};{1};{2}", CurIndex, 0, 0));
                    isJoyGame = true;
                }
            }
        }
        #endregion

        #region public method
        #endregion
    }
}