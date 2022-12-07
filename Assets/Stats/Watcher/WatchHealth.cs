using System.Globalization;
using Stats.Code;
using TMPro;
using UniRx;
using UnityEngine;

namespace Stats.Watcher
{
    public class WatchHealth : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;
        public TestStore testStore;

        private void Start()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            testStore.age.Subscribe(age => _textMeshProUGUI.text = age.ToString(CultureInfo.InvariantCulture));
        }
    }
}