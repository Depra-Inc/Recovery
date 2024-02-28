// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;

namespace Depra.Recovery.Exceptions
{
	internal sealed class RollbackDisposed : Exception
	{
		public RollbackDisposed() : base("This rollback is disposed!") { }
	}
}