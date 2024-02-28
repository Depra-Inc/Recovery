using System;

namespace Depra.Recovery.Exceptions
{
	internal sealed class ActionWasNotDeferred : Exception
	{
		public ActionWasNotDeferred() : base("Trying to remove action which wasn't deferred") { }
	}
}