﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public class FileHelper
	{
		/// <summary>
		/// 文件写入
		/// </summary>
		/// <param name="path"></param>
		/// <param name="str"></param>
		/// <param name="encoding"></param>
		public static void Write(string path, string str, Encoding encoding)
		{
			using (FileStream fs = new FileStream(path, FileMode.Create))
			{
				using (StreamWriter sw = new StreamWriter(fs, encoding))
				{
					sw.Write(str);
				}
			}
		}
		/// <summary>
		/// 文件读取（只读取一行）
		/// </summary>
		/// <param name="path"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static string ReadLine(string path, Encoding encoding)
		{
			string str = "";
			using (StreamReader sr = new StreamReader(path, encoding))
			{
				str = sr.ReadToEnd();
			}
			return str;
		}

		/// <summary>
		/// 如果文件存在，则删除
		/// </summary>
		/// <param name="path"></param>
		public static void DeleteIfExists(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
	}
}
