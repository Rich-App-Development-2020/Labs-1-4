﻿using ClubDomain.Classes.ClubModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RAD3012021Week4.ClubDomain.Classes.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        public int AssociatedClub { get; set; }
        public string StudentID { get; set; }
        public bool approved { get; set; }
        [ForeignKey("AssociatedClub")]
        public virtual Club myClub { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student studentMember { get; set; }
    }
}
