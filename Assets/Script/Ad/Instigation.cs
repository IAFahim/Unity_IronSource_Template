using System;
using UnityEditor;
using UnityEngine;

namespace Script.Ad
{
    public class Instigation : MonoBehaviour
    {
        public string appkey;
        private void Awake()
        {
            IronSource.Agent.init(appkey);
        }

        private void Start()
        {
            LoadBanner();
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            IronSource.Agent.onApplicationPause(pauseStatus);
        }

        public void LoadBanner()
        {
            IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
        }
    }
}
