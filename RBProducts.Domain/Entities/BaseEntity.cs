using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBProducts.Domain.Entities
{
    public abstract class BaseEntity<TKey>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { set; get; }
        public bool IsRemovedRecord { set; get; }
    }
}
