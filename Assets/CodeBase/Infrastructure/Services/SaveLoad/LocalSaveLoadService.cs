using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class LocalSaveLoadService: ISaveLoadService
    {
        public async UniTask<T> LoadDataAsync<T>(string key)
        {
            return await IO.LoadData<T>(key);
        }

        public async UniTask SaveDataAsyncAsync(string key, object data)
        {
            await IO.SaveData(key, data);
        }
    }
}
