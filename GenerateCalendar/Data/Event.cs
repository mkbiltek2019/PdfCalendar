﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PropertyChanged;
using GenerateCalendar.Misc;

namespace GenerateCalendar.Data
{
    [AddINotifyPropertyChangedInterface]
    class Event
    {
        const string Filter = "Image-files (.png, .gif, .jpg, .bmp)|*.png;*.gif;*.jpg;*.bmp";

        public DateTime Date { get; set; }
        public string Text { get; set; }
        public RelayCommand BrowseImage { get; set; }
        public FileInfo FilePath { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Event()
        {
            Date = vms.vmYear.SelectedYear;
            Text = "";
            Width = 15;
            Height = 10;
            BrowseImage = new RelayCommand();
            BrowseImage.Callback += SelectFileLocation;
        }

        private void SelectFileLocation()
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = Filter,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            FilePath = new FileInfo(dialog.FileName);
        }
    }

    class EventLite
    {
        // This class is only when serializing to JSON.
        // The actual Event is too complex for serializing.
        // The FileInfo and RelayCommand cause circle references.

        public DateTime Date { get; set; }
        public string Text { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string FilePath { get; set; }
    }
}
