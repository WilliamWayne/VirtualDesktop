using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using WindowsDesktop.Interop;

namespace WindowsDesktop
{
	/// <summary>
	/// Encapsulates a virtual desktop on Windows 10.
	/// </summary>
	[DebuggerDisplay("{Id}")]
	public partial class VirtualDesktop
	{
		/// <summary>
		/// Gets the unique identifier for the virtual desktop.
		/// </summary>
		public Guid Id { get; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IVirtualDesktop ComObject => ComObjects.GetVirtualDesktop(this.Id);

		private VirtualDesktop(IVirtualDesktop comObject)
		{
			ComObjects.Register(comObject);
			this.Id = comObject.GetID();
		}
	}
}
