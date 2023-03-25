namespace BTVN_B5_4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Tựa Sách Không Được Để Trống")]
        [StringLength(150, ErrorMessage ="Tựa Sách Có Tối Đa 150 kí tự")]
        public string Title { get; set; }

        [StringLength(150, ErrorMessage ="Tên Tác Giả có tối ta 150 kí tự")]
        public string Author { get; set; }
        [Range(1, 999999999, ErrorMessage ="Giá Sách từ 1 - 999999999")]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
