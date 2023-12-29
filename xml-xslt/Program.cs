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
            string inputXmlFilePath = "path/to/your/input.xml";
            string xsltFilePath = "path/to/your/remove_namespaces.xslt"; // Replace with the actual path

            // Output file path
            string outputXmlFilePath = "path/to/your/output.xml"; // Replace with the desired output path

            // Load the XSLT transform
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltFilePath);

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
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
