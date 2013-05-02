using System;
using System.Net;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;
//using OData;





namespace ZgenMobil
{
	public class HttpRestController
	{
		private static HttpRestController instance;

		public static HttpRestController Instance {
			get {
				if(instance == null)
				{
					instance = new HttpRestController();
				}
				return instance;
			}
			set {
				instance = value;
			}
		}
	
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




		string loggedUser;

		public string LoggedUser {
			get {
				return loggedUser;
			}
			set {
				loggedUser = value;
			}
		}

		 bool userLogged = false;

		public bool UserLogged {
			get {
				return userLogged;
			}
			set {
				userLogged = value;
			}
		}


		
		private HttpRestController ()
		{
		}

		public string buildRestUrl(string select_service, string login_data)
		{


			//select_service = serviceEmployee; 
			
			if(userLogged == false)
			{
				Console.WriteLine("login case IS null");
				loggedUser = login_data;

				//TODO: umstellen
				//select_service = serviceOrgViews;
				select_service = serviceEmployee;

			}
			else if(userLogged == true)
			{
				Console.WriteLine("userLogged ist true..." + loggedUser);
			}

			string whole_url = basic_url + select_service;


			try
			{
				var request = HttpWebRequest.Create(whole_url);
				request.Headers["Authorization"] = loggedUser;
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
					
					XmlDocument xmlDoc = new XmlDocument();
					xmlDoc.LoadXml(readerText);


					resp.Close();


					//xmlDoc durch XmlNamespaceManager parsen

					XmlNamespaceManager xm = new XmlNamespaceManager(xmlDoc.NameTable);

					xm.AddNamespace("atom" 	, "http://www.w3.org/2005/Atom");
					xm.AddNamespace("d" 	, "http://schemas.microsoft.com/ado/2007/08/dataservices");
					xm.AddNamespace("m"		, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
					xm.AddNamespace("sap"	, "http://www.sap.com/Protocols/SAPData");
					xm.AddNamespace("base"	, "HTTP://SCDECC.SCDINTERN.DE:8000/sap/opu/sdata/SCD/ZGEN_MI_EMPLOYEES/");


					XmlNodeList elements = xmlDoc.DocumentElement.SelectNodes("./atom:entry" , xm);
					Console.WriteLine("test count: " + elements.Count.ToString());

					foreach (XmlNode element in elements)
					{
						XmlNodeList properties = element.SelectSingleNode("./atom:content/m:properties/d:PERNR" , xm).ChildNodes;

						foreach(XmlNode property in properties)
						{
							Console.WriteLine(property.InnerText.ToString() + " neee oder?!?!?" );
						}

					}

					//TagName("d:PERNR");
					//TagName("d:ENAME");
					//TagName("d:ORGTX");
					//TagName("d:PERSK");
					//TagName("d:BTRTX");

				} 
				userLogged = true;
				return "OK";
			} 

			catch (WebException ex)
			{
				Console.WriteLine("Exception:  {0}", ex.Status);

				return "false";
			}
		}
		
		
	}
}

