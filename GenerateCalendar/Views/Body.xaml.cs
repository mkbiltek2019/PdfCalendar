﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenerateCalendar.Views
{
    /// <summary>
    /// Interaction logic for Body.xaml
    /// </summary>
    public partial class Body : UserControl
    {
        public Body()
        {
            InitializeComponent();
            SetupViewModels();
            SetupCallbacks();
        }

        private void SetupViewModels()
        {
            vms.vmYear = viewYear.DataContext as ViewModels.vmYear;
            vms.vmOptions = viewOptions.DataContext as ViewModels.vmOptions;
            vms.vmBirthdays = viewBirthDays.DataContext as ViewModels.vmBirthdays;
            vms.vmEvents = viewEvents.DataContext as ViewModels.vmEvents;
            vms.vmRiddles = viewRiddles.DataContext as ViewModels.vmRiddles;
            vms.vmSelectableRiddles = viewSelectableRiddles.DataContext as ViewModels.vmSelectableRiddles;
            vms.vmCitations = viewCitations.DataContext as ViewModels.vmCitations;
            vms.vmPdfFile = viewPdfFile.DataContext as ViewModels.vmPdfFile;
            vms.vmPageSpacing = viewPageSpacings.DataContext as ViewModels.vmPageSpacing;
        }

        private void SetupCallbacks()
        {
            vms.vmBirthdays.Callbacks();
            vms.vmEvents.Callbacks();
        }
    }
}
