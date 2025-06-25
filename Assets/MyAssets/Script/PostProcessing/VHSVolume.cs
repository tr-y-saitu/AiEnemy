using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable, VolumeComponentMenu("Custom/VHS")]
public class VHSVolume : VolumeComponent, IPostProcessComponent
{
    public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 1f);

    public bool IsActive() => intensity.value > 0f;
    public bool IsTileCompatible() => false;
}
