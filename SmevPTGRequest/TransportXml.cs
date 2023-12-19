using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmevPTGRequest
{
    internal class TransportXml
    {
        private string UprmesTemplate { get; set; }

        public TransportXml() 
        {
            using (StreamReader reader = new StreamReader(@"D:\SMEV\SmevPTG\TransportTemplate.xml", Encoding.UTF8))
            {
                UprmesTemplate = reader.ReadToEnd();
            }
        }

        public void CreateMessage(string guidMessage, string xmlMessage, string filePath)
        {
            string result = UprmesTemplate.Replace(@"{{guidMessage}}", guidMessage)
                                                .Replace(@"{{xmlMessage}}", xmlMessage);

            Encoding utf8WithoutBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            using (StreamWriter file = new StreamWriter(filePath, false, utf8WithoutBom))
            {
                file.Write(result);
            }
        }

    }
}
