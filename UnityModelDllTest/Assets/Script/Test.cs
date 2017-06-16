//#define LoadFile	//读取文件
using UnityEngine;
using System.Collections;
using StorageModel;

public class Test : MonoBehaviour {

	#region 默认测试逻辑
	
	// Update is called once per frame
	void OnGUI () {
		if (GUI.Button (new Rect (0, 0, 300, 300), "Test")) {
			OnClickTest ();
		}
	}

	public void OnClickTest()
	{
		#if LoadFile
		LoadFromPath ();
		#endif

	}

	#endregion

	#region 测试逻辑

	#if LoadFile
	/// <summary>
	/// 文件路径
	/// </summary>
	public string filePath;
	/// <summary>
	/// 读取文件
	/// </summary>
	private void LoadFromPath()
	{
		FileMgr.Instance.LoadFile (filePath, GetFile);
	}
	/// <summary>
	/// 读取文件操作回调
	/// </summary>
	/// <param name="path">文件读取路径.</param>
	/// <param name="data">文件数据.</param>
	private void GetFile(string path, byte[] data)
	{
		if (data != null) {
			Debug.Log (string.Format ("{0}的长度是{1}B\n约为{2}", path, data.Length, GetLength(data)));
		} else {
			Debug.Log ("读取失败");
		}
	}
	/// <summary>
	/// 计算该文件大小
	/// </summary>
	/// <returns>The length.</returns>
	/// <param name="data">Data.</param>
	private string GetLength(byte[] data)
	{
		int kbCount = data.Length / 1024;
		int mbCount = kbCount / 1024;
		int gbCount = mbCount / 1024;
		int bCount = data.Length - kbCount * 1024;
		kbCount = kbCount - mbCount * 1024;
		mbCount = mbCount - gbCount * 1024;
		return string.Format ("{0}GB{1}MB{2}KB{3}B", gbCount, mbCount, kbCount, bCount);
	}
	#endif

	#endregion
}
