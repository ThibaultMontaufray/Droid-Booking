using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid_Booking
{
    public static class Print
    {
        public static void PrintPanel(Panel panel)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrintDialog = new PrintDialog();
            System.Drawing.Bitmap memoryImage = new System.Drawing.Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(memoryImage, panel.ClientRectangle);
            if (myPrintDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Printing.PrinterSettings values;
                values = myPrintDialog.PrinterSettings;
                myPrintDialog.Document = doc;
                doc.PrintController = new StandardPrintController();
                doc.Print();
            }
            doc.Dispose();
        }
    }
}
