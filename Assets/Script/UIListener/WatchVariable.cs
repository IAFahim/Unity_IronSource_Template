﻿using System.Globalization;
using Stats.Code;
using TMPro;
using UniRx;
using UnityEngine;

namespace Script.UIListener
{
    public class WatchVariable : MonoBehaviour
    {
        public CharacterStats characterStats;
        TextMeshProUGUI _textMeshPro;

        private void Start()
        {
            _textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
            Debug.Log(_textMeshPro.text);
            characterStats.health.Subscribe(health => _textMeshPro.text = health.ToString(CultureInfo.InvariantCulture));
        }

        private void OnDisable()
        {
            characterStats.health.Dispose();
        }
    }
}