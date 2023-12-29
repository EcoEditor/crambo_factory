using CremboFactory;
using UnityEngine;
using Workers;
using Workers.WorkerStates;

namespace DefaultNamespace
{
    public class CremboWorkStation : MonoBehaviour
    {
        [SerializeField] private float overlapRadius = 1f;
        [SerializeField] private LayerMask cremboMask;
        [SerializeField] private float snapInterval = 0.5f;
        [SerializeField] private float wrapWithDelay = 0.4f;
        [SerializeField] private string wrapAnimationTriggerName = "Wrap";
        
        private WorkerController _worker;
        private Transform _transform;
        private Crembo _selectedCrembo;
        private float _elapsedTime;

        private void Awake()
        {
            _transform = transform;
            _worker = GetComponent<WorkerController>();
        }

        private void Update()
        {
            if (_selectedCrembo) return;
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= snapInterval)
            {
                _elapsedTime = 0;
                SnapToWorkStation();
            }
        }

        private void SnapToWorkStation()
        {
            if (_worker.MyState is SleepingState) return;
            
            var hitCollider = Physics2D.OverlapCircle(_transform.position, overlapRadius, cremboMask);

            if (hitCollider)
            {
                _selectedCrembo = hitCollider.GetComponent<Crembo>();
                if (_selectedCrembo == null) return;
                if (_selectedCrembo.IsWrapped)
                {
                    _selectedCrembo = null;
                    return;
                }

                var direction = _selectedCrembo.transform.position.y - _transform.position.y;

                if (direction < 0)
                {
                    _selectedCrembo = null;
                    return;
                }
                
                _selectedCrembo.SnapToStation();
                _selectedCrembo.transform.position = _transform.position;
                MessagingSystem.SetWorkerAnimationTrigger?.Invoke(_worker.WorkerIndex, wrapAnimationTriggerName);
                Invoke(nameof(WrapCrembo), wrapWithDelay);
            }
        }

        private void WrapCrembo()
        {
            _selectedCrembo.SwitchToWrapped();
            _selectedCrembo = null;
        }

        // public void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.blue;
        //     Gizmos.DrawSphere(transform.position, overlapRadius);
        // }
    }
}