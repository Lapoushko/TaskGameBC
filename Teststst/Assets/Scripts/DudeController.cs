using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridPlacement))]
public class DudeController : MonoBehaviour
{
    [SerializeField] private int countDudes = 10;

    public int Count => countDudes;

    private MouseDrawer drawer = null;
    private DudeSpawner spawnerDudes = null;
    private GameController gameController = null;

    private void Awake()
    {
        drawer = FindObjectOfType<MouseDrawer>();
        spawnerDudes = FindObjectOfType<DudeSpawner>();
        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        drawer.OnPointsGenerated += Recalculates;
        spawnerDudes.OnDudeSpawned += OnDudeSpawned;
    }

    private void OnDisable()
    {
        drawer.OnPointsGenerated -= Recalculates;
        spawnerDudes.OnDudeSpawned -= OnDudeSpawned;
    }

    private void Start()
    {
        Spawn();
    }

    private void OnDudeSpawned(DudeSpawner.OnDudeSpawnedEventArgs args)
    {
        countDudes += 1;

        args.Dude.OnSpikeCollision += OnDudeSpikeCollision;
    }

    private void Spawn()
    {
        GridPlacement gridPlacemants = GetComponent<GridPlacement>();

        Vector3[] positions = gridPlacemants.Calculate();

        for (int i = 0; i < positions.Length; i++)
        {
            spawnerDudes.SpawnAt(positions[i]);
        }
        
    }
    private void OnDudeSpikeCollision(DudeObject.OnSpikeCollisionEventArgs args)
    {
        args.Sender.OnSpikeCollision -= OnDudeSpikeCollision;

        countDudes -= 1;        
        if (countDudes == 0)
        {
            FindObjectOfType<GameController>()?.LoseGame();
        }
    }

    private void Recalculates()
    {
        spawnerDudes.RecalculatePosition(countDudes);
    }
}
