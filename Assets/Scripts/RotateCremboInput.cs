using CzernyStudio.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CremboFactory {
    public class RotateCremboInput : MonoBehaviour {
        [SerializeField] private float initialRotationSpeed = 2f;
        [SerializeField] private float sensitivity = 5f;
        [SerializeField] private Transform objectToRotate;

        private TouchInputHandler _touchInputHandler;

        protected void Awake() {
            _touchInputHandler = FindObjectOfType<TouchInputHandler>();
            _touchInputHandler.OnTouchDrag += OnDrag;
        }

        protected void OnDestroy() {
            _touchInputHandler.OnTouchDrag -= OnDrag;
        }

        private void OnDrag(PointerEventData eventData) {
            var direction = new Vector3(eventData.delta.y, -eventData.delta.x, 0f);
            var dragSpeed = eventData.delta.magnitude * initialRotationSpeed * sensitivity;
            objectToRotate.Rotate(direction, dragSpeed * Time.deltaTime, Space.World);
            //Debug.Log($"Drag speed is {eventData.delta.magnitude}");
            MessagingSystem.RotationSpeed?.Invoke(eventData.delta.magnitude);
        }
    }
}
