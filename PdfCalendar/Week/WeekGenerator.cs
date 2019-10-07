﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfCalendar.Week
{
    partial class WeekGenerator : Generator
    {
        internal Data Data { get; set; }
        internal PdfPTable Table { get; set; }
        internal int Number { get; set; }
        internal IEnumerable<DateTime> Dates;

        const float WeekNumberSize = 20;
        const float WeekNumberHeight = 40;
        const float CellBodySize = 20;
        const float CellBodyHeight = 40;
        const float CellFooterSize = 8;
        const float CellFooterHeight = 12;

        public override void Generate()
        {
            /*
             Parts of a week in the calendar.
              ________ _____________________________________________________________________
             |        |                                                                     |
             |        |                                                                     | Header
             |        |_____________________________________________________________________|
             |  Week  |         |         |         |         |         |         |         |
             | number |    1    |    2    |    3    |    4    |    5    |    6    |    7    | Body
             |        |_________|_________|_________|_________|_________|_________|_________|
             |        |         |         |         |         |         |         |         |
             |        | Event#1 |         | Event#2 |         |         |         |         | Footer
             |________|_________|_________|_________|_________|_________|_________|_________|
            */

            WeekNumber();
            Header();
            Body();
            Footer();
        }

        private void WeekNumber()
        {
            // The cell containing the week must span over the week's header, body and footer sections.
            // The week's header, body and foot are each separate rows in the table.
            // Therefore the week cell must span over 1, 2 or 3 rows.
            // Adjust the rowspan according to how many rows the week spans over.
            var rowSpan = 2;
            AddCellToTable(Number.ToString(), BaseColor.BLACK, WeekNumberSize, WeekNumberHeight, rowSpan);
        }

        private void AddCellToTable(string text, BaseColor color, float size, float height, int rowSpan = 1, IPdfPCellEvent cellEvent = null)
        {
            var font = new Font
            (
                BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, false),
                size,
                Font.NORMAL,
                color
            );

            var cell = new PdfPCell
            {
                Phrase = new Phrase(text, font),
                FixedHeight = height,
                HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                Rowspan = rowSpan,
                BackgroundColor = BaseColor.WHITE,
                CellEvent = cellEvent
            };
            Table.AddCell(cell);
        }
    }
}