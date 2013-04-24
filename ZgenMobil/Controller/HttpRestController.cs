using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections.Generic;




namespace ZgenMobil
{
	public class HttpRestController
	{

		private const string basic_url 					= "http://192.168.12.115:8000/sap/opu/sdata/";
		//private const string basic_url 					= "http://scdecc.scdintern.de:8000/sap/opu/sdata/";
		private const string serviceEmployee 			= "SCD/ZGEN_MI_EMPLOYEES/EMPLOYEES";
		private const string serviceOrgViews 			= "SCD/ZGEN_MI_ORG_VIEWS/ORGVIEWS";
		private const string serviceRefGroups 			= "SCD/ZGEN_MI_REF_GROUPS/REF_GROUPS";
		private const string serviceRefReasons 			= "SCD/ZGEN_MI_REF_REASONS/REF_REASONS";
		private const string serviceReferences 			= "SCD/ZGEN_MI_REFERENCES/REFERANCES";
		private const string serviceReference 			= "SCD/ZGEN_MI_REFERENCES/REFERANCE";
		private const string servicePreSelections		= "SCD/ZGEN_MI_PRESELECTIONS/PRESELECTIONS";
		private const string serviceReferenceSteps 		= "SCD/ZGEN_MI_REF_REFERENCE_STEPS/REFERANCE_STEPS";
		private const string serviceReferencePreviews 	= "SCD/ZGEN_MI_REF_REFERENCE_PREVIEW/REFERANCE_PREVIEWS";

		/*
		bool loggedIn = false;

		public bool LoggedIn {
			get {
				return loggedIn;
			}
			set {
				loggedIn = value;
			}
		}
		*/

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

		public string buildRestUrl(string select_service, string login_data)
		{


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


			try
			{
				var request = HttpWebRequest.Create(whole_url);
				request.Headers["Authorization"] = login_data;
				request.ContentType = "application/atom+xml";
				request.Method = "GET";
				
				//request.Headers["X-Requested-With"] = "XMLHttpRequest";
				//request.Headers["DataServiceVersion"] ="2.0";
				//request.Headers["X-CSRF-Token"] = "fetch";
				//request.Headers["Authorization"] = base64Encode(loggedUser, loggedPw);
				
				HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

				if(resp.StatusCode == HttpStatusCode.OK)
				{
					StreamReader reader = new StreamReader(resp.GetResponseStream());
					
					string readerText = reader.ReadToEnd();
					
					XmlDocument doc = new XmlDocument();
					doc.LoadXml(readerText);
					
					resp.Close();


					List<XmlNodeList> xmlNodeList = new List<XmlNodeList>();
					xmlNodeList.Add(doc.GetElementsByTagName("d:PERNR"));
					xmlNodeList.Add(doc.GetElementsByTagName("d:ENAME"));
					xmlNodeList.Add(doc.GetElementsByTagName("d:ORGTX"));
					xmlNodeList.Add(doc.GetElementsByTagName("d:PERSK"));
					xmlNodeList.Add(doc.GetElementsByTagName("d:BTRTX"));

					List<XmlNode> xmlNode = new List<XmlNode>();

					int hanz = 0;
					foreach(XmlNodeList node in xmlNodeList)
					{
						xmlNode.Add(node.Item(hanz));
						hanz++;
					}

					foreach(XmlNode node in xmlNode)
					{
						Console.WriteLine("fettzzz " + node.InnerText.ToString());
					}

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
				return "OK";
			} 

			catch (WebException ex)
			{
				Console.WriteLine("Exception:  {0}",ex.Status);
				return "false";
			}
		}
		
		
	}
}

