using SmevPTGRequest;
using System.Text;

TransportXml transportXml = new TransportXml();

string msg = string.Empty;

string curDir = Directory.GetCurrentDirectory();
string[] files = Directory.GetFiles(curDir, "Request.xml");
foreach (string file in files)
{
    using (StreamReader reader = new StreamReader(file, Encoding.UTF8))
    {
        msg = reader.ReadToEnd();
    }
    msg = msg.Replace(@"<?xml version=""1.0"" encoding=""UTF-8""?>", "");
    string guid = Guid.NewGuid().ToString();
    transportXml.CreateMessage(guid, msg, Path.Combine(curDir, guid + ".xml"));
}