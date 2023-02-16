using System;
using System.Collections.Generic;
using System.Text;
using TemplateBase.Core.Entities;
using TemplateBase.Core.Interfaces;

namespace TemplateBase.Core.Services
{
    public class TestClassService : ITestClassService
    {
        private readonly ITestClassRepository _testClassRepository;
        public TestClassService(ITestClassRepository testClassRepository)
        {
            _testClassRepository = testClassRepository;
        }
        public IEnumerable<TestClass> GetTests()
        {
            return _testClassRepository.GetAll();
        }
    }
}
