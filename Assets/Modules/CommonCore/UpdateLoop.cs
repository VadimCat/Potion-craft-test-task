using System.Collections.Generic;
using UnityEngine;

namespace Modules.CommonCore
{
    public class UpdateLoop : MonoBehaviour
    {
        private readonly List<IUpdate> _updates = new();
        private readonly List<IFixedUpdate> _fixedUpdates = new();
        private readonly List<ILateUpdate> _lateUpdates = new();

        private void Update()
        {
            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdates.Count; i++)
            {
                _fixedUpdates[i].OnFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            foreach(var lateUpdatable in _lateUpdates)
            {
                lateUpdatable.OnLateUpdate();
            }
        }

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

    public interface IUpdate
    {
        public void OnUpdate();
    }

    public interface IFixedUpdate
    {
        public void OnFixedUpdate();
    }

    public interface ILateUpdate
    {
        public void OnLateUpdate();
    }
}