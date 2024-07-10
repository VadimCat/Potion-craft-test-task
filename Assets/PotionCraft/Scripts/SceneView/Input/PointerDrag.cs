using UnityEngine;

namespace PotionCraft.SceneView.Input
{
    public class PointerDrag
    {
        private readonly PointerDrag _pointerDrag;
        private IDraggable _currentHoldable;

        public void AddDraggable(IDraggable pointerHoldHandler, Vector3 position)
        {
            _currentHoldable = pointerHoldHandler;
            _currentHoldable.HandleDown(position);
        }

        public void TryHandleHold(Vector3 position)
        {
            _currentHoldable?.HandleHold(position);
        }

        public void ReleaseDraggable(Vector3 position)
        {
            _currentHoldable?.HandleUp(position);
            _currentHoldable = null;
        }
    }
}