﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

namespace GenerateCalendar.Data
{
    [AddINotifyPropertyChangedInterface]
    class Birthday
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public Birthday()
        {
            BirthDay = vms.vmYear.SelectedYear;
        }
    }
}
