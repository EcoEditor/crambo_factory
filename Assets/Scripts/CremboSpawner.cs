using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CremboSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private int maxCremboAmount = 10;
        [SerializeField] private Crembo cremboRef;
        [SerializeField] private Transform spawnPosition;

        private HashSet<Crembo> _spawnedCrembo = new HashSet<Crembo>();
        private WaitForSeconds _spawnDelay;
        private void Awake()
        {
            _spawnDelay = new WaitForSeconds(spawnInterval);
            StartSpawn();
        }

        private void StartSpawn()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (_spawnedCrembo.Count < maxCremboAmount)
            {
                var crembo = Instantiate(cremboRef, spawnPosition);
                _spawnedCrembo.Add(crembo);
                yield return _spawnDelay;
            }
        }
    }
}