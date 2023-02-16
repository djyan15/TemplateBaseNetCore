using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TemplateBase.Core.Entities;
using TemplateBase.Core.Interfaces;

namespace TemplateBase.Infrastructure.Repositories
{
    public class TestClassRepository : ITestClassRepository
    {
        private readonly DBTestContext _context;

        public TestClassRepository(DBTestContext context)
        {
            _context = context;
        }
        public IEnumerable<TestClass> GetAll()
        {
            return _context.TestClass.AsEnumerable();
        }

    }
}
