﻿using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState: IState
    {
        private const string PlayerProgressKey = "Player";
        private const string Initial = "Initial";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(new LocalDataProvider(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>(),
                PlayerProgressKey));
        }
    }
}
