using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace WDLockstep
{

    public class OutputMsgMgr
    {
        private static OutputMsgMgr _instance = null;
        public static OutputMsgMgr Instance {
            get {
                if (_instance == null) {
                    _instance = new OutputMsgMgr();
                }
                return _instance;
            }
        }

        private static int a = 0;
        public void Begin(int v)
        {
            TimerCallback timerDelegate = new TimerCallback(SendInvoke);
            Timer timer = new Timer(timerDelegate, a, v, v);
        }
        private void SendInvoke(object obj) {
            WDClient.Instance.Send(string.Format(""));
        }
        public void SendMove() { 
        }
        public void SendStop() {
        }
    }
}