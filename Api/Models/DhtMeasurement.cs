using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class DhtMeasurement
    {
        public string DeviceId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public string Placement { get; set; }
        public bool Status { get; set; }
    }
}
