using Kakao.Properties;
using System;

namespace Kakao
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddInversionModule<ViewModules>()
                .AddInversionModule<DirectModules>()
                .AddWireDataContext<WireDataContext>()
                .Run();
        }
    }
}
