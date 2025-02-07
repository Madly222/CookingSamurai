using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private string blendShapeName = "Key 1";
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timerDuration = 30f;

    [SerializeField] private Renderer textureObject;
    [SerializeField] private Texture textureAt100;
    [SerializeField] private Texture textureAt80;
    [SerializeField] private Texture textureAt30;

    [SerializeField] private Renderer colorObject;
    [SerializeField] private Color colorAt100 = Color.green;
    [SerializeField] private Color colorAt80 = Color.yellow;
    [SerializeField] private Color colorAt30 = Color.red;

    private int _blendShapeIndex;
    private float _currentTimer;
    private bool _hasChangedAt80;
    private bool _hasChangedAt30;
    private float _percentage;
    private float _blendShapeValue;

    private void Awake()
    {
        _blendShapeIndex = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShapeName);
        skinnedMeshRenderer.SetBlendShapeWeight(_blendShapeIndex, 100f);
    }

    private void OnEnable()
    {
        colorObject.material.color = colorAt100;
        textureObject.material.mainTexture = textureAt100;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        _currentTimer = timerDuration;
        _hasChangedAt80 = false;
        _hasChangedAt30 = false;
            
        while (_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;

            _percentage = (_currentTimer / timerDuration) * 100f;
                
            if (!_hasChangedAt80 && _percentage <= 80f)
            {
                _hasChangedAt80 = true;
                ChangeTexture(textureAt80);
                ChangeColor(colorAt80);
            }
                
            if (!_hasChangedAt30 && _percentage <= 30f)
            {
                _hasChangedAt30 = true;
                ChangeTexture(textureAt30);
                ChangeColor(colorAt30);
            }

            UpdateTimerText(Mathf.CeilToInt(_currentTimer));

            _blendShapeValue = Mathf.Clamp(_percentage, 0f, 100f);
            skinnedMeshRenderer.SetBlendShapeWeight(_blendShapeIndex, _blendShapeValue);

            yield return null;
        }
    }

    private void ChangeTexture(Texture newTexture)
    {
        textureObject.material.mainTexture = newTexture;
    }

    private void ChangeColor(Color newColor)
    {
        colorObject.material.color = newColor;
    }

    private void UpdateTimerText(int seconds)
    {
        timerText.text = seconds.ToString();
    }
}
