using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Threading;

namespace monoDevelop
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new Thread (() => {
				Form f = new Form ();
				f.Show ();
			}).Start ();

			//MessageBox.Show ("dfdj");
			Console.WriteLine ("Hello World!");
			Console.Read ();
		}
	}
}
