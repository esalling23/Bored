using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Creature : MonoBehaviour
{
    public string givenName;
    private bool _alive = true;
    [SerializeField] private CreatureStats _stats;
    public EntertainmentStat[] entertainmentStats;

    [Header("Creature loses health if any stat is below threshold")]
    public int healthReduceThreshold = 50;

    private float _tickLength = 5.2f;
    private float _timeSinceLastTick = 0f;

    [Space]
    [SerializeField] private CreatureHUD _hud;

    public int Health {
        get { return _stats.health.value; }
    }
    public int Hunger {
        get { return _stats.hunger.value; }
    }
    public int Thirst {
        get { return _stats.thirst.value; }
    }
    public int Boredom {
        get { return _stats.boredom.value; }
    }

    private void Update()
    {
        if (!_alive) return;

        if (_timeSinceLastTick < _tickLength)
        {
            _timeSinceLastTick += Time.deltaTime;
            return;
        }

        _timeSinceLastTick = 0;
        TickStats();

        if (!_stats.Alive)
        {
            Die();
        }
    }

    void Start()
    {
        ResetStats();

        _hud.Initialize(this);
    }

    /// <summary>
    /// Select this creature
    /// </summary>
    public void Select()
    {
        CreatureManager.Instance.SetActiveCreature(this);
    }

    /// <summary>
    /// Updates stats over time
    /// </summary>
    public void TickStats()
    {
        _increaseStat(ref _stats.hunger.value);
        _increaseStat(ref _stats.thirst.value);
        _increaseStat(ref _stats.boredom.value);

        bool isHealthHurt = Hunger > healthReduceThreshold
                            || _stats.thirst.value > healthReduceThreshold
                            || _stats.boredom.value > healthReduceThreshold;
        if (isHealthHurt)
        {
            _reduceStat(ref _stats.health.value, CreatureManager.defaultStatReduction);
        }

        _hud.Initialize(this);
    }

    /// <summary>
    /// Resets stats to "full"
    /// </summary>
    public void ResetStats()
    {
        _stats.health.value = 100;
        _stats.hunger.value = 0;
        _stats.thirst.value = 0;
        _stats.boredom.value = 0;

        _alive = true;

        _hud.Initialize(this);
    }


    public void Eat(int amount)
    {
        _reduceStat(ref _stats.hunger.value, amount);
        _hud.UpdateStat(STAT.HUNGER);
    }
    public void Drink(int amount)
    {
        _reduceStat(ref _stats.thirst.value, amount);
        _hud.UpdateStat(STAT.THIRST);
    }
    public void Play(int amount)
    {
        _reduceStat(ref _stats.boredom.value, amount);
        _hud.UpdateStat(STAT.BOREDOM);
    }

    public void Die()
    {
        _alive = false;
    }

    /// <summary>
    /// Reduces stat values
    /// </summary>
    /// <param name="_val"></param>
    /// <param name="_amount"></param>
    private void _reduceStat(ref int _val, int _amount)
    {
        _val -= _amount;

        if (_val < 0)
        {
            _val = 0;
        }
    }

    /// <summary>
    /// Increases stat values
    /// </summary>
    /// <param name="_val"></param>
    private void _increaseStat(ref int _val)
    {
        _val += CreatureManager.statTickAmount;
    }
}
