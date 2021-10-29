using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceMtk_P1_20190140104;

using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServerCodeMtk_P2_20190140104
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8888/Matematika");
            BasicHttpBinding bind = new BasicHttpBinding();

            try
            {
                hostObj = new ServiceHost(typeof(Matematika), address); //Alamat Base address
                hostObj.AddServiceEndpoint(typeof(IMatematika), bind, ""); //Alamat ENDPoint

                //wsld
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl(dibuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);

                //mex
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex");

                hostObj.Open();
                Console.WriteLine("Server telah SIAPP....!!!");
                Console.ReadLine();
                hostObj.Close();

            }
            catch(Exception e)
            {
                hostObj = null;
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}
