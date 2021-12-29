using u1w202112.Model;
using u1w202112.UseCase.MainGame;
using u1w202112.UseCase.MainGame.State;
using u1w202112.View.MainGame;
using u1w202112.View.MainGame.Photon;
using u1w202112.View.MainGame.State;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace u1w202112.Installer
{
    public class MainInstaller : LifetimeScope
    {
        // State
        [SerializeField] private WaitStateRenderer waitStateRenderer = default;
        [SerializeField] private ReadyStateRenderer readyStateRenderer = default;
        [SerializeField] private MyAttackStateRenderer myAttackStateRenderer = default;
        [SerializeField] private OthersAttackStateRenderer othersAttackStateRenderer = default;
        [SerializeField] private ResultStateRenderer resultStateRenderer = default;
        [SerializeField] private WaitSelectDefenceStateRenderer waitSelectDefenceStateRenderer = default;
        [SerializeField] private SelectDefenceStateRenderer selectDefenceStateRenderer = default;
        
        // Hand
        [SerializeField] private SelfHandRenderer selfHandRenderer = default;
        
        // Selected Card
        [SerializeField] private SelfUseCardRenderer selfUseCardRenderer = default;
        [SerializeField] private SubmitUseCardHandler submitUseCardHandler = default;
        [SerializeField] private OpponentUseCardRenderer opponentUseCardRenderer = default;
        
        // Button
        [SerializeField] private TurnEndButton turnEndButton = default;
        [SerializeField] private StartGameButton startGameButton = default;
        [SerializeField] private ResetHandButton resetHandButton = default;
        [SerializeField] private DrawButton drawButton = default;
        [SerializeField] private BackToLobbyButtons backToLobbyButtons = default;
        
        // Photon
        [SerializeField] private PhotonPlayer photonPlayer = default;
        [SerializeField] private PhotonGameStarter photonGameStarter = default;
        [SerializeField] private PhotonTurnChanger photonTurnChanger = default;
        [SerializeField] private PhotonUseCardSender photonUseCardSender = default;
        [SerializeField] private PhotonPlayerStatus photonPlayerStatus = default;
        
        // Player Status
        [SerializeField] private SelfStatusRenderer selfStatusRenderer = default;
        [SerializeField] private OpponentStatusRenderer opponentStatusRenderer = default;
        [SerializeField] private HpChangeRenderer hpChangeRenderer = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // State
            builder.RegisterInstance(waitStateRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(readyStateRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(myAttackStateRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(othersAttackStateRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(resultStateRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(waitSelectDefenceStateRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(selectDefenceStateRenderer).AsImplementedInterfaces();
            
            builder.Register<MainGameStateModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<WaitStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ReadyStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<MyStartStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<MyAttackStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<MyEndStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<OthersAttackStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<ResultStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<WaitSelectDefenceStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<SelectDefenceStateUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            
            // Hand
            builder.RegisterInstance(selfHandRenderer).AsImplementedInterfaces();
            
            builder.Register<HandUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            
            // Selected Card
            builder.Register<SelfUseCardUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<UseCardUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<UsedCardModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterInstance(selfUseCardRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(submitUseCardHandler).AsImplementedInterfaces();
            builder.RegisterInstance(opponentUseCardRenderer).AsImplementedInterfaces();
            
            // Button
            builder.RegisterInstance(turnEndButton).AsImplementedInterfaces();
            builder.RegisterInstance(startGameButton).AsImplementedInterfaces();
            builder.RegisterInstance(resetHandButton).AsImplementedInterfaces();
            builder.RegisterInstance(drawButton).AsImplementedInterfaces();
            builder.RegisterInstance(backToLobbyButtons).AsImplementedInterfaces();
            
            // Player
            builder.Register<MainGamePlayersModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<RoomPlayerUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            
            // Photon
            builder.RegisterInstance(photonPlayer).AsImplementedInterfaces();
            builder.RegisterInstance(photonGameStarter).AsImplementedInterfaces();
            builder.RegisterInstance(photonTurnChanger).AsImplementedInterfaces();
            builder.RegisterInstance(photonUseCardSender).AsImplementedInterfaces();
            builder.RegisterInstance(photonPlayerStatus).AsImplementedInterfaces();

            // Player Status
            builder.RegisterInstance(selfStatusRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(opponentStatusRenderer).AsImplementedInterfaces();
            builder.RegisterInstance(hpChangeRenderer).AsImplementedInterfaces();
            builder.Register<PlayerStatusUseCase>(Lifetime.Scoped).AsImplementedInterfaces();
            
            
            builder.RegisterEntryPoint<MainGameStateUseCase>(Lifetime.Scoped);

        }
    }
}
