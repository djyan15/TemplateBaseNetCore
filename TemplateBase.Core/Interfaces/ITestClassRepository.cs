using System;
using System.Collections.Generic;
using System.Text;
using TemplateBase.Core.Entities;

namespace TemplateBase.Core.Interfaces
{
    public interface ITestClassRepository
    {
         IEnumerable<TestClass> GetAll();
    }
}
