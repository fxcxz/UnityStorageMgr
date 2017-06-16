using System.Collections.Generic;
namespace StorageModel
{
	/// <summary>
	/// 文件结构体
	/// </summary>
	public struct MemItem{
		private string fileName;
		private byte[] data;
		private int fileWeight;
		private string md5Code;

		public string FileName
		{
			get
			{
				return fileName;
			}
			internal set
			{
				fileName = value;
			}
		}
		public byte[] Data
		{
			get{
				return data;
			}
			internal set
			{
				data = value;
			}
		}
		public int Weight
		{
			get
			{
				return fileWeight;
			}
			internal set
			{
				fileWeight = value;
			}
		}
		internal string Md5Code
		{
			get
			{
				return md5Code;
			}
			set
			{
				md5Code = value;
			}
		}
	}
}
