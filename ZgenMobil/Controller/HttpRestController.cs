using System;
using System.Net;
using System.Linq;
using System.IO;

namespace ZgenMobil
{
	public class HttpRestController
	{
		/// <summary>
		/// Deklarations
		/// </summary>
		private static HttpRestController instance;
		string loggedUser;
		bool userLogged = false;

		/// <summary>
		/// Konstanten der URLs der Webservices
		/// </summary>
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

		/// <summary>
		/// Gets or sets the logged user.
		/// </summary>
		/// <value>The logged user.</value>
		public string LoggedUser {
			get {
				return loggedUser;
			}
			set {
				loggedUser = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ZgenMobil.HttpRestController"/> user logged.
		/// </summary>
		/// <value><c>true</c> if user logged; otherwise, <c>false</c>.</value>
		public bool UserLogged {
			get {
				return userLogged;
			}
			set {
				userLogged = value;
			}
		}

		/// <summary>
		/// Singleton of HttpRestController
		/// </summary>
		/// <value>The instance.</value>
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

		/// <summary>
		/// Constructor
		/// </summary>
		private HttpRestController ()
		{
		}

		/// <summary>
		/// Baut den Request des Webservices auf
		/// </summary>
		/// <returns>The rest URL.</returns>
		/// <param name="select_service">Select_service.</param>
		/// <param name="login_data">Login_data.</param>
		public string buildRestUrl(string select_service, string login_data)
		{
			if(userLogged == false)
			{
				Console.WriteLine("login case IS null");
				loggedUser = login_data;
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

