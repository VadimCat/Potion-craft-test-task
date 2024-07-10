using UnityEngine;

namespace PotionCraft.SceneView.Input
{
    public interface IPointerDownHandler
    {
        void HandleDown(Vector3 position);
    }
}