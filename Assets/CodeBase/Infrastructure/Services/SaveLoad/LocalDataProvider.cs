using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class LocalDataProvider: IDataProvider
    {
        public async UniTask<T> LoadDataAsync<T>(string key)
        {
            var loadData = await IO.LoadData<T>(key);
            Debug.Log(loadData.ToString());
            return loadData;
        }

        public async UniTask SaveDataAsync(string key, object data)
        {
            await IO.SaveData(key, data);
        }
    }
}
