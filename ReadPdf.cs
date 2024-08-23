using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Drawing.Imaging;
using Aspose.BarCode.BarCodeRecognition;
using iText.Layout;
using iText.Layout.Element;

namespace ReadPdfInDotNet
{
    public partial class ReadPdf : Form
    {
        public ReadPdf()
        {
            InitializeComponent();
        }

        private void ReadPdf_Load(object sender, EventArgs e)
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                Trace.WriteLine(openFileDialog1);
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
                //label3.Text = ReadPdfFile(file);
                  FindAndReadBarCodeFromPDF(file);
                //label3.Text += "BarCode results: "  + FindAndReadBarCodeFromPDF(file);
                //MessageBox.Show();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Label is clicked");
        }
        public string ReadPdfFile(object Filename)
        {
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader((string)Filename);
            string strText = string.Empty;

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                iTextSharp.text.pdf.PdfReader reader1 = new iTextSharp.text.pdf.PdfReader((string)Filename);
                String s = PdfTextExtractor.GetTextFromPage(reader1, page, its);

                s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                strText = strText + s;
                reader.Close();
            }
            return strText;
        }
        public string FindAndReadBarCodeFromPDF(string sFileName)
        {
          
            // This code example demonstrates how to read a barcode from a PDF document using ImagePlacementAbsorber.
            // The path to the document
            var barcodeResults = "";
            string file = sFileName;

            // Load a PDF document
            Aspose.Pdf.Document pdfDoc = new Aspose.Pdf.Document(file);

            // Initialize ImagePlacementAbsorber
            Aspose.Pdf.ImagePlacementAbsorber imagePlacementAbsorber = new Aspose.Pdf.ImagePlacementAbsorber();

            // Process all PDF pages in the document starting from page 1
            for (int i = 1; i <= pdfDoc.Pages.Count; ++i)
            {
                // Visit the page create an image extractor
                imagePlacementAbsorber.Visit(pdfDoc.Pages[i]);

                // Extract all images from the PDF page
                foreach (Aspose.Pdf.ImagePlacement imagePlacement in imagePlacementAbsorber.ImagePlacements)
                {
                    // Convert an image from the PDF page to the stream
                    MemoryStream ms = new MemoryStream();
                    imagePlacement.Save(ms, ImageFormat.Png);
                    ms.Position = 0;

                    // Recognize barcode from extracted image of the page
                    BarCodeReader reader = new BarCodeReader(ms);

                    // Show results
                    foreach (BarCodeResult result in reader.ReadBarCodes())
                    {
                        Trace.WriteLine("Codetext found: " + result.CodeText);
                        Trace.WriteLine("Symbology: " + result.CodeType);
                        Trace.WriteLine("-------------------------------");
                        barcodeResults = result.ToString();
                        label3.Text = barcodeResults;
                        // write pdf file for each page
                        string FName = "";
                        string[] textsplited = sFileName.Split("\\");
                        FName = textsplited[textsplited.Length - 1];
                        string dir = "D:\\Workplace\\.Net\\ReadPdfInDotNet\\BarCodedReadedFilesPdf\\";
                        // If directory does not exist, create it
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        var BarCodedpath = dir + "BarcodePage-" + i + "-" + FName;
                        WritePdfFile(BarCodedpath, barcodeResults);
                    }
                }
            }
            // rename orignal file
            renameFile(sFileName);
            return barcodeResults;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void WritePdfFile(string path, string data)
        {
            string pdfPath = path;
            using (iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(pdfPath))
            {
                using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    document.Add(new Paragraph(data));
                    document.Close();
                }
            }

            Console.WriteLine("PDF generated successfully using iText 7.");
        }

        public void renameFile(string sFileName)
        {
            string FileName = "";
            string newPath = "";
            string[] textSplit = sFileName.Split("\\");
            FileName = textSplit[textSplit.Length - 1];
            newPath = "processed-" + DateTime.Now.ToString("MM-dd-yyy hh-mm-ss-tt") + "-" + FileName;
            var oldPath = sFileName;
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(oldPath, newPath.ToString());
        }
    }
}
