using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vurilo.Models
{
    public class Search
    {

        [Key]
        public int VideoLength { get; set; }

        [Required]
        public string Categories { get; set; }
   
        [DisplayName("Sub Category")]
        public string Sub_Category { get; set; }
    
        public  string Instructor { get; set; }

        [DisplayName("Class Level")]
        public string Class_Level { get; set; }
       
     

    }
}
