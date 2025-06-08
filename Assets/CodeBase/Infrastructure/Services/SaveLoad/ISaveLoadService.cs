using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService: IService
    {
        UniTask<T> LoadProgress<T>();
        UniTask SaveProgress();
    }
}
