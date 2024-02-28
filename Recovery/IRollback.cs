// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;

namespace Depra.Recovery
{
	public interface IRollback
	{
		bool Disposed { get; }

		void Defer(Action action);

		void RemoveDeferred(Action action);
	}
}