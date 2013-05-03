using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ZgenMobil
{
	public partial class ViewEntwurf : UIViewController
	{
		public ViewEntwurf () : base ("ViewEntwurf", null)
		{
			this.Title = "Zeugnisentwurf";
		}
	
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void buildTextView(string bereitschaft, string befaehigung , string wissen, string weise, string erfolg, string zusammen)
		{
			string person = ViewZeugnisart.Instance.Globname;
			string abteilung = ViewZeugnisart.Instance.Globteil;
			string stichtag = "03. Mai 2013";

			string basic = 	
					person + ", geboren am 01.Januar 1970, trat am 01. Oktorber 2007 als Entwickler in die Abteilung " + abteilung + " unseres Unternehmens ein.\n\n" +
					"In dieser Funktion nahm " + person + " im Wesentlichen folgende Aufgaben wahr:\n\n" +
					" - Komplette Auftragsabwicklung für Kunden, Vertreter und Töchter in dem Verantwortungsbereich\n"+
					" - Ermittlung, Aufbereitung und Visualisierung von Vertriebskennzahlen auf Basis vorhandener Reportingwerkzeuge\n"+
					" - Erstellung von MS-Excel-Auswertungen für Ad-Hoc-Auswertungen\n"+
					" - Erstellen von Versand- und Zolldokumenten\n"+
					" - Export- und Versandabwicklung, Luftfracht und Seefracht Übersee\n"+
					" - Kontrolle der Kreditwürdigkeit des Kunden\n"+
					" - Schreiben der Auftragsbestätigung / Rechnung\n"+
					" - Auftragsüberwachung\n"+
					" - Kontrolle der Auftragsrückstände\n\n"+
					"Darüber hinaus war " + person + " mit folgenden Zusatzaufgaben betraut:\n\n"+
					" - Systematische Bearbeitung von Reklamationen\n"+
					" - Besuch der Fachmessen\n"
					;

			string schluss =
				"Das Ausscheiden von " + person + "erfolgt zum " + stichtag + " betriebsbedingt unter Einhaltung der Sozialauswahl.\n\n"+
				"Den Weggang von " + person + " bedauern wir sehr. Wir wünschen " + person + " im weiteren Berufs- und Lebensweg alles Gute und weiterhin viel Erfolg."
				;


			textView.Text = "";
			string nz = "\n\n";

			textView.Text += basic + nz;
			textView.Text += bereitschaft + nz;
			textView.Text += befaehigung + nz;
			textView.Text += wissen + nz;
			textView.Text += weise + nz;
			textView.Text += erfolg + nz;
			textView.Text += zusammen+ nz+"\n";
			textView.Text += schluss;
		}
	}
}

