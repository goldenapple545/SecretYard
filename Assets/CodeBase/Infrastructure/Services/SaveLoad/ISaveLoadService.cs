using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService: IService
    {
        UniTask<T> LoadDataAsync<T>(string key);
        UniTask SaveDataAsyncAsync(string key, object data);
    }
}
