using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WDLockstep
{
    public delegate void LockStepEvent(string args);
    /// <summary>
    /// 写入提示
    /// </summary>
    public class TipsMgr : MonoBehaviour
    {
        
    }
    /// <summary>
    /// 全局事件管理器
    /// </summary>
    public class GlobalEventMgr {
        private static Dictionary<EventName, LockStepEvent> events = new Dictionary<EventName, LockStepEvent>();
        public static void Regist(EventName aname, LockStepEvent del) {

        }
        public static void Remove(EventName aname, LockStepEvent del)
        {

        }
    }
    /// <summary>
    /// 事件名称
    /// </summary>
    public enum EventName {
        
    }
}