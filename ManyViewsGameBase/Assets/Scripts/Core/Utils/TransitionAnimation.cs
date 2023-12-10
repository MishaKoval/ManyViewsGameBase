using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Core.Utils
{
    public class TransitionAnimation : MonoBehaviour
    {
        [SerializeField] private VolumeProfile volumeProfile;
        private const float DefaultVignetteValue = 0f;
        private const float MaxVignetteValue = 1f;
        
        [ContextMenu("Test")]
        public async Task<bool> WaitVignetteChange()
        {
            ChangeVignetteValue(DefaultVignetteValue);
            if (volumeProfile.TryGet(out Vignette vignette))
            {  
                while (vignette.intensity.value < MaxVignetteValue)
                {
                    vignette.intensity.value += 0.01f;
                    await Task.Delay(10);
                }
            }
            ChangeVignetteValue(DefaultVignetteValue);
            return true;
        }
        
        private void Start()
        {
            ChangeVignetteValue(DefaultVignetteValue);
        }
        private void OnDestroy()
        {
            ChangeVignetteValue(DefaultVignetteValue);
        }
        
        private void ChangeVignetteValue(float value)
        {
            if (volumeProfile.TryGet(out Vignette bloom))
            {
                bloom.intensity.value = value;
            }
        }
    }
}