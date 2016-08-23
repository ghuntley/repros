using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Serilog;

namespace SerilogRepro.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication(new App());

			Log.Logger = new LoggerConfiguration().WriteTo.Seq("http://google.com/").CreateLogger();

			return base.FinishedLaunching(app, options);
		}
	}
}

