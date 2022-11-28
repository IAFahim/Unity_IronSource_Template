using System;
using Script.DB;
using UnityEngine;

namespace Script.Character.Health
{
    [RequireComponent(typeof(Character))]
    public class Health : MonoBehaviour
    {
        private CharacterStats _stats;

        private void Start()
        {
            _stats = GetComponent<Character>().stats;
        }

        public void setHealth(float value)
        {
            _stats.health = value;
        }
    }
}