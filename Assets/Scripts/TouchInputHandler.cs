using System;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Script is referenced by this answer: https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects
/// this script is different than the TouchInputManager - since touchInputManager is for touch.finger events
/// </summary>
namespace CzernyStudio.Utilities {
    public class TouchInputHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler { //IPointerClickHandler, IPointerUpHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler

        public event Action<PointerEventData> OnTouchPress;
        public event Action<PointerEventData> OnTouchDrag;
        public event Action<PointerEventData> OnTouchRelease;

        public void OnPointerDown(PointerEventData eventData) {
            OnTouchPress?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData) {
            OnTouchDrag?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData) {
            OnTouchRelease?.Invoke(eventData);
        }

        #region other input handlers
        //public void OnBeginDrag(PointerEventData eventData) {
        //    Debug.Log("Drag Begin");
        //}

        //public void OnEndDrag(PointerEventData eventData) {
        //    Debug.Log("Drag Ended");
        //}

        //public void OnPointerClick(PointerEventData eventData) {
        //    Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        //}

        //public void OnPointerExit(PointerEventData eventData) {
        //    Debug.Log("Mouse Exit");
        //}
        #endregion
    }
}