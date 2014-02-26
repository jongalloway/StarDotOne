using System.ComponentModel.DataAnnotations;

namespace StarDotOne.Models
{
    /// <summary>
    /// This is an example person class. It artisanally crafted by a
    /// bearded, bespeckled craftsman after being lovingly sketched
    /// in a leather bound notebook with charcoal pencils.
    /// </summary>
    public class Person
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        /// <summary>
        /// This uses a custom salution enum since there's apparently no ISO standard.
        /// </summary>
        /// <value>
        /// The person's requested salutation.
        /// </value>
        [UIHint("Enum-radio")]
        public Salutation Salutation { get; set; }
        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "Your {0} must be at least {1} characters long")]
        [MaxLength(100, ErrorMessage = "Your {0} must be no more than {1} characters")]
       public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [MinLength(3, ErrorMessage = "Your {0} must be at least {1} characters long")]
        [MaxLength(100, ErrorMessage = "Your {0} must be no more than {1} characters")]
        public string LastName { get; set; }
        /// <summary>
        /// This is the person's actual or desired age.
        /// </summary>
        /// <value>
        /// The age in years, represented in an integer.
        /// </value>
        public int Age { get; set; }
    }


    /// <summary>
    /// This is our custom Salutation enum. Perhaps we should open source it and distribute
    /// it via NuGet?
    /// </summary>
    public enum Salutation : byte
    {
        [Display(Name = "Mr.")]   Mr,
        [Display(Name = "Mrs.")]  Mrs,
        [Display(Name = "Ms.")]   Ms,
        [Display(Name = "Dr.")]   Doctor,
        [Display(Name = "Prof.")] Professor,
        Sir, 
        Lady, 
        Lord
    }
}