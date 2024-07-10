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
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private UpdateLoop updateLoop;
        [SerializeField] private NameFactory nameFactory;
        [SerializeField] private ScoreFactory scoreFactory;
        [SerializeField] private IngredientsViewConfig ingredientsViewConfig;

        public void Start()
        {
            DiContext diContext = DiContext.GetOrCreateInstance();

            scoreFactory.Bootstrap();

            TapInputAction tapInputAction = new TapInputAction(new TouchScreenInputActions(), updateLoop);

            diContext.Register(tapInputAction);
            diContext.Register(nameFactory);
            diContext.Register(scoreFactory);
            diContext.Register(ingredientsViewConfig);
            diContext.Register(new PointerDrag());
            diContext.Register(new Hover());
            diContext.Register(new SceneLoader(updateLoop));

            StateMachine stateMachine = new StateMachine();
            stateMachine.AddState(new GameState(stateMachine, diContext));

            stateMachine.Enter<GameState>().Forget();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}