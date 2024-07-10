using System.Collections.Generic;
using UnityEngine;

namespace Modules.CommonCore
{
    /// <summary>
    /// Manages update, fixed update, and late update calls for objects implementing specific interfaces.
    /// </summary>
    public class UpdateLoop : MonoBehaviour
    {
        private readonly List<IUpdate> _updates = new List<IUpdate>();
        private readonly List<IFixedUpdate> _fixedUpdates = new List<IFixedUpdate>();
        private readonly List<ILateUpdate> _lateUpdates = new List<ILateUpdate>();

        /// <summary>
        /// Executes OnUpdate for all registered IUpdate objects during Unity's Update phase.
        /// </summary>
        private void Update()
        {
            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].OnUpdate();
            }
        }

        /// <summary>
        /// Executes OnFixedUpdate for all registered IFixedUpdate objects during Unity's FixedUpdate phase.
        /// </summary>
        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdates.Count; i++)
            {
                _fixedUpdates[i].OnFixedUpdate();
            }
        }

        /// <summary>
        /// Executes OnLateUpdate for all registered ILateUpdate objects during Unity's LateUpdate phase.
        /// </summary>
        private void LateUpdate()
        {
            foreach (var lateUpdatable in _lateUpdates)
            {
                lateUpdatable.OnLateUpdate();
            }
        }

        /// <summary>
        /// Adds an object to the respective update list based on its implemented interface.
        /// </summary>
        /// <param name="updatable">Object implementing IUpdate, IFixedUpdate, or ILateUpdate.</param>
        public void Add(object updatable)
        {
            if (updatable is IUpdate upd && !_updates.Contains(upd))
            {
                _updates.Add(upd);
            }
            if (updatable is IFixedUpdate fixUpd && !_fixedUpdates.Contains(fixUpd))
            {
                _fixedUpdates.Add(fixUpd);
            }
            if (updatable is ILateUpdate lateUpd && !_lateUpdates.Contains(lateUpd))
            {
                _lateUpdates.Add(lateUpd);
            }
        }

        /// <summary>
        /// Removes an object from the respective update list based on its implemented interface.
        /// </summary>
        /// <param name="updatable">Object implementing IUpdate, IFixedUpdate, or ILateUpdate.</param>
        public void Remove(object updatable)
        {
            if (updatable is IUpdate upd && _updates.Contains(upd))
            {
                _updates.Remove(upd);
            }
            if (updatable is IFixedUpdate fixUpd && _fixedUpdates.Contains(fixUpd))
            {
                _fixedUpdates.Remove(fixUpd);
            }
            if (updatable is ILateUpdate lateUpd && _lateUpdates.Contains(lateUpd))
            {
                _lateUpdates.Remove(lateUpd);
            }
        }
    }

    /// <summary>
    /// Interface for objects that require update calls during Unity's Update phase.
    /// </summary>
    public interface IUpdate
    {
        void OnUpdate();
    }

    /// <summary>
    /// Interface for objects that require update calls during Unity's FixedUpdate phase.
    /// </summary>
    public interface IFixedUpdate
    {
        void OnFixedUpdate();
    }

    /// <summary>
    /// Interface for objects that require update calls during Unity's LateUpdate phase.
    /// </summary>
    public interface ILateUpdate
    {
        void OnLateUpdate();
    }
}
