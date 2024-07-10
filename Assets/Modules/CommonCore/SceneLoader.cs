using System;
using Cysharp.Threading.Tasks;
using Ji2.Context.Modules.Context;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.CommonCore
{
    public class SceneLoader : IUpdate
    {
        public event Action<float> OnProgressUpdate;
        public event Action<Scene> SceneLoaded;
        
        private readonly UpdateLoop _updateLoop;
        private AsyncOperation _currentLoadingOperation;

        public SceneLoader(UpdateLoop updateLoop)
        {
            this._updateLoop = updateLoop;
        }
        
        public async UniTask LoadScene(string sceneName)
        {
            _currentLoadingOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            _updateLoop.Add(this);
            await _currentLoadingOperation.ToUniTask();
            _currentLoadingOperation = null;
            _updateLoop.Remove(this);

            await UniTask.NextFrame(PlayerLoopTiming.PostLateUpdate);
            
            SceneLoaded?.Invoke(SceneManager.GetActiveScene());
        } 
        
        public void OnUpdate()
        {            
            OnProgressUpdate?.Invoke(_currentLoadingOperation.progress);
        }
        
        public async UniTask UnloadScene(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName).ToUniTask();
        }
    }

    public static class ContextExtensions
    {
        public static SceneLoader SceneLoader(this DiContext diContext)
        {
            return diContext.Get<SceneLoader>();
        }
    }
}