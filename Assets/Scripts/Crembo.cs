using UnityEngine;

namespace DefaultNamespace
{
    public class Crembo : MonoBehaviour
    {
        [SerializeField] private GameModel model;
        [SerializeField] private float moveSpeed = 1.2f;
        [SerializeField] private SpriteRenderer wrappedCrembo;
        [SerializeField] private int wrappedSortOrder = 12;
        [SerializeField] private float minYPosition = -5f;
        
        private Transform _transform;
        private Vector3 _initialPosition;
        private Vector3 _currentPosition;
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
            if (_transform.position.y <= minYPosition)
            {
                HandleBeltEnd();
            }
            _transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        public void SetInitialPosition(Vector3 spawnPosition)
        {
            _initialPosition = spawnPosition;
        }

        public void SnapToStation()
        {
            _currentPosition = _transform.position;
            _currentSpeed = 0;
        }

        public void SwitchToWrapped()
        {
            SetWrappedSortOrder(wrappedSortOrder);
            _currentSpeed = moveSpeed;
            _transform.position = new Vector3(_currentPosition.x, _currentPosition.y - 1f, _currentPosition.z);
            _isWrapped = true;
        }

        private void SetWrappedSortOrder(int so)
        {
            wrappedCrembo.sortingOrder = so;
        }

        /// <summary>
        /// At the end of the belt,
        /// update game model if crembo is wrapped or missed
        /// reuse crembo again
        /// </summary>
        private void HandleBeltEnd()
        {
            if (_isWrapped)
            {
                model.IncreaseWrappedCrembo();
            } else
            {
                model.IncreaseMissedCrembo();
            }
            
            _transform.position = _initialPosition;
            _isWrapped = false;
            SetWrappedSortOrder(0);
        }

        public bool IsWrapped => _isWrapped;
    }
}