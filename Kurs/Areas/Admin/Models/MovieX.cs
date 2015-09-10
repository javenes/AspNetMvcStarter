using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kurs.Areas.Admin.Models
{

    public class MovieX
    {
        [CustomValidation (typeof(MovieValidatorClass), "NewMovie")]
        [Required]
        [MaxLength(30)]
        public string MovieId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string OriginalTitle { get; set; }

        public string Description { get; set; }

        [MaxLength(4)]
        public string ProductionYear { get; set; }

        public int RunningLengthHour { get; set; }

        public int RunningLengthMinute { get; set; }

        public int GenreId { get; set; }

    }

    public class MovieValidatorClass
    {
        public static ValidationResult NewMovie(string movieId)
        {
            ImdbContext db = new ImdbContext();
            if (db.Movies.Find(movieId) == null)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Filmen finnes fra før");
        }
    }
}