using System;
using UnityEngine;

public enum ENTERTAINMENT
{
    EXERCISE,
    READ,
    VIDEO_GAME
}

[SerializeField]
public struct EntertainmentStat
{
    public ENTERTAINMENT activity;
    public int amount; // amount by which to reduce boredom
}

public enum STAT
{
    HAPPINESS,
    HUNGER,
    THIRST,
    BOREDOM
}

[System.Serializable]
public struct CreatureStat
{
    public STAT type;
    public int value;
}

[System.Serializable]
public struct CreatureStats
{
    public CreatureStat health;
    public CreatureStat hunger;
    public CreatureStat thirst;
    public CreatureStat boredom;

    public bool Alive { get { return health.value > 0; }}
}
