using UnityEngine;
using Zenject;

namespace IceCream.GameLogic
{
    public abstract class Present : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _chanceCurve;
        [SerializeField] private AudioClip _audioClip;
        private AudioSource _audio;

        public AnimationCurve ChanceCurve => _chanceCurve;

        [Inject]
        public void Init(AudioSource audio) => _audio = audio;

        private void OnEnable() => transform.rotation = Quaternion.identity;

        public void Apply()
        {
            gameObject.SetActive(false);
            _audio.PlayOneShot(_audioClip);
            PlayApplyFeedBack();
        }

        protected abstract void PlayApplyFeedBack();
    }
}
