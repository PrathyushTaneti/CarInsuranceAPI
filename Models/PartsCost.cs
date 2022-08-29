using System;
using System.Collections.Generic;

namespace BeenFieldAPI.Models
{
    public partial class PartsCost
    {
        public string? BodyPart { get; set; }
        public double? Alto800 { get; set; }
        public double? Alto800Std { get; set; }
        public double? Alto800Lxi { get; set; }
        public double? Alto800Vxi { get; set; }
        public double? AltoK10 { get; set; }
        public double? AltoK10lx { get; set; }
        public double? AltoK10lxi { get; set; }
        public double? AltoK10vxi { get; set; }
        public double? AltoK10vsi { get; set; }
        public double? Swift { get; set; }
        public double? SwiftLxi { get; set; }
        public double? SwiftVxi { get; set; }
        public double? SwiftZxi { get; set; }
        public double? SwiftDzire { get; set; }
        public double? SwiftDzireLxi { get; set; }
        public double? SwiftDzireVxi { get; set; }
        public double? SwiftDzireZxi { get; set; }
        public double? WagonR { get; set; }
        public double? WagonRlxi { get; set; }
        public double? WagonRvxi { get; set; }
        public double? WagonRzxi { get; set; }
        public int Id { get; set; }
        public string? VehicleVariantCode { get; set; }
        public int? Cost { get; set; }
    }
}
