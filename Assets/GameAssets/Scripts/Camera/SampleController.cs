using UnityEngine;
using UnityEngine.Rendering.Universal.Glitch;

namespace Samples
{
    sealed class SampleController : MonoBehaviour
    {
        [SerializeField] DigitalGlitchFeature _digitalGlitchFeature = default;
        [SerializeField] AnalogGlitchFeature _analogGlitchFeature = default;

        [Header("Digital")]
        [SerializeField, Range(0f, 1f)] float _intensity = default;

        [Header("Analog")]
        [SerializeField, Range(0f, 1f)] float _scanLineJitter = default;
        [SerializeField, Range(0f, 1f)] float _verticalJump = default;
        [SerializeField, Range(0f, 1f)] float _horizontalShake = default;
        [SerializeField, Range(0f, 1f)] float _colorDrift = default;

        public float Intensity { get => _intensity; set => _intensity = value; }
        public float ScanLineJitter { get => _scanLineJitter; set => _scanLineJitter = value; }
        public float VerticalJump { get => _verticalJump; set => _verticalJump = value; }
        public float HorizontalShake { get => _horizontalShake; set => _horizontalShake = value; }
        public float ColorDrift { get => _colorDrift; set => _colorDrift = value; }

        void Update()
        {
            _digitalGlitchFeature.Intensity = _intensity;

            _analogGlitchFeature.ScanLineJitter = ScanLineJitter;
            _analogGlitchFeature.VerticalJump = VerticalJump;
            _analogGlitchFeature.HorizontalShake = HorizontalShake;
            _analogGlitchFeature.ColorDrift = ColorDrift;
        }
    }
}
