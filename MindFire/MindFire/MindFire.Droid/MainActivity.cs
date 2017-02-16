using System;

using Android.App;
using Android.Widget;
using Android.OS;
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.paas.sdk.csharp;
using Android.Support.V7.App;

namespace MindFire.Droid
{
	[Activity (Label = "MindFire.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity, ConnectionRequestListener
	{
		private WarpClient w;

		public void onConnectDone(ConnectEvent eventObj)
		{
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
			{
				StartActivity(typeof(MenuActitvity));
				this.Finish();
			}
			else
			{ 
				RunOnUiThread(() => Toast.MakeText(this, "Connection error " + eventObj.getResult(), ToastLength.Long).Show());
			}
		}

		public void onDisconnectDone(ConnectEvent eventObj)
		{
			
		}

		public void onInitUDPDone(byte resultCode)
		{
			throw new NotImplementedException();
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			WarpClient.initialize(Constants.apiKey, Constants.secretKey);
			App42API.Initialize(Constants.apiKey, Constants.secretKey);

			w = WarpClient.GetInstance();
			w.AddConnectionRequestListener(this);

			Button button = FindViewById<Button>(Resource.Id.myButton);
			EditText et = FindViewById<EditText>(Resource.Id.editText1);

			button.Click += delegate
			{
				w.Connect(et.Text);
			};

		}

	}
}


