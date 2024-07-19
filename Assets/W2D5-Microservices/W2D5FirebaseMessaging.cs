using Firebase;
using Firebase.Messaging;
using System.Linq;
using TMPro;
using UnityEngine;

namespace W2D5.Microservices
{
	public class W2D5FirebaseMessaging : MonoBehaviour
	{
		[SerializeField] TMP_InputField _tokenText;
		[SerializeField] TMP_InputField _messageText;


		void Start()
		{
			FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
			{
				var dependencyStatus = task.Result;
				if (dependencyStatus == DependencyStatus.Available)
				{
					// Firebase is ready for use
					FirebaseMessaging.TokenReceived += OnNewTokenReceived;
					FirebaseMessaging.MessageReceived += OnMessageReceived;
					FirebaseMessaging.GetTokenAsync().ContinueWith(tokenTask =>
					{
						OnHandleToken(tokenTask.Result);
					});
				}
				else
				{
					Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
				}
			});
		}

		// Note this is only received the first time the app is open (or after the user clears the
		// storage)
		void OnNewTokenReceived(object sender, TokenReceivedEventArgs token)
		{
			OnHandleToken(token.Token);
		}

		void OnHandleToken(string token)
		{
			Debug.Log($"Received FCM Token: {token}");
			_tokenText.text = token;
		}

		// Called when a push notification comes in and the app is active (foreground)
		// In other words, if your app is in the background or closed, this is NOT called, even if you
		// open the app afterwards
		void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
		{
			Debug.Log($"Received a new message: {e.Message}");
			var notif = e.Message.Notification;
			if (notif == null)
			{
				_messageText.text = 
					$"Non-notification: {System.Text.Encoding.UTF8.GetString(e.Message.RawData)}";

			}
			else
			{
				_messageText.text = $"Notification: {notif.Title} - {notif.Body}";
			}
		}

		void OnDestroy()
		{
			FirebaseMessaging.MessageReceived -= OnMessageReceived;
			FirebaseMessaging.TokenReceived -= OnNewTokenReceived;
		}
	}
}
