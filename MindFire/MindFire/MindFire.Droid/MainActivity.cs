using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.events;

namespace MindFire.Droid
{
	[Activity (Label = "MindFire.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ConnectionRequestListener
	{
		private WarpClient w;

		public void onConnectDone(ConnectEvent eventObj)
		{
			StartActivity(typeof(MenuActitvity));
			this.Finish();
		}

		public void onDisconnectDone(ConnectEvent eventObj)
		{
			throw new NotImplementedException();
		}

		public void onInitUDPDone(byte resultCode)
		{
			throw new NotImplementedException();
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			WarpClient.initialize(Constants.apiKey, Constants.secretKey);
			w = WarpClient.GetInstance();
			w.AddConnectionRequestListener(this);

			Button button = FindViewById<Button> (Resource.Id.myButton);
			EditText et = FindViewById<EditText> (Resource.Id.editText1);

			button.Click += delegate {
				w.Connect(et.Text);
			};

		}
	}
}


