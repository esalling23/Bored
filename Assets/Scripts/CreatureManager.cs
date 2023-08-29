using System.Linq;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{

    [SerializeField] private Creature _activeCreature;

    public static int defaultStatReduction = 10;
    public static int statTickAmount = 5;

    [SerializeField] private Creature _creaturePrefab;

    // Temporary "history"
    //[SerializeField] private Creature[] _creatureHistory;

    private static CreatureManager _instance;
    public static CreatureManager Instance
    {
        get { return _instance; }
    }

    public Creature ActiveCreature {
        get { return _activeCreature; }
    }

    private void Awake()
    {
        // Singleton management
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        //foreach (Creature c in _creatureHistory)
        //{
        //    Creature existingCreature = Instantiate(_creaturePrefab);
        //    existingCreature.stats = c.stats;
        //    existingCreature.givenName = c.givenName;
        //    existingCreature.entertainmentStats = c.entertainmentStats;
        //}
    }

    public void SetActiveCreature(Creature creature)
    {
        _activeCreature = creature;
    }

    /// <summary>
    /// Spawns a given # of creatures
    /// </summary>
    /// <param name="_count"></param>
    public void SpawnCreatures(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_creaturePrefab);
        }
    }

    /// <summary>
    /// Feed the selected creature
    /// </summary>
    public void Feed()
    {
        ActiveCreature.Eat(defaultStatReduction);
    }

    /// <summary>
    /// Give the selected creature a drink
    /// </summary>
    public void Drink()
    {
        ActiveCreature.Drink(defaultStatReduction);
    }

    /// <summary>
    /// Entertain the selected creature
    /// </summary>
    /// <param name="_activity"></param>
    public void Entertain(ENTERTAINMENT _activity)
    {
        EntertainmentStat? activityStat = ActiveCreature.entertainmentStats?.FirstOrDefault(
            (EntertainmentStat stat) => stat.activity == _activity
        );
        int amount = activityStat.HasValue ? activityStat.Value.amount : defaultStatReduction;
        ActiveCreature.Play(amount);
    }
}
