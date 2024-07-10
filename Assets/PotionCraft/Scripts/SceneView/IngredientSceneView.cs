using Ji2.Pools;
using PotionCraft.Models.Ingredients;
using PotionCraft.SceneView.Input;
using UnityEngine;

namespace PotionCraft.SceneView
{
    public class IngredientSceneView : MonoBehaviour, IHoverable, IPoolable, IDraggable, IIngredient
    {
        private static readonly int IsHovered = Shader.PropertyToID("_IsHovered");
        private const float ThrowForce = 25;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Vector2? _diff;
        private Vector2? _targetPosition;
        private IIngredient _ingredient;
        private Bounds2DPhysics _bounds;
        public IIngredient Implementation => _ingredient;

        public IngredientId Id => _ingredient.Id;

        private void Construct(IIngredient ingredient, Bounds2DPhysics bounds2DPhysics)
        {
            _bounds = bounds2DPhysics;
            _ingredient = ingredient;
        }

        public void Spawn()
        {
            gameObject.SetActive(true);
        }

        public void DeSpawn()
        {
            gameObject.SetActive(false);
        }

        public void HandleDown(Vector3 position)
        {
            spriteRenderer.material.SetFloat(IsHovered, 0);
            rb.velocity = Vector2.zero;
            _diff = transform.position - position;
        }

        public void HandleHold(Vector3 position)
        {
            if (_diff == null)
            {
                rb.velocity = Vector2.zero;
                _diff = transform.position - position;
            }
            else
            {
                _targetPosition = position + (Vector3)_diff.Value;
            }
        }

        public void HandleUp(Vector3 position)
        {
            if (_diff != null)
            {
                var impulse = (Vector2)position + _diff.Value - (Vector2)transform.position;
                rb.AddForce(impulse * ThrowForce, ForceMode2D.Impulse);
                _diff = null;
                _targetPosition = null;
            }
        }

        public void HoverEnter()
        {
            spriteRenderer.material.SetFloat(IsHovered, 1);
        }

        public void HoverExit()
        {
            spriteRenderer.material.SetFloat(IsHovered, 0);
        }

        private void Update()
        {
            if (_diff != null && _targetPosition != null)
            {
                rb.MovePosition(Vector3.Lerp(transform.position, _targetPosition.Value, .5f));
                rb.velocity = Vector2.zero;
            }
        }

        private void LateUpdate()
        {
            _bounds.Clamp(rb);
        }

        public class Factory
        {
            private readonly Pool<IngredientSceneView> _pool;

            public Factory(Pool<IngredientSceneView> pool)
            {
                _pool = pool;
            }

            public IngredientSceneView Create(IIngredient ingredient, Bounds2DPhysics bounds, Vector3 position)
            {
                IngredientSceneView instance = _pool.Spawn(position);
                instance.Construct(ingredient, bounds);

                return instance;
            }
        }
    }
}