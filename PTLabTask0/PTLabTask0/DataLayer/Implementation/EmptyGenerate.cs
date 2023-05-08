using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class EmptyGenerate: IDataGenerator
    {
        public override void Generate(IDataRepository dataRepository)
        {
        }
    }
}