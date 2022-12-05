using System;
using Script.DB;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UIListener
{
    public class IncrementValue : MonoBehaviour
    {
        public CharacterStats characterStats;
        
        public void OnClick()
        {
            characterStats.health.Value += 1;
        }
    }
}