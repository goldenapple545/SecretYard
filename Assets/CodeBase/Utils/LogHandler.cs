using UnityEngine;
using System.Collections;
using System.IO;

public class LogHandler : MonoBehaviour
{
	public string folder = "logs";
	public string prefix = "app";

	private string m_file;

	void Awake ()
	{
		string path = "";

		if (Application.platform == RuntimePlatform.Android)
		{
			path = Path.Combine(Application.persistentDataPath, folder);
		}
		else
		{
			path = Path.Combine(Application.dataPath, "..", folder);
		}

		Directory.CreateDirectory (path);
		m_file = path + "/" + prefix + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
		
		Application.logMessageReceived += HandleLog;
	}

	void OnDestroy ()
	{
		Application.logMessageReceived -= HandleLog;
	}

	void HandleLog (string logString, string stackTrace, LogType type)
	{
		File.AppendAllText (m_file, logString + "\r\n");
		if (LogType.Exception == type) {
			File.AppendAllText (m_file, stackTrace + "\r\n\r\n");
		}
	}
}
