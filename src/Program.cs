
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using xunit_xml2html.Properties;

internal class Program
{

    static void Main(string[] args)
    {
        bool flag = args == null || args.Length == 0 || args[0] == "-h" || args[0] == "-help";
        if (flag)
        {
            Console.WriteLine("xunit xml to html tool");
            Console.WriteLine("github: https://github.com/codeex/xunit-xml2html.git");
            Console.WriteLine("input param: xunit v2 format xml file path");
        }
        try
        {
            Assembly assem = typeof(Program).Assembly;
            string xslt = Resources.HTML;
            string xmlPath = args[0];
            string xml = File.ReadAllText(xmlPath, Encoding.UTF8);
            string html = TransformXMLToHTML(xml, xslt);
            FileInfo fi = new FileInfo(xmlPath);
            string output = Path.Combine(fi.DirectoryName, fi.Name + ".html");
            bool flag2 = File.Exists(output);
            if (flag2)
            {
                File.Delete(output);
            }
            File.WriteAllText(output, html, Encoding.UTF8);
            Console.WriteLine("Output html file: " + output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("parse xml file error:" + ex.Message);
        }
    }

    static string TransformXMLToHTML(string inputXml, string xsltString)
    {
        XslCompiledTransform transform = new XslCompiledTransform();
        using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
        {
            transform.Load(reader);
        }
        StringWriter results = new StringWriter();
        using (XmlReader reader2 = XmlReader.Create(new StringReader(inputXml)))
        {
            transform.Transform(reader2, null, results);
        }
        return results.ToString();
    }

}