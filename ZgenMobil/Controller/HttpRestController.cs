using System;
using System.Net;
using System.Xml;
using System.IO;




namespace ZgenMobil
{
	public class HttpRestController
	{
		
		const string basic_url = "http://192.168.12.115:8000/sap/opu/sdata/";
		const string serviceEmployee = "SCD/ZGEN_MI_EMPLOYEES/EMPLOYEES";
		string loggedUser_data;
		
		public string LoggedUser_data {
			get {
				return loggedUser_data;
			}
			set {
				loggedUser_data = value;
			}
		}
		
		public HttpRestController ()
		{
		}
		
		
		//Convert to Base64
		public string base64Encode(string http_user, string http_pw){
			
			//http_user = "p20000000";
			//http_pw = "scdsoft1";
			string user_pw = http_user + ":" + http_pw;
			
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			byte[] bytes = encoding.GetBytes(user_pw);
			string base64 = System.Convert.ToBase64String(bytes);
			
			return "Basic " + base64;
			
		}
		/*
		public string testUrl(string select_service, string login_data)
		{
			if(loggedUser_data == null)
			{
				Console.WriteLine("login case IS null");
				loggedUser_data = login_data;
				select_service = serviceEmployee;
			}

			else if(loggedUser_data != null)
			{
				Console.WriteLine("login case !null");;
			}

			string whole_url = basic_url + select_service;
			//create HttpREST request
			var request = HttpWebRequest.Create(new Uri(whole_url));
			request.Headers["Authorization"] = login_data;
			request.ContentType = "application/atom+xml";
			request.Method = "GET";

			HttpWebResponse resp = (HttpWebResponse)request.GetResponse();



		}
*/
		public string buildRestUrl(string select_service, string login_data)
		{
			string status;
			
			
			//select_service = serviceEmployee; 
			
			if(loggedUser_data == null)
			{
				Console.WriteLine("login case IS null");
				loggedUser_data = login_data;
				select_service = serviceEmployee;
			}
			
			else if(loggedUser_data != null)
			{
				Console.WriteLine("login case !null");
				select_service = serviceEmployee;
			}
			
			string whole_url = basic_url + select_service;
			//create HttpREST request
			var request = HttpWebRequest.Create(whole_url);
			request.Headers["Authorization"] = login_data;
			request.ContentType = "application/atom+xml";
			request.Method = "GET";
			
			//request.Headers["X-Requested-With"] = "XMLHttpRequest";
			//request.Headers["DataServiceVersion"] ="2.0";
			//request.Headers["X-CSRF-Token"] = "fetch";
			//request.Headers["Authorization"] = base64Encode(loggedUser, loggedPw);
			
			HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
			
			status = resp.StatusCode.ToString();
			
			if(status == "OK")
			{
				StreamReader reader = new StreamReader(resp.GetResponseStream());
				
				string readerText = reader.ReadToEnd();
				
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(readerText);
				
				resp.Close();
				
				XmlNodeList propList 	= doc.GetElementsByTagName("m:properties");
				XmlNodeList pernrList 	= doc.GetElementsByTagName("d:PERNR");
				XmlNodeList enameList	= doc.GetElementsByTagName("d:ENAME");
				XmlNodeList orgtxList 	= doc.GetElementsByTagName("d:ORGTX");
				XmlNodeList perskList 	= doc.GetElementsByTagName("d:PERSK");
				XmlNodeList btrtxList 	= doc.GetElementsByTagName("d:BTRTX");
				
				Console.WriteLine("count " + pernrList.Count);
				Console.WriteLine("prop: " + propList[0].InnerText);
				
				for(int i=0; i < pernrList.Count; i++){
					XmlNode pernrItem = pernrList.Item(i);
					XmlNode enameItem = enameList.Item(i);
					XmlNode orgtxItem = orgtxList.Item(i);
					XmlNode perskItem = perskList.Item(i);
					XmlNode btrtxItem = btrtxList.Item(i);
					
					int zahl = i+1;
					Console.WriteLine(zahl + "."  
					                  + " PernNr: "	+ pernrItem.InnerText 
					                  + " name: "		+ enameItem.InnerText
					                  + " org: " 		+ orgtxItem.InnerText
					                  + " persk: " 	+ perskItem.InnerText
					                  + " btrx: " 	+ btrtxItem.InnerText
					                  );
				}
				
				for(int j=0; j < propList.Count; j++){
					Console.WriteLine(
						" PernNr: "	+ pernrList[j].InnerText 
						+ " name: "	+ enameList[j].InnerText
						//+ " org: " 	+ orgtxItem.InnerText
						//+ " persk: " 	+ pernrItem.InnerText
						//+ " btrx: " 	+ btrtxItem.InnerText
						);
				}
				
			}
			
			else
			{
				return "false";
			}
			return status;
		}
		
		
	}
}

