using System;
using UnityEngine;

namespace Susie
{
    public class SSDebug
    {
        private static bool isDebug = true;
        public static void SetDebug(bool val)
        {
            isDebug = val;
        }
        public static void Log(string msg)
        {
			if(isDebug)
            	Debug.Log(msg);
        }

        public static void printBytes(byte[] bytes)
        {

            string s = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                s += bytes[i] + ",";
            }
            SSDebug.Log(s);
        }
    }
}