using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IceCream.GameLogic
{
    public sealed class NightView : MonoBehaviour
    {
        [SerializeField] private SunRays _sunRays;
        [SerializeField] private CameraColor _cameraColor;
        [SerializeField] private IceBagFactory _factory;
        [SerializeField] private ParticleSystem _snowParticle;
        [SerializeField] private ParticleSystem _starParticle;
        [SerializeField] private List<RawImage> _rawImages = new();
        [SerializeField] private Image _moon;

        private void OnEnable() => _sunRays.OnChanged += SwitchDayTime;

        private void OnDestroy() => _sunRays.OnChanged -= SwitchDayTime;

        private void SwitchDayTime(bool isNight)
        {
            SetActiveSnow(!isNight);
            _starParticle.gameObject.SetActive(isNight);
            _moon.gameObject.SetActive(isNight);

            if (isNight)
            {
                Dark();
            }
            else
            {
                Bright();
            }
        }

        private void Dark() => _cameraColor.SetNew(Color.black);

        private void Bright()
        {
            _cameraColor.Clear();
            _factory.StartSpawn();
        }

        private void SetActiveSnow(bool isActive)
        {
            _factory.gameObject.SetActive(isActive);
            _snowParticle.gameObject.SetActive(isActive);
            _rawImages.ForEach(r => r.gameObject.SetActive(isActive));
        }
    }
}