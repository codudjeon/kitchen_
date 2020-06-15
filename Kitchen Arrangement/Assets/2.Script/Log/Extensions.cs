using System;
using UnityEngine;

namespace FreemixCommon
{
    public static class Extensions
    {
        public static string Format(this Quaternion q)
        {
            return String.Join(";", new string[] { q.x.ToString(), q.y.ToString(), q.z.ToString(), q.w.ToString() });
        }

        public static string Format(this Vector3 v)
        {
            return String.Join(";", new string[] { v.x.ToString(), v.y.ToString(), v.z.ToString() });
        }
    }
}
