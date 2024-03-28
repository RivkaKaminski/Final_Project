using System;
using System.Collections.Generic;

namespace HealthFundCoronaSystemServer.Models2
{
    public partial class DailyActivatePatient
    {
        public DateTime Date { get; set; }
        public int? ActivePatientCount { get; set; }
    }
}
