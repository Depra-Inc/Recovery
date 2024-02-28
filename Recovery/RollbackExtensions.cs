// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Recovery.Exceptions;

namespace Depra.Recovery
{
	public static class RollbackExtensions
	{
		/// <summary>
		/// Opens a child rollback which will be disposed with current one. Allows cascade disposals
		/// </summary>
		/// <returns></returns>
		public static Rollback OpenRollback(this IRollback parentRollback)
		{
			Guard.Against(parentRollback.Disposed, () => new RollbackDisposed());

			var result = new Rollback();
			parentRollback.Defer(DisposeChild);
			result.Defer(CancelDisposingChild);
			return result;

			void DisposeChild() => result.Dispose();

			void CancelDisposingChild() => parentRollback.RemoveDeferred(DisposeChild);
		}
	}
}