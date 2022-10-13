using UnityEngine;
using UnityEngine.UI;
namespace Geekbrains
{
    public sealed class RadarObj : MonoBehaviour
    {
        [SerializeField] private Image _ico;
        private void OnValidate()
        {
            if(!_ico)
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
        }
        private void OnDisable()
        {
            Radar.RemoveRadarObject?.Invoke(gameObject);
        }
        private void OnEnable()
        {
            Radar.RegisterRadarObject?.Invoke(gameObject, _ico);
        }
    }
}
