using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	/// <summary>
	/// 加解密帮助类
	/// </summary>
	public class EncryptHelper
	{
		//private static string encryptKey = "Oyea";    //定义密钥  
		private static string encryptKey =  ConfigurationHelper.GetAppSettingStr("EncryptKey");    //定义密钥  
		#region 加密字符串  
		/// <summary> 
		/// 加密字符串   
		/// </summary>  
		/// <param name="str">要加密的字符串</param>  
		/// <returns>加密后的字符串</returns>  
		public static string Encrypt(string str)
		{
			DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

			byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

			byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  

			MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

			//使用内存流实例化加密流对象   
			CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

			CStream.Write(data, 0, data.Length);  //向加密流中写入数据      

			CStream.FlushFinalBlock();              //释放加密流      

			return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
		}
		#endregion

		#region 解密字符串   
		/// <summary>  
		/// 解密字符串   
		/// </summary>  
		/// <param name="str">要解密的字符串</param>  
		/// <returns>解密后的字符串</returns>  
		public static string Decrypt(string str, string from)
		{
			DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

			byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

			byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

			MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

			//使用内存流实例化解密流对象       
			CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

			CStream.Write(data, 0, data.Length);       //向解密流中写入数据     

			CStream.FlushFinalBlock();               //释放解密流      

			return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
		}
		#endregion

		/// <summary> 
		/// DES加密 
		/// </summary>
		public static string DESEncrypt(string value)
		{
			

			byte[] keyArray = Encoding.UTF8.GetBytes(encryptKey);
			byte[] toEncryptArray = Encoding.UTF8.GetBytes(value);

			DESCryptoServiceProvider rDel = new DESCryptoServiceProvider();
			rDel.Key = keyArray;
			rDel.Mode = CipherMode.ECB;
			rDel.Padding = PaddingMode.PKCS7;

			ICryptoTransform cTransform = rDel.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		/// <summary> 
		/// DES解密 
		/// </summary>
		public static string DESDecrypt(string value)
		{
			try
			{
				byte[] keyArray = Encoding.UTF8.GetBytes(encryptKey);
				byte[] toEncryptArray = Convert.FromBase64String(value);

				DESCryptoServiceProvider rDel = new DESCryptoServiceProvider();
				rDel.Key = keyArray;
				rDel.Mode = CipherMode.ECB;
				rDel.Padding = PaddingMode.PKCS7;

				ICryptoTransform cTransform = rDel.CreateDecryptor();
				byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

				return Encoding.UTF8.GetString(resultArray);
			}
			catch
			{
				return string.Empty;
			}
		}

		//加密
		public static void Encrypt(byte[] byteArray, int offset, int len)
		{
			for (int i = 0; i < len; i++)
				byteArray[i + offset] ^= 0xa7;

		}
		//解密
		public static void Decrypt(byte[] byteArray, int offset, int len)
		{
			for (int i = 0; i < len; i++)
				byteArray[i + offset] ^= 0xa7;

		}
	}
}
