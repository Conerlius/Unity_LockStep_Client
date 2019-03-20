using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WDLockstep
{
    public static class RenderMgr
    {
        public static void RenderPosition(Unit unit)
        {
            unit.SetRenderMesh(GameObject.CreatePrimitive(PrimitiveType.Cube));
        }
    }
}