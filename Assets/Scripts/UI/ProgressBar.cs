using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Image fillBar;
    public TMP_Text progressText;

    [SerializeField] private int _totalValue = 100;
    private int _fillValue;

    public int TotalValue { get { return _totalValue; } }

    public void SetFillAmount(int val)
    {
        if (val == _fillValue)
        {
            return;
        }

        if (val > _totalValue)
        {
            val = _totalValue;
        }

        _fillValue = val;
        progressText.text = $"{_fillValue} / {_totalValue}";
        fillBar.fillAmount = (float) _fillValue / _totalValue;
    }

}
