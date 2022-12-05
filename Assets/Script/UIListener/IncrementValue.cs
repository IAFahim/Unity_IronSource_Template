﻿using Script.DB;
using Stats.Code;
using UnityEngine;

namespace Script.UIListener
{
    public class IncrementValue : MonoBehaviour
    {
        public CharacterStats characterStats;
        
        public void OnClick()
        {
            characterStats.rHaelth.Value += 1;
        }
    }
}