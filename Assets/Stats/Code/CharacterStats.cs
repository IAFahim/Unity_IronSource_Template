using UniRx;
using UnityEngine;

namespace Stats.Code
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "CharacterStats", order = 0)]
    public class CharacterStats : ScriptableObject
    {
        public Customer customer;
        public float Health = 100;
        [HideInInspector] public ReactiveProperty<float> H;

        private void OnEnable()
        {

            customer = new Customer
            {
                Email = "10"
            };
            H = new FloatReactiveProperty(Health);
            H.Subscribe(h => { Health = H.Value; });
        }
    }
}