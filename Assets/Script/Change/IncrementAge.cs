using Stats.Code;
using UnityEngine;

namespace Script
{
    public class IncrementAge : MonoBehaviour
    {
        public TestStore store;

        public void OnClick()
        {
            store.age.Value += 1;
        }
    }
}