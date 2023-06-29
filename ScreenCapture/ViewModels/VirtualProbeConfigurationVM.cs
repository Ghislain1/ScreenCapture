// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ScreenCapture.ViewModels
{
    using Figma.ViewModels;
    using MaterialDesignThemes.Wpf;
    using ScreenCapture.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class VirtualProbeConfigurationVM: ViewModelBase
    {
        private string name;
        private ushort? channel;
        private ushort? timeSlot;
        private ushort signalChain;
        private ushort? driver;
        private ushort? receiver;
        private ushort ? virtualProbeId;

        private VirtualProbeConfiguration virtualProbeConfigurationModel;
        private VpConfigurationAssignment AssignmentModel => this.virtualProbeConfigurationModel.ConfigurationAssignment;
        public VirtualProbeConfigurationVM(VirtualProbeConfiguration virtualProbeConfigurationModel)
        {
            this.virtualProbeConfigurationModel = virtualProbeConfigurationModel;
            this.name = this.virtualProbeConfigurationModel.Name;
            this.Id = this.virtualProbeConfigurationModel.OriginId;
            this.virtualProbeId = (ushort?)(this.Id.VirtualProbeId);
            this.channel = (ushort?) (this.AssignmentModel.Channel + addedValue);
            this.timeSlot =(ushort?) (this.AssignmentModel.TimeSlot + addedValue);
            this.signalChain = this.AssignmentModel.SignalChain;
            this.driver = (ushort?)(this.AssignmentModel.Driver + addedValue);
            this.receiver = (ushort?) (this.AssignmentModel.Receiver + addedValue);
        }
        ushort addedValue = 1;

        public OriginId Id { get; }

       public ushort? VirtualProbeId    
       {
            get => this.virtualProbeId;
            private set => this.SetProperty(ref this.virtualProbeId, value);
       }
       public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }
        public ushort? Channel
        {
            get => (ushort?)(this.channel == ushort.MinValue ? null:  this.channel + addedValue);
            set
            {
                this.SetProperty(ref this.channel, value);
                this.AssignmentModel.Channel = value - addedValue > ushort.MinValue ? (ushort)(value - this.addedValue) : ushort.MinValue;
                this.virtualProbeConfigurationModel.UpdateParameters();
                this.VirtualProbeId = this.virtualProbeConfigurationModel.OriginId.VirtualProbeId;
            }
        }
        public ushort? TimeSlot
        {
            get => this.timeSlot;
            set => this.SetProperty(ref this.timeSlot, value);
        }
        public ushort SignalChain
        {
            get => this.signalChain;
            set => this.SetProperty(ref this.signalChain, value);
        }
        public ushort? Driver
        {
            get => this.driver;
            set => this.SetProperty(ref this.driver, value);
        }
        public ushort? Receiver
        {
            get => this.receiver;
            set => this.SetProperty(ref this.receiver, value);
        }
     



    }
}
