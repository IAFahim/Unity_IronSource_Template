using System;
using UnityEngine;

namespace Script.DB
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "CharacterStats", order = 0)]
    public class CharacterStats : ScriptableObject
    {
        public float health;
        public float xp;
        public int level;

        public float Xp
        {
            get => xp;
            set
            {
                xp = SetLevel(value);
            }
        }

        private float SetLevel(float value)
        {
            Debug.Log(value);
            level = (int)Mathf.Sqrt(value);
            return value;
        }
    }
}