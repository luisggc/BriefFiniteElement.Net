﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using BriefFiniteElementNet.Validation;
using Newtonsoft.Json;

namespace BriefFiniteElementNet.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DktElementChecker.Test1();
        }
    }
}
