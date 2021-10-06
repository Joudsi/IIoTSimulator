// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace cocoApp
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField txtName { get; set; }

		[Outlet]
		AppKit.NSScrollView txtScrollData { get; set; }

		[Outlet]
		AppKit.NSTextField txtTemperatureData { get; set; }

		[Outlet]
		AppKit.NSTextField txtType { get; set; }

		[Outlet]
		AppKit.NSTextField txtUnit { get; set; }

		[Action ("btnShowData_Click:")]
		partial void btnShowData_Click (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txtScrollData != null) {
				txtScrollData.Dispose ();
				txtScrollData = null;
			}

			if (txtTemperatureData != null) {
				txtTemperatureData.Dispose ();
				txtTemperatureData = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (txtType != null) {
				txtType.Dispose ();
				txtType = null;
			}

			if (txtUnit != null) {
				txtUnit.Dispose ();
				txtUnit = null;
			}
		}
	}
}
