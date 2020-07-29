using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Category
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Keyword { get; set; }
        #endregion
    }
}
