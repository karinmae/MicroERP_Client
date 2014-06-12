using iTextSharp.text;
using iTextSharp.text.pdf;
using MicroErp;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroERP.ipdf
{
    class PrintPDF
    {
        public void openPDF()
        {
            Process.Start("C:\\Temp\\Test.pdf");
        }
        
        public Document doc { get; set; }
        private float sumNetto;
        private float sumBrutto;
        private float sumUSt20;
        private float sumUSt10;
        public PrintPDF(Invoice bill)
        {

            //Invoice bill;
            //liste.Invoice.
            float netto1, netto2, netto3;
            float brutto1, brutto2, brutto3;

            doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("C:\\Temp\\Test.pdf", FileMode.Create));
            
            writer.SetFullCompression();
            writer.CloseStream = true;

            doc.Open();
            doc.NewPage();

            PdfContentByte cb = writer.DirectContent;
            cb.BeginText();
            BaseFont font_Fett = BaseFont.CreateFont("c:\\windows\\fonts\\HARNGTON.TTF", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            BaseFont font_calibri = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(font_Fett, 24);

            cb.SetTextMatrix(0, 0);
            cb.SetColorFill(new BaseColor(252, 26, 180));

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MicoERP", 50, 800, 0);
            cb.EndText();
            cb.SetLineWidth(1);
            cb.MoveTo(50, 790);
            cb.LineTo(550, 790);
            cb.Stroke();

            cb.BeginText();
            cb.SetFontAndSize(font_calibri, 12);
            cb.SetTextMatrix(50, 740);
            cb.SetColorFill(new BaseColor(0, 0, 0));
            cb.ShowText("MicroERP");
            cb.SetTextMatrix(50, 725);
            cb.ShowText("Stenersgata 10 ");
            cb.SetTextMatrix(50, 710);
            cb.ShowText("0184 Oslo");
            cb.SetFontAndSize(font_Fett, 16);
            cb.SetTextMatrix(50, 600);
            cb.ShowText("Rechnung Nr. " + bill.Faelligkeit.ToString()); 
            cb.SetFontAndSize(font_calibri, 9);
            cb.SetTextMatrix(460, 600);
            cb.ShowText("Datum:     " + bill.Datum.ToString()); 
            cb.EndText();

            Paragraph p1 = new Paragraph(" ");
            p1.SpacingAfter = 250;
            doc.Add(p1);

            DataTable filledTable = new DataTable();
            filledTable.Columns.Add("Menge");
            filledTable.Columns.Add("Artikel");
            filledTable.Columns.Add("Stückpreis");
            filledTable.Columns.Add("UST");
            filledTable.Columns.Add("Netto");
            filledTable.Columns.Add("Brutto");


 
                int menge, stk, Ust;


                DataRow row = filledTable.NewRow();
                menge = Convert.ToInt32(bill.Menge1);
                stk = Convert.ToInt32(bill.Stueckpreis1);
                netto1 = menge * stk;
                Ust = Convert.ToInt32(bill.Ust1);
                brutto1 = netto1 * ((Ust / 100) + 1);
                row["Menge"] = bill.Menge1;
                row["Artikel"] = bill.Artikel1;
                row["Stückpreis"] = bill.Stueckpreis1;
                row["UST"] = bill.Ust1;
                row["Netto"] = netto1;
                row["Brutto"] = brutto1;
                filledTable.Rows.Add(row);

                DataRow row2 = filledTable.NewRow();
                menge = Convert.ToInt32(bill.Menge2);
                stk = Convert.ToInt32(bill.Stueckpreis2);
                netto2 = menge * stk;
                Ust = Convert.ToInt32(bill.Ust2);
                brutto2 = netto2 * ((Ust / 100) + 1);
                row2["Menge"] = bill.Menge2;
                row2["Artikel"] = bill.Artikel2;
                row2["Stückpreis"] = bill.Stueckpreis2;
                row2["UST"] = bill.Ust2;
                row2["Netto"] = netto2;
                row2["Brutto"] = brutto2;
                filledTable.Rows.Add(row2);

                DataRow row3 = filledTable.NewRow();
                menge = Convert.ToInt32(bill.Menge3);
                stk = Convert.ToInt32(bill.Stueckpreis3);
                netto3 = menge * stk;
                Ust = Convert.ToInt32(bill.Ust3);
                brutto3 = netto3 * ((Ust / 100) + 1);
                row3["Menge"] = bill.Menge3;
                row3["Artikel"] = bill.Artikel3;
                row3["Stückpreis"] = bill.Stueckpreis3;
                row3["UST"] = bill.Ust3;
                row3["Netto"] = netto3;
                row3["Brutto"] = brutto3;
                filledTable.Rows.Add(row3);



            Paragraph paragraphTable = new Paragraph();
            paragraphTable.SpacingAfter = 10;
            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 90;

            foreach (DataColumn col in filledTable.Columns)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Phrase = new Phrase(col.ColumnName, new Font(font_calibri, 12, Font.BOLD));
                table.AddCell(cell);
            }
            foreach (DataRow Rows in filledTable.Rows)
            {
                foreach (DataColumn col in filledTable.Columns)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.Phrase = new Phrase(Rows[col.ColumnName].ToString(), new Font(font_calibri, 11, Font.NORMAL));
                    table.AddCell(cell);
                }
            }
            paragraphTable.Add(table);
            doc.Add(paragraphTable);

            Paragraph paragraphPricing = new Paragraph();
            PdfPTable pricing = new PdfPTable(2);
            pricing.WidthPercentage = 90;
            pricing.SetWidths(new float[] { 80, (float)13.3 });
            pricing.SpacingAfter = 40;


            //var pricingList = new List<KeyValuePair<string, float>>();
            //pricingList.Add(new KeyValuePair<string, float>("Gesamt Netto:", sumNetto));
            //if (USt20)
            //{
            //    pricingList.Add(new KeyValuePair<string, float>("20% USt:", sumUSt20)); // Werte einfügen
            //}
            //if (USt10)
            //{
            //    pricingList.Add(new KeyValuePair<string, float>("10% USt:", sumUSt10));
            //}
            //pricingList.Add(new KeyValuePair<string, float>("Gesamt Brutto:", sumBrutto));

            //foreach (KeyValuePair<string, float> pair in pricingList)
            //{
            //    PdfPCell cell1 = new PdfPCell();
            //    PdfPCell cell2 = new PdfPCell();
            //    cell1.HorizontalAlignment = Element.ALIGN_RIGHT;
            //    cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
            //    cell1.Border = Rectangle.NO_BORDER;
            //    cell2.Border = Rectangle.NO_BORDER;


            //    if (pair.Key == "Gesamt Brutto:")
            //    {
            //        cell1.Phrase = new Phrase(pair.Key, new Font(font_calibri, 11, Font.BOLD));
            //    }
            //    else
            //    {
            //        cell1.Phrase = new Phrase(pair.Key, new Font(font_calibri, 11, Font.NORMAL));
            //    }
            //    cell2.Phrase = new Phrase(pair.Value.ToString() + "€", new Font(font_calibri, 11, Font.NORMAL));
            //    pricing.AddCell(cell1);
            //    pricing.AddCell(cell2);
            //}

            paragraphPricing.Add(pricing);
            doc.Add(paragraphPricing);

            // hier message einfügen
            Paragraph message = new Paragraph(bill.Nachricht, new Font(font_calibri, 11, Font.NORMAL));
            message.SpacingAfter = 50;
            message.IndentationLeft = 25;
            message.IndentationRight = 25;
            doc.Add(message);
            Paragraph greetings = new Paragraph("Vielen Dank im Voraus!", new Font(font_calibri, 11, Font.NORMAL));
            greetings.IndentationLeft = 25;
            doc.Add(greetings);


            if (doc != null)
            {
                doc.Close();
            }
            doc = null;
        }
    }
}
