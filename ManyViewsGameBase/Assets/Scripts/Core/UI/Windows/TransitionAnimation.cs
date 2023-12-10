using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Core.UI.Windows
{
    public class TransitionAnimation : MonoBehaviour
    {
        private const float DefaultVignetteValue = 0f;
        
        private const float MaxVignetteValue = 1f;
        
        [SerializeField] private VolumeProfile volumeProfile;
        
        private void Start()
        {
            ChangeVignetteValue(DefaultVignetteValue);
        }
        private void OnDestroy()
        {
            ChangeVignetteValue(DefaultVignetteValue);
        }
        
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

        
        private void ChangeVignetteValue(float value)
        {
            if (volumeProfile.TryGet(out Vignette bloom))
            {
                bloom.intensity.value = value;
            }
        }
       
    }
}