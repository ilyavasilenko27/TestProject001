using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class ScaleRender : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Slider slider2;
    [SerializeField]
    private UniversalRenderPipelineAsset renderPipeline;

    void Start()
    {
        slider.value = QualitySettings.GetQualityLevel();
        renderPipeline = (UniversalRenderPipelineAsset)QualitySettings.GetRenderPipelineAssetAt((int)slider.value);
        slider2.value = renderPipeline.renderScale;
    }

    public void Change()
    {
        QualitySettings.SetQualityLevel((int)slider.value);
        renderPipeline = (UniversalRenderPipelineAsset)QualitySettings.GetRenderPipelineAssetAt((int)slider.value);
        renderPipeline.renderScale = slider2.value;
    }
}
