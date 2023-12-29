using System;
using System.Xml;
using System.Xml.Xsl;

class Program
{
    static void Main()
    {
        try
        {
            // Input XML file and XSLT file paths
            string inputXmlFilePath = "G:\\RND\\XML-to-XSLT transformer\\xml-xslt\\Commissioning_001000785839_361223_20231213054950750.biztemp";
            string xsltFilePath = "G:\\RND\\XML-to-XSLT transformer\\xml-xslt\\CommissionFile.xml"; // Replace with the actual path

            // Output file path
            string outputXmlFilePath = "G:\\RND\\XML-to-XSLT transformer\\xml-xslt\\outputs\\output.xml"; // Replace with the desired output path

            // Load the XSLT transform
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);
            XmlDocument original = new XmlDocument();
            // Create an XmlReader for the input XML file
            using (XmlReader reader = XmlReader.Create(inputXmlFilePath))
            {
                // Create an XmlWriter for the transformed output
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    "
                };

                using (XmlWriter writer = XmlWriter.Create(outputXmlFilePath, settings))
                {
                    // Apply the XSLT transformation
                    xslt.Transform(reader, writer);

                    Console.WriteLine($"Transformation complete. Output written to: {outputXmlFilePath}");
                }
                original.LoadXml(File.ReadAllText(outputXmlFilePath));
                var originalXmlFileNodes = original.DocumentElement?.SelectNodes("//*")?.Cast<XmlNode>()?.Select(e => e.LocalName)?.Distinct()?.ToList();

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
