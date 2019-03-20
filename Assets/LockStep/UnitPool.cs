using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WDLockstep
{
    /// <summary>
    /// 粗暴写的单位对象池
    /// </summary>
    public class UnitPool
    {
        /// <summary>
        /// 对象池
        /// </summary>
        private static Stack<Unit> stack = new Stack<Unit>();
        /// <summary>
        /// 简单处理
        /// </summary>
        /// <returns>对象</returns>
        public static Unit Spawn() {
            if (stack.Count > 0) {
                return stack.Pop();
            }
            Unit unit = new Unit();
            return unit;
        }
    }
    /// <summary>
    /// 单位
    /// </summary>
    [Serializable]
    public class Unit {
        #region 逻辑数据
        /// <summary>
        /// 唯一id
        /// </summary>
        public long Index = 0;
        /// <summary>
        /// 坐标
        /// </summary>
        public FixVector3 LPosition;
        /// <summary>
        /// 旋转
        /// </summary>
        internal FixVector3 LRotation;
        #endregion
        #region 渲染数据
        private GameObject mesh;
        private Transform transform;
        #endregion
        #region 渲染相关方法
        public Vector3 RPosition {
            get {
                if (transform == null)
                    return Vector3.zero;
                return transform.position;
            }
        }
        public void SetRenderMesh(GameObject obj) {
            mesh = obj;
            transform = mesh.transform;
            transform.position = LPosition.ToUnityVector3();
            transform.rotation = Quaternion.Euler(LRotation.ToUnityVector3());
        }
        #endregion
    }
}