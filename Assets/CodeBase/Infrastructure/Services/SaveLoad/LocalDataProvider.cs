using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class LocalDataProvider: IDataProvider
    {
        public async UniTask<T> LoadDataAsync<T>(string key)
        {
            var loadData = await IO.LoadData<T>(key);
            return loadData;
        }

        public async UniTask SaveDataAsync(string key, object data)
        {
            await IO.SaveData(key, data);
        }
    }
}
