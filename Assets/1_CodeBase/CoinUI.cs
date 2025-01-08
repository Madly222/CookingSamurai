using System.Collections;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private GameObject coinBox;
    [SerializeField] private float duration = 2f;

    private int _newCoinValue;
    private float _elapsedTime;
    private int _displayValue;

    private int _tempSaveValue;
    public void CoinIncrease(int itemPrice,int finalScore)
    {
        _tempSaveValue += finalScore;
        StartCoroutine(IncreaseValueOverTime(itemPrice, _tempSaveValue));
    }

    private IEnumerator IncreaseValueOverTime(int startValue, int endValue)
    {
        coinBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        while (_elapsedTime < duration)
        {
            _elapsedTime += Time.deltaTime;
            _displayValue = (int)Mathf.Lerp(startValue, endValue, _elapsedTime / duration);
            uiText.text = _displayValue.ToString();
            yield return null;
        }
        
        uiText.text = endValue.ToString();
        
        yield return new WaitForSeconds(2f);
        _elapsedTime = 0;
        coinBox.SetActive(false);
    }
}
