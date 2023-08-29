using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreatureHUD : MonoBehaviour
{
    [Header("Progress bars")]
    [SerializeField] private ProgressBar _hungerBar;
    [SerializeField] private ProgressBar _thirstBar;
    [SerializeField] private ProgressBar _boredomBar;

    [Space]
    [Header("Details")]
    [SerializeField] private TMP_Text _nameText;

    private Creature _creature;

    public void Initialize(Creature c)
    {
        _creature = c;
        _nameText.text = c.givenName;
        _updateStatBars();
    }

    public void UpdateStat(STAT stat)
    {
        _updateStatBar(stat);
    }

    /// <summary>
    /// Updates each stat bar
    /// </summary>
    private void _updateStatBars()
    {
        _updateStatBar(STAT.HUNGER);
        _updateStatBar(STAT.THIRST);
        _updateStatBar(STAT.BOREDOM);
    }

    private void _updateStatBar(STAT stat)
    {
        switch (stat)
        {
            default:
            case STAT.HUNGER:
                _fillProgressBar(_hungerBar, _creature.Hunger);
                break;
            case STAT.THIRST:
                _fillProgressBar(_thirstBar, _creature.Thirst);
                break;
            case STAT.BOREDOM:
                _fillProgressBar(_boredomBar, _creature.Boredom);
                break;
        }
    }

    private void _fillProgressBar(ProgressBar _bar, int _stat)
    {
        _bar.SetFillAmount(_bar.TotalValue - _stat);
    }
}