using System;
using System.Collections.Generic;

namespace HealthFundCoronaSystemServer.Models1
{
    public partial class DailyActivatePatient
    {
        public DateTime Date { get; set; }
        public int? ActivePatientCount { get; set; }
    }
}
