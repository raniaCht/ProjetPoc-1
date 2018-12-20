using IRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Serveur
{
    class Serveur
    {
        static void Main(string[] args)
        {
               try
               {
                   TcpChannel cnl = new TcpChannel(1234);
                   ChannelServices.RegisterChannel(cnl, false);
                   RemotingConfiguration.RegisterWellKnownServiceType(typeof(ImplBibliothecaire), "obj", WellKnownObjectMode.Singleton);
                   Console.WriteLine("serveur demarrer");
                   Console.ReadLine();
               } catch(Exception e)
               {
                   Console.WriteLine("erreur : " + e);
                   Console.ReadLine();
               }
               

        }
        
    }

}

