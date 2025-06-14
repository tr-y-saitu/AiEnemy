using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VHSRenderFeature : ScriptableRendererFeature
{
    class VHSRenderPass : ScriptableRenderPass
    {
        Material material;
        VHSVolume settings;

        public VHSRenderPass(Material mat)
        {
            material = mat;
            renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (material == null) return;

            var stack = VolumeManager.instance.stack;
            settings = stack.GetComponent<VHSVolume>();
            if (settings == null || !settings.IsActive()) return;

            CommandBuffer cmd = CommandBufferPool.Get("VHS Effect");

            var source = renderingData.cameraData.renderer.cameraColorTargetHandle;
            var dest = renderingData.cameraData.renderer.cameraColorTargetHandle;

            material.SetFloat("_Intensity", settings.intensity.value);

            Blit(cmd, source, dest, material);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    public Shader shader;
    VHSRenderPass pass;

    public override void Create()
    {
        if (shader == null)
            shader = Shader.Find("Hidden/Custom/VHS");

        if (shader != null)
        {
            var mat = new Material(shader);
            pass = new VHSRenderPass(mat);
        }
        else
        {
            Debug.LogError("VHSRenderFeature: Shader not found!");
        }
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (pass != null)
        {
            renderer.EnqueuePass(pass);
        }
    }
}
