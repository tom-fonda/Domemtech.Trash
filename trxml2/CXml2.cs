namespace Trash
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Xsl;

    public class CXml2
    {
        public string Help()
        {
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("trxml2.readme.md"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public void Execute(Config config)
        {
            if (config.Files == null || ! config.Files.Any())
            {
                Process();
            }
            else
            {
                foreach (var arg in config.Files)
                {
                    Process(arg);
                }
            }
        }

        private static void Process()
        {
            try
            {
                XDocument oldDocument = XDocument.Load(System.Console.In);
                Process(oldDocument);
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine("Error in file " + e.ToString());
            }
        }

        private static void Process(string file_name)
        {
            try
            {
                XDocument oldDocument = XDocument.Load(file_name);
                Process(oldDocument);
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine("Error in file " + e.ToString());
            }
        }

        private static void Process(XDocument oldDocument)
        {
            string xslt = @"<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">

<xsl:output method=""text"" indent=""no"" />

<xsl:template match=""*[not(*)]"">
    <xsl:for-each select=""ancestor-or-self::*"">
        <xsl:value-of select=""concat('/', name())""/>
    </xsl:for-each>
    <xsl:text>=</xsl:text>
    <xsl:value-of select="".""/>
    <xsl:text>&#xA;</xsl:text>
    <xsl:apply-templates select=""*""/>
</xsl:template>

<xsl:template match=""*"">
    <xsl:apply-templates select=""*""/>
</xsl:template>

</xsl:stylesheet>";
            var newDocument = new XDocument();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Encoding = Encoding.Unicode;
            settings.ConformanceLevel = ConformanceLevel.Auto;
            MemoryStream strm = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(strm, settings);
            var stringReader = new StringReader(xslt);
            XmlReader xsltReader = XmlReader.Create(stringReader);
            var transformer = new XslCompiledTransform();
            transformer.Load(xsltReader);
            XmlReader oldDocumentReader = oldDocument.CreateReader();
            transformer.Transform(oldDocumentReader, writer);
            writer.Flush();
            writer.Close();
            var result = Encoding.Unicode.GetString(strm.ToArray()).Substring(1);
            Console.WriteLine(result);
        }
    }
}
