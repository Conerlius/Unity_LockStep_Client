using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WDLockstep
{
    [System.Serializable]
    public struct FixVector3
    {
        private static readonly long ScaleRate = 1000;
        public long x, y, z;

        public FixVector3(long v1, long v2, long v3)
        {
            x = v1;
            y = v2;
            z = v3;
        }

        public static FixVector3 one {
            get {
                return new FixVector3(1, 1, 1);
            }
        }

        public Vector3 ToUnityVector3()
        {
            return new Vector3(x / ScaleRate, y / ScaleRate, z / ScaleRate);
        }
    }
}