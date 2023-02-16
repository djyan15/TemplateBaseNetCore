using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TemplateBase.Core.Entities
{
    public class TestClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        // for create foreign key 
        // [ForeignKey("Id")]
        // for relations 1 to * Virtual ICollection<T> 
        // for relations 1 to 1 Virtual T
        // consider that the classes where you add it is the relationship of one 
    }
}
