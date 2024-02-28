﻿using System;

namespace Depra.Recovery
{
	public interface IRollback
	{
		bool Disposed { get; }

		void Defer(Action action);

		void RemoveDeferred(Action action);
	}
}