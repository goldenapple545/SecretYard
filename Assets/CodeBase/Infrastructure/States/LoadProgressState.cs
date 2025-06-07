using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string InitialLevel = "Main";
        private const string PlayerProgressKey = "Player";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine,
            IPersistentProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public async void Enter()
        {
            try
            {
                await LoadProgressOrInitNew();
                _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.worldData.positionOnLevel.level);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public void Exit()
        {
        }

        private async UniTask LoadProgressOrInitNew() =>
            _progressService.Progress =
                await _saveLoadService.LoadDataAsync<PlayerProgress>(PlayerProgressKey)
                ?? NewProgress();

        private PlayerProgress NewProgress() =>
            new(initialLevel: InitialLevel);
    }
}
