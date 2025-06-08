using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface IDataProvider
    {
        UniTask<T> LoadDataAsync<T>(string key);
        UniTask SaveDataAsync(string key, object data);
    }
}
