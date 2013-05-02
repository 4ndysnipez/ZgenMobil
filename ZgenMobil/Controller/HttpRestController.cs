using System;
using System.Net;
//using System.Xml;
using System.Linq;
using System.IO;
//using System.Collections.Generic;
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

			string readerText = "";

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
					StreamReader sr = new StreamReader(resp.GetResponseStream());

					string srText = sr.ReadToEnd();


					resp.Close();


					readerText = srText;
				} 
				return readerText;

			} 

			catch (WebException ex)
			{
				Console.WriteLine("Exception:  {0}", ex.Status);

				return "fehler";
			}
		}
		
		
	}
}

