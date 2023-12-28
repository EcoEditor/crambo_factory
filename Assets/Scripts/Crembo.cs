using UnityEngine;

namespace DefaultNamespace
{
    public class Crembo : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1.2f;
        [SerializeField] private SpriteRenderer wrappedCrembo;
        [SerializeField] private int wrappedSortOrder = 12;
        
        private Transform _transform;
        private float _currentSpeed;
        private bool _isWrapped;

        private void Awake()
        {
            _transform = transform;
            _currentSpeed = moveSpeed;
            SetWrappedSortOrder(0);
        }

        private void Update()
        {
            if (_currentSpeed <= 0) return;
            _transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        public void SnapToStation()
        {
            _currentSpeed = 0;
        }

        public void SwitchToWrapped()
        {
            SetWrappedSortOrder(wrappedSortOrder);
            _currentSpeed = moveSpeed;
            _isWrapped = true;
        }

        private void SetWrappedSortOrder(int so)
        {
            wrappedCrembo.sortingOrder = so;
        }

        public bool IsWrapped => _isWrapped;
    }
}