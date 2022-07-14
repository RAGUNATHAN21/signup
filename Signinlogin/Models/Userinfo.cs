//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signinlogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Userinfo
    {
        public int userid { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name ="Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "RePassword")]
        [DataType(DataType.Password)] 
        [Notmapped]
        [Compare("Password",ErrorMessage="Password doesn't Match,Try again !")]

        public string Repassword { get; set; }
    }

    internal class NotmappedAttribute : Attribute
    {
    }
}
