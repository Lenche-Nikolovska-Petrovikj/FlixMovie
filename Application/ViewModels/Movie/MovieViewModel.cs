using System;
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels.Movie
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Duration In Minutes")]
        public string DurationInMinutes { get; set; }
        [Required]
        [MaxLength(20)]
        public string Genre { get; set; }
        [Required]
        [MaxLength(60)]
        public string Director { get; set; }
        [Required]
        public int InStock { get; set; }
        [Display(Name = "Poster")]
        public string ImageUrl { get; set; }

    }
}
