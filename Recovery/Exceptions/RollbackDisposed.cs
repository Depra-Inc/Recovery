using System;

namespace Depra.Recovery.Exceptions
{
	internal sealed class RollbackDisposed : Exception
	{
		public RollbackDisposed() : base("This rollback is disposed!") { }
	}
}