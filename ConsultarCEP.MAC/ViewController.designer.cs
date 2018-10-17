// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ConsultarCEP.MAC
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField lbViewC { get; set; }

        [Outlet]
        AppKit.NSTextField textViewC { get; set; }

        [Action ("btnViewC:")]
        partial void btnViewC (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (textViewC != null) {
                textViewC.Dispose ();
                textViewC = null;
            }

            if (lbViewC != null) {
                lbViewC.Dispose ();
                lbViewC = null;
            }
        }
    }
}
