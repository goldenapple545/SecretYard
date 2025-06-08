using Autohand;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Player
{
    public class Player: MonoBehaviour, ISavedProgress
    {
        public AutoHandPlayer characterController;

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.worldData.positionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() != progress.worldData.positionOnLevel.level) return;
            Vector3Data savedPosition = progress.worldData.positionOnLevel.position;
            if (savedPosition != null)
                Warp(to: savedPosition);

        }

        private void Warp(Vector3Data to)
        {
            characterController.enabled = false;
            Debug.Log(to.AsUnityVector().ToString());
            characterController.SetPosition(to.AsUnityVector());
            characterController.enabled = true;
        }

        private string CurrentLevel() => SceneManager.GetActiveScene().name;
    }
}
