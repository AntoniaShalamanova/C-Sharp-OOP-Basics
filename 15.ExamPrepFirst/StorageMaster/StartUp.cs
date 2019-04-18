using StorageMaster.Core;
using System;
using System.Collections.Generic;

namespace StorageMaster
{
    using Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new StorageMaster());
            engine.Run();
        }
    }
}
