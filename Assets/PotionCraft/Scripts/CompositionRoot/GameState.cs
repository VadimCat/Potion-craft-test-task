using Cysharp.Threading.Tasks;
using Ji2.Context.Modules.Context;
using Modules.CommonCore;
using Modules.Input.Tap;
using PotionCraft.Models.Dishes.Naming;
using PotionCraft.Models.Dishes.Scoring;
using PotionCraft.SceneView;
using PotionCraft.SceneView.Input;
using UnityEngine;

namespace PotionCraft.CompositionRoot
{
    public class GameState : IState, IExitableState
    {
        const string GameSceneName = "GameScene";

        private readonly StateMachine _stateMachine;
        private readonly DiContext _context;
        private readonly SceneLoader _sceneLoader;

        public GameState(StateMachine stateMachine, DiContext context)
        {
            _stateMachine = stateMachine;
            _context = context;
            _sceneLoader = context.SceneLoader();
        }

        public async UniTask Exit()
        {
            await _sceneLoader.UnloadScene(GameSceneName);
        }

        public async UniTask Enter()
        {
            await _sceneLoader.LoadScene(GameSceneName);
            var sceneBoostrap = Object.FindFirstObjectByType<GameSceneBootstrap>();
            sceneBoostrap.Construct(
                _context.Get<ScoreFactory>(), 
                _context.Get<NameFactory>(), 
                _context.Get<TapInputAction>(),
                _context.Get<PointerDrag>(),
                _context.Get<Hover>(),
                _context.Get<IngredientsViewConfig>());
        }
    }
}