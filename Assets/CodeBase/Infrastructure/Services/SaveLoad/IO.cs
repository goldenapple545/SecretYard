using Cysharp.Threading.Tasks;
using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

    namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public static class IO
    {
        private static readonly SemaphoreSlim _saveSemaphore = new SemaphoreSlim(1, 1);

        public static async UniTask<TResult> LoadData<TResult>(string key)
        {
            var RawData = await GetDataInJSON(key);
            if (RawData == null) return (TResult)default;
            var JsonData = System.Text.Encoding.UTF8.GetString(RawData);
            return (TResult) JsonConvert.DeserializeObject<TResult>(JsonData);
        }

        public static async UniTask<byte[]> GetDataInJSON(string Name)
        {
            string Path = GetFullPath(Name);
            if (!File.Exists(Path))
            {
                return null;
            }
            byte[] Result = null;
            using (var Reader = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Result = new byte[Reader.Length];
                await Reader.ReadAsync(Result, 0, Result.Length);
                Reader.Close();
                Reader.Dispose();
            }
            return Result;
        }

        public static async UniTask SaveData(string key, object Serialized)
        {
            await _saveSemaphore.WaitAsync();
            try
            {
                var JsonString = JsonConvert.SerializeObject(Serialized, Formatting.Indented);
                await WriteData(key, JsonString);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to save data: {ex.Message}");
            }
            finally
            {
                _saveSemaphore.Release();
            }
        }

        public static async UniTask WriteData(string key, string Data)
        {
            var RawData = System.Text.Encoding.UTF8.GetBytes(Data);
            string Path = GetFullPath(key);
            using (var Writer = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.Write, bufferSize: 4096, FileOptions.WriteThrough))
            {
                await Writer.WriteAsync(RawData,0, RawData.Length);
            }

            var fileInfo = new FileInfo(Path);
            Debug.Log($"File size: {fileInfo.Length} bytes");
        }

        public static void DeleteData(string dataType)
        {
            string Path = GetFullPath(dataType);
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }

        public static void DeleteAllData()
        {
            string directoryPath = Application.persistentDataPath;
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
        }

        static string GetFullPath(string FileName) => Application.persistentDataPath + "/" + FileName + ".json";
    }
}
