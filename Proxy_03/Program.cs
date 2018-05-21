using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy_03
{
    class ProxyContainer
    {
        private class ComplexProtectedExpensiveResource
        {
            internal void DoWork()
            {
                Console.WriteLine("Hard work is now doing ....");
                Thread.Sleep(10000);
            }
        }

        public class SimpleProxy
        {
            ComplexProtectedExpensiveResource _complexProtectedResource;
            private string _password;

            public SimpleProxy(string password)
            {
                _password = password;
            }

            public void DoWork()
            {
                if (Authenticate())
                {
                    _complexProtectedResource.DoWork();
                }
                else
                {
                    Console.WriteLine("fake work is done");

                }

            }

            bool Authenticate()
            {
                if (_password == "password")
                {

                    if (_complexProtectedResource == null)
                    {
                        _complexProtectedResource = new ComplexProtectedExpensiveResource();
                    }
                    return true;
                }
                return false;
            }
        }
    }
    class Program : ProxyContainer
    {
        static void Main(string[] args)
        {
            var simpleProxy = new SimpleProxy("passwrd");
            simpleProxy.DoWork();
        }
    }
}
