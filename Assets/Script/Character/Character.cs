using System;
using Script.DB;
using UnityEngine;

namespace Script.Character
{
    public class Character : MonoBehaviour
    { 
        public enum Type
        {
            Player,
            Enemy
        }
        public Type cType=Type.Enemy;
        public CharacterStats stats;
        public FloatReference hp;

        private void Update()
        {
            Debug.Log(hp.Value);
        }
    }
}