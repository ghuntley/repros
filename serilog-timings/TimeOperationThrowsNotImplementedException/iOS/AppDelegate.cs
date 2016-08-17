using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Serilog;
using SerilogTimings;
using UIKit;

namespace TimeOperationThrowsNotImplementedException.iOS
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
			Log.Logger = new LoggerConfiguration()
				.WriteTo.File("debug.log")
				.MinimumLevel.Verbose()
				.CreateLogger();

			using (Operation.Time("Launching application"))
			{
				LoadApplication(new App());
			}
			return base.FinishedLaunching(app, options);
		}
	}
}

