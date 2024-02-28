// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;

namespace Depra.Recovery.Exceptions
{
	internal sealed class ActionWasNotDeferred : Exception
	{
		public ActionWasNotDeferred() : base("Trying to remove action which wasn't deferred") { }
	}
}