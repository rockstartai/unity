using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace W2D5.Microservices
{
	/// <summary>
	/// This expects the user is already logged in. Use <see cref="W2D4AuthUI"/> for that
	/// </summary>
	public class W2D5FirebaseDBUI : MonoBehaviour
	{
		[SerializeField] List<Toggle> _userItemsToggles;
		[SerializeField] Button _submitButton;

		FirebaseDatabase _db;


		void Start()
		{
			InitFirebase();
			_submitButton.onClick.AddListener(OnSubmitClicked);
		}

		void InitFirebase()
		{
			FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(OnFirebaseInitResult);
		}

		void OnFirebaseInitResult(Task<DependencyStatus> task)
		{
			if (task.Exception == null)
			{
				Debug.Log("Firebase inited");
				InitFirebaseDB();
			}
			else
			{
				Debug.LogError("Firebase init failed: " + task.Exception);
			}
		}

		void InitFirebaseDB()
		{
			_db = FirebaseDatabase.DefaultInstance;
			Debug.Log("Firebase DB inited");
		}

		void OnSubmitClicked()
		{
			var auth = FirebaseAuth.DefaultInstance;
			if (auth.CurrentUser == null)
			{
				Debug.LogError("Log in first");
				return;
			}

			Debug.Log("Submitting data to db..");
			SubmitItems(auth.CurrentUser.UserId);
		}

		void SubmitItems(string userId)
		{
			_submitButton.interactable = false;  // both for preventing double click and for feedback

			var enabledToggles = _userItemsToggles.FindAll(t => t.isOn);
			var itemsCollected = enabledToggles.ConvertAll(t => t.GetComponentInChildren<Text>().text);

			// Use a dictionary to accumulate all user data
			var userData = new Dictionary<string, object>
			{
				{ "name", "Just a name" },
				{ "lastUpdate", DateTime.UtcNow.ToString("o") },  // Using a sortable date format
				{ "items", itemsCollected }
			};

			// Create a node in our database JSON graph with the id <userId> if it doesn't already exist
			var userRef = _db.GetReference("users").Child(userId);

			userRef.UpdateChildrenAsync(userData)
				.ContinueWithOnMainThread(OnSaveResult);
		}

		void OnSaveResult(Task task)
		{
			_submitButton.interactable = true;  // clicking available again

			if (task.IsCompleted)
			{
				Debug.Log("Data saved");
			}
			else if (task.IsFaulted)
			{
				Debug.LogError("Error saving data to Firebase: " + task.Exception);
			}
			else
			{
				Debug.LogError("Save canceled without error: " + task.Status);
			}
		}
	}
}
