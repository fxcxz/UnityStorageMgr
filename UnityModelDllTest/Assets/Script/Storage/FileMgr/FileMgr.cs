using UnityEngine;
using System.Collections;

namespace StorageModel
{
	public class FileMgr : MonoBehaviour{
		
		public static FileMgr Instance;

		void Awake()
		{
			Instance = this;
		}

		#region 文件读取
		/// <summary>
		///读取文件后回调 
		/// </summary>
		public delegate void LoadFileCallBack(string path, byte[] data);
		/// <summary>
		/// 读取文件接口.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="callBack">Call back.</param>
		public void LoadFile(string path, LoadFileCallBack callBack)
		{
			StartCoroutine (ILoadFile(path, callBack));
		}
		/// <summary>
		/// 读取文件
		/// </summary>
		/// <returns>The load file.</returns>
		/// <param name="path">Path.</param>
		/// <param name="callBack">Call back.</param>
		IEnumerator ILoadFile(string path, LoadFileCallBack callBack)
		{
			WWW www;
			if (path.IndexOf ("://") != -1) {
				//获取网络数据逻辑
				www = new WWW (path);
				yield return www;
			} else {
	//			path = "files:///" + path;
				www = new WWW ("file:///" + path);
				yield return www;
			}
			if (www.error != null) {
				Debug.LogError (string.Format ("fileMgr==>>>path = {0}\nerror = {1}", path, www.error));
				callBack (path, null);
			} else {
				callBack (path, www.bytes);
			}
		}


		#endregion

		#region 文件立即销毁

		public void DestoryFile(byte[] data)
		{
			//c++写销毁释放部分
		}

		#endregion
	}
}
