using System;
using System.Collections;
using System.Collections.Generic;

namespace W2D3.Exs.Tetris
{
	/// <summary>
	/// Note: for simple cases like ours, SignalBus should NOT be used. However, we're using it for
	/// educational purposes. The critical reason why you shouldn't use SignalBus in some scenarios is
	/// because you'd be tempted to rely on it even for events where there are <i>multiple</i> handlers,
	/// and most probably they have to trigger in a certain order, which will lead to very complex bugs.
	/// Best is to keep it simple and use direct interfaces where all of the listeners are known, or
	/// at least whose priority you control.
	/// 
	/// Good use cases for SignalBus: updating many UI elements on various events. For example, when
	/// health decreases, you might want to play a sound, shake the screen, decrease the user's HP --
	/// all these can happen in any order.
	/// 
	/// Bad use cases for SignalBus: managing crucial game state, and relying on multiple, independent
	/// handlers to act on your event in a specific order, that might magically work, but one day you 
	/// need to add another handler, then it stops working and you even forgot you wrote that code.
	/// </summary>
	public class TetrisSignalBus
	{
		public static TetrisSignalBus Instance { get; private set; } = new();

		readonly Dictionary<Type, List<Delegate>> _subs = new();


		public void Subscribe<TEvent>(Action<TEvent> subscriberFunction)
		{
			var type = typeof(TEvent);
			if (!_subs.TryGetValue(type, out var subsForType))
				_subs[type] = subsForType = new();

			subsForType.Add(subscriberFunction);
		}

		public void Unsubscribe<TEvent>(Action<TEvent> subscriberFunction)
		{
			var type = typeof(TEvent);
			if (_subs.TryGetValue(type, out var subsForType))
				subsForType.Remove(subscriberFunction);
		}

		public void Publish<TEvent>(TEvent ev)
		{
			var type = typeof(TEvent);
			if (_subs.TryGetValue(type, out var subsForType))
			{
				foreach (var sub in subsForType)
				{
					if (sub is Action<TEvent> action)
						action(ev);
				}
			}
		}
	}
}
