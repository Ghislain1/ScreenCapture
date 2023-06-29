// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ScreenCapture.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VpConfigurationAssignment
    {
        public ushort Channel { get; set; }
        public ushort TimeSlot { get; set; }
        public ushort SignalChain { get; set; }
        public ushort Driver { get; set; }
        public ushort Receiver { get; set; }
      
        public VpConfigurationAssignment()
        {
            
        }
    }
}
