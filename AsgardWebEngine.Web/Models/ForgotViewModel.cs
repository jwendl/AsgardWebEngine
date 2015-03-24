using System.ComponentModel.DataAnnotations;

namespace AsgardWebEngine.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ForgotViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}