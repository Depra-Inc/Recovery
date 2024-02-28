// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using Depra.Recovery.Exceptions;

namespace Depra.Recovery
{
	/// <summary>
	/// Container to defer actions to be executed on <see cref="IDisposable.Dispose"/>
	/// (resource cleanup, cancel side effects).
	/// </summary>
	public sealed class Rollback : IRollback, IDisposable
	{
		private readonly object _sync = new();
		private Action _deferredActions;

		public bool Disposed { get; private set; }

		/// <summary>
		/// Defer action to be executed upon <see cref="IDisposable.Dispose"/>.
		/// </summary>
		public void Defer(Action action)
		{
			lock (_sync)
			{
				Guard.Against(Disposed, () => new RollbackDisposed());
				_deferredActions = action + _deferredActions;
			}
		}

		/// <summary>
		/// Remove deferred action so it won't be executed.
		/// </summary>
		public void RemoveDeferred(Action action)
		{
			lock (_sync)
			{
				Guard.Against(Disposed, () => new RollbackDisposed());
#if DEBUG
				var previousLength = _deferredActions.GetInvocationList().Length;
				_deferredActions -= action;
				if (_deferredActions.GetInvocationList().Length == previousLength)
				{
					throw new ActionWasNotDeferred();
				}
#else
				_deferredActions -= action;
#endif
			}
		}

		/// <summary>
		/// Executes deferred actions in reverse order.
		/// </summary>
		public void Dispose()
		{
			lock (_sync)
			{
				Guard.Against(Disposed, () => new RollbackDisposed());
				Disposed = true;
				_deferredActions?.Invoke();
				_deferredActions = null;
			}
		}
	}
}