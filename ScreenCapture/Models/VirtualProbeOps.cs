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

    public class VirtualProbeOps
    {
        public static ushort CalculateVirtualProbeId(ushort channel, ushort timeSlot, ushort signalChain) => (ushort)(channel + (ushort)(signalChain << 7) + (ushort)(timeSlot << 8));

        public static ushort CalculateVirtualProbeId(VpConfigurationAssignment assignment) => CalculateVirtualProbeId(assignment.Channel, assignment.TimeSlot, assignment.SignalChain);

    }
}
