using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService: ISaveLoadService
    {
        private readonly string _playerProgressKey;

        private readonly IDataProvider _dataProvider;
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IDataProvider dataProvider, IPersistentProgressService progressService,
            IGameFactory gameFactory, string playerProgressKey)
        {
            _dataProvider = dataProvider;
            _progressService = progressService;
            _playerProgressKey = playerProgressKey;
            _gameFactory = gameFactory;
        }

        public UniTask SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);

            return _dataProvider.SaveDataAsync(_playerProgressKey, _progressService.Progress);
        }

        public async UniTask<T> LoadProgress<T>() =>
            await _dataProvider.LoadDataAsync<T>(_playerProgressKey);
    }
}
