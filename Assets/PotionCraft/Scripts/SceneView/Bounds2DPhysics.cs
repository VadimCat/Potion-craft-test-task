using UnityEngine;

namespace PotionCraft.SceneView
{
    public class Bounds2DPhysics : MonoBehaviour
    {
        [SerializeField] private Transform botLeft;
        [SerializeField] private Transform topRight;

        public void Clamp(Rigidbody2D rb)
        {
            if (rb.transform.position.x < botLeft.position.x || rb.transform.position.x > topRight.position.x ||
                rb.transform.position.y < botLeft.position.y || rb.transform.position.y > topRight.position.y)
            {
                var position = rb.transform.position;
                var botLeftPosition = botLeft.position;
                var topRightPosition = topRight.position;
                float x = Mathf.Clamp(position.x, botLeftPosition.x, topRightPosition.x);
                float y = Mathf.Clamp(position.y, botLeftPosition.y, topRightPosition.y);
                position = new Vector3(x, y, position.z);
                rb.transform.position = position;
            }
        }
    }
}