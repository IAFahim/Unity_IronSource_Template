﻿using Script.DB;
using UnityEngine;

namespace Script.UIListener
{
    public class DecrementValue : MonoBehaviour
    {
        public CharacterStats characterStats;
        
        public void OnClick()
        {
            characterStats.health.Value += 1;
        }
    }
}