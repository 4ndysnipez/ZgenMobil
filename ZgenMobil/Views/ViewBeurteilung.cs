
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	/// <summary>
	/// View beurteilung Klasse.
	/// </summary>
	public partial class ViewBeurteilung : UIViewController
	{
		/// <summary>
		/// Deklarationen
		/// </summary>
		ViewEntwurf viewEntwurf;
		string[] arbeitsbereitschaft;
		string[] arbeitsbefaehigung;
		string[] wissen;
		string[] arbeitsweise;
		string[] arbeitserfolg;
		string[] zusammenfassung;


		/// <summary>
		/// Initializes a new instance of the <see cref="ZgenMobil.ViewBeurteilung"/> class.
		/// </summary>
		public ViewBeurteilung () : base ("ViewBeurteilung", null)
		{
			this.Title = "Beurteilung";
		}

		/// <Docs>Called when the system is running low on memory.</Docs>
		/// <summary>
		/// Dids the receive memory warning.
		/// </summary>
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			propScrollView.Frame = new RectangleF(0,0,768,879);
			propScrollView.ContentSize = new SizeF(768,880);
			this.View.AddSubview(propScrollView);
		}

		/// <summary>
		/// Actions the button erstellen.
		/// </summary>
		/// <param name="sender">Sender.</param>
		partial void actionBtnErstellen (NSObject sender)
		{
			if(viewEntwurf == null)
			{
				viewEntwurf = new ViewEntwurf();
			}

			string check = checkSegments();

			if(check != "OK")
			{
				new UIAlertView("Fehler", "Bitte alle Noten ausfüllen",null,"OK",null).Show();
			}
			else{
				string selArbBereitschaft = buildArbeitsbereitschaft(segmentArbBereitschaft.SelectedSegment);
				string selArbBefaehigung = buildArbeitsbefaehigung(segmentArbBefaehigung.SelectedSegment);
				string selWissen = buildWissen(segmentWissen.SelectedSegment);
				string selArbWeise = buildArbeitsweise(segmentArbWeise.SelectedSegment);
				string selArbErfolg = buildArbeitserfolg(segmentArbErfolg.SelectedSegment);
				string selZusammenfassung = buildZusammenfassung(segmentZusammenfassung.SelectedSegment);
				
				this.NavigationController.PushViewController(viewEntwurf, true);
				viewEntwurf.buildTextView(selArbBereitschaft,selArbBefaehigung,selWissen,selArbWeise,selArbErfolg,selZusammenfassung);
			}

		}

		/// <summary>
		/// Checks the segments.
		/// </summary>
		/// <returns>The segments.</returns>
		public string checkSegments()
		{
			if(segmentArbBereitschaft.SelectedSegment < 0)
			{
				return "fehler";
			}
			else if(segmentArbBefaehigung.SelectedSegment < 0)
			{
				return "fehler";
			}
			else if(segmentWissen.SelectedSegment < 0)
			{
				return "fehler";
			}
			else if(segmentArbWeise.SelectedSegment < 0)
			{
				return "fehler";
			}
			else if(segmentArbErfolg.SelectedSegment < 0)
			{
				return "fehler";
			}
			else if(segmentZusammenfassung.SelectedSegment < 0)
			{
				return "fehler";
			}
			else{return "OK"; }
		}

		/// <summary>
		/// Builds the arbeitsbereitschaft.
		/// </summary>
		/// <returns>The arbeitsbereitschaft.</returns>
		/// <param name="item">Item.</param>
		public string buildArbeitsbereitschaft(int item)
		{
			string person = ViewZeugnisart.Instance.Globname;
			arbeitsbereitschaft = new string[5];

			arbeitsbereitschaft[0] = 	person + " zeichnete sich durch eine sehr hohe Arbeitsmoral aus. " +
										person + " hat jederzeit zusätzliche Arbeiten und Mehrarbeit übernommen.";
			arbeitsbereitschaft[1] = 	person + " zeichnete sich durch Arbeitseifer und ein hohes Pflichtbewusstsein aus.";
			arbeitsbereitschaft[2] = 	person + " war pflichtbewusst.";
			arbeitsbereitschaft[3] = 	"Die Arbeitsmoral von " + person + " äußerte sich darin, dass " + person + 
										" wiederholt auf Anforderungen bereit war, Mehrarbeit zu übernehmen.";
			arbeitsbereitschaft[4] = 	"Die Arbeitsmotivation von " + person + " war insgesamt zufrieden stellend.";

			return arbeitsbereitschaft[item];
		}

		/// <summary>
		/// Builds the arbeitsbefaehigung.
		/// </summary>
		/// <returns>The arbeitsbefaehigung.</returns>
		/// <param name="item">Item.</param>
		public string buildArbeitsbefaehigung(int item)
		{
			string person = ViewZeugnisart.Instance.Globname;
			arbeitsbefaehigung = new string[5];
			arbeitsbefaehigung[0] = 	person + " war eine sehr belastbare, besonnene und fachlich tüchtige Arbeitskraft. " +
										person + " ist ein absoluter Könner und hat laufend schwierige und umfangreiche Aufgaben übernommen.";

			arbeitsbefaehigung[1] = 	person + " war eine robuste, belastbare und sehr ausdauernde Arbeitskraft. " +
										person + " plant und denkt mit und beherrscht die Arbeit gut.";

			arbeitsbefaehigung[2] = 	person + " verfügte über eine gute Arbeitsbefähigung";

			arbeitsbefaehigung[3] = 	person + " war fähig auf Aufforderung auch einzelne andere, gleichartige Arbeitsaufgaben zu erfüllen.";

			arbeitsbefaehigung[4] = 	person + " verfügte über eine im Großen und Ganzen zufrieden stellende Arbeitsbefähigung.";

			return arbeitsbefaehigung[item];
		}

		/// <summary>
		/// Builds the wissen.
		/// </summary>
		/// <returns>The wissen.</returns>
		/// <param name="item">Item.</param>
		public string buildWissen(int item)
		{
			string person = ViewZeugnisart.Instance.Globname;
			wissen = new string[5];

			wissen[0] = 	person + " war eine aufgeschlossene und sehr visierte Arbeitskraft, die aufgrund ihrer außergewöhnlichen " +
							"Fachkenntnisse und vielseitigen Berugserfahrung mit allen Maschinen und Werkstoffen im Abreitsbereich bestens vertraut war und daher flexibel eingesetzt werden konnte.";

			wissen[1] =		person + " verfügt über eine große Berufserfahrung. Die fachlichen Kenntnisse entsprechen dem neusten technischen Stand. Daher hat " +
							person + " regelmäßig die Einweisung der Auszubildenden und wiederholt die Einarbeitung neuer Mitarbeiter übernommen. Hervorzuheben ist die Fähigkeit, sich selbstständig neues Wissen anzueignen.";

			wissen[2] = 	person + " verfügt über eine gute Berufserfahrung. Die fachlichen Kenntnisse entsprechen dem heutigen technischen Stand.";

			wissen[3] = 	person + " verfügt über Berufserfahrung.";

			wissen[4] = 	person + " verfügt über eine noch auszubauende Berufserfahrung.";

			return wissen[item];
		}

		/// <summary>
		/// Builds the arbeitsweise.
		/// </summary>
		/// <returns>The arbeitsweise.</returns>
		/// <param name="item">Item.</param>
		public string buildArbeitsweise(int item)
		{
			string person = ViewZeugnisart.Instance.Globname;
			arbeitsweise = new string[5];

			arbeitsweise[0] =	person + " arbeitete stehts zielstrebig, gründlich und zügig. " +
								person + " dachte mit und plante den Werkzeug- und Materialbedarf der verschiedenen Arbeitseinsätze sehr gut.";

			arbeitsweise[1] =	person + " arbeitete sehr gründlich und rationell. " +
								person + " dachte bei der Arbeitsvorbereitung mit und plante den Werkzeug- und Materialbedarf der verschiedenen Aufträge gut.";
			arbeitsweise[2] = 	person + " arbeitete routiniert und effizient.";
			arbeitsweise[3] = 	"Man kann " + person + " auch als gründlich bezeichnen.";
			arbeitsweise[4] = 	person + " arbeitete im Allgemeinen gründlich und zügig.";

			return arbeitsweise[item];
		}

		/// <summary>
		/// Builds the arbeitserfolg.
		/// </summary>
		/// <returns>The arbeitserfolg.</returns>
		/// <param name="item">Item.</param>
		public string buildArbeitserfolg(int item)
		{
			string person = ViewZeugnisart.Instance.Globname;
			arbeitserfolg = new string[5];
			arbeitserfolg[0] =		"Die Arbeitsergebnisse waren, auch bei wechselnden Anforderungen und in sehr schwiegrigen Fällen, stets von sehr guter Qualität.";
			arbeitserfolg[1] =		"Die Werkstücke von " + person + " waren stets von guter Qualität.";
			arbeitserfolg[2] =		"Die Arbeitsergebnisse waren von guter Qualität.";
			arbeitserfolg[3] =		"Die von " + person + " bearbeiteten Werkstücke waren zufrieden stellend.";
			arbeitserfolg[4] =		"Die von " + person + " bearbeiteten Werkstücke waren im Allgemeinen mängelfrei und entsprachen insgesamt der erforderlichen Mindesqualität.";

			return arbeitserfolg[item];
		}

		/// <summary>
		/// Builds the zusammenfassung.
		/// </summary>
		/// <returns>The zusammenfassung.</returns>
		/// <param name="item">Item.</param>
		public string buildZusammenfassung(int item)
		{
			string person = ViewZeugnisart.Instance.Globname;
			zusammenfassung = new string[5];

			zusammenfassung[0] = 	"Die übertragenen Arbeiten erledigte " + person + " stets zu unserer vollsten Zufriedenheit."; 
			zusammenfassung[1] = 	"Die übertragenen Arbeiten erledigte " + person + " stets zu unserer vollen Zufriedenheit."; 
			zusammenfassung[2] = 	"Mit der Leistung von " + person + " waren unsere Auftraggeber und wir voll zufrieden.";
			zusammenfassung[3] = 	"Mit den Arbeiten von " + person + " waren unsere Auftraggeber und wir zufrieden.";
			zusammenfassung[4] = 	"Mit den Arbeiten von " + person + " waren unsere Auftraggeber und wir zumeist zufrieden.";

			return zusammenfassung[item];
		}
	}
}

