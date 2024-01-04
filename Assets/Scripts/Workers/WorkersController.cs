using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Workers
{
    public class WorkersController : MonoBehaviour
    {
        [SerializeField] private Vector2 stateShiftRange = new Vector2(2f, 10f);
        
        private List<WorkerController> _workers;
        
        private float _elapsedTime;
        private float _randomDelay;
        private void Awake()
        {
            _workers = gameObject.GetComponentsInChildren<WorkerController>().ToList();
            _randomDelay = Random.Range(stateShiftRange.x, stateShiftRange.y);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _randomDelay)
            {
                _randomDelay = Random.Range(stateShiftRange.x, stateShiftRange.y);
                _elapsedTime = 0f;
                ChangeWorkerState();
            }
        }

        private void ChangeWorkerState()
        {
            var randomIndex = Random.Range(0, _workers.Count);
            var randomWorker = _workers[randomIndex];
            randomWorker.ChangeState(WorkerStates.WorkerStates.Sleeping);
        }
    }
}