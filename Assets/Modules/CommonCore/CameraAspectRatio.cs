using UnityEngine;

namespace Modules.CommonCore
{
    [RequireComponent(typeof(Camera))]
    public class AspectRatioHandler : MonoBehaviour
    {
        // Target aspect ratio
        private const float TargetAspect = 16.0f / 9.0f;
    
        [SerializeField] private Camera targetCamera;

        private void Start()
        {
            // Calculate the current window's aspect ratio
            float windowAspect = (float)Screen.width / Screen.height;

            // Calculate the scale height needed to match the target aspect ratio
            float scaleHeight = windowAspect / TargetAspect;

            // Adjust the camera's viewport rect
            if (scaleHeight < 1.0f)
            {
                Rect rect = targetCamera.rect;

                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;

                targetCamera.rect = rect;
            }
            else
            {
                float scaleWidth = 1.0f / scaleHeight;

                Rect rect = targetCamera.rect;

                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;

                targetCamera.rect = rect;
            }
        }

        private void OnValidate()
        {
            // Get the camera component
            targetCamera = GetComponent<Camera>();
        }
    }
}