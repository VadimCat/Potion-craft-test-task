using System;
using Modules.Input;
using Modules.Input.Tap;
using UnityEngine;

namespace PotionCraft.SceneView.Input
{
    public class GameInput: IDisposable
    {
        private readonly ITapInputAction _tapInputAction;
        private readonly Camera _camera;
        private readonly PointerDrag _pointerDrag;
        private readonly Hover _hover;

        public GameInput(ITapInputAction tapInputAction, PointerDrag pointerDrag, Hover hover, Camera camera)
        {
            _tapInputAction = tapInputAction;
            _camera = camera;
            _pointerDrag = pointerDrag;
            _hover = hover;

            tapInputAction.EventTapUpdated += OnTapUpdated;
            tapInputAction.Enable();
        }

        private void OnTapUpdated(TouchData touchData)
        {
            switch (touchData.Phase)
            {
                case ClickPhase.Began:
                    HandlePointerDown(touchData);
                    break;
                case ClickPhase.Pressed:
                    HandlePointerHold(touchData);
                    break;
                case ClickPhase.NotPressed:
                    HandlePointerMove(touchData);
                    break;
                case ClickPhase.Ended:
                    HandlePointerUp(touchData);
                    break;
            }
        }

        private void HandlePointerMove(TouchData touchData)
        {
            var hit = RaycastHit2D(touchData.Position);
            if (hit.collider != null)
            {
                var pointerDownHandler = hit.collider.GetComponent<IHoverable>();
                _hover.HandleHover(pointerDownHandler);
            }
        }

        private void HandlePointerDown(TouchData touchData)
        {
            Vector3 position = Position(touchData.Position);
            var hit = RaycastHit2D(touchData.Position);
            if (hit.collider != null)
            {
                position.z = 0;
                var pointerDownHandler = hit.collider.GetComponent<IPointerDownHandler>();
                pointerDownHandler?.HandleDown(position);
                
                if (pointerDownHandler is IDraggable draggable)
                {
                    _pointerDrag.AddDraggable(draggable, position);
                }
            }
        }

        private void HandlePointerHold(TouchData touchData)
        {
            Vector3 position = Position(touchData.Position);
            _pointerDrag.TryHandleHold(position);
        }

        private void HandlePointerUp(TouchData touchData)
        {
            Vector3 position = Position(touchData.Position);
            _pointerDrag.ReleaseDraggable(position);
        }

        private RaycastHit2D RaycastHit2D(Vector2 pointerPosition)
        {
            var position = Position(pointerPosition);
            Debug.DrawRay(position, Vector3.forward * 10, Color.red, .1f);
            var hit = Physics2D.Raycast(position, Vector2.zero);
            return hit;
        }

        private Vector3 Position(Vector2 pointerPosition)
        {
            Vector3 pos = pointerPosition;
            pos.z = -_camera.transform.position.z;
            return _camera.ScreenToWorldPoint(pos);
        }

        public void Dispose()
        {
            _tapInputAction.EventTapUpdated -= OnTapUpdated;
        }
    }
}