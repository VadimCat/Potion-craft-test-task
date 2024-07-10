using UnityEngine;

namespace PotionCraft.SceneView.Input
{
    public interface IDraggable: IPointerDownHandler
    {
        void HandleHold(Vector3 position);
        void HandleUp(Vector3 position);
    }
}