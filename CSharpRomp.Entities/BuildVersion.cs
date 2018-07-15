using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpRomp.Entities
{
    public partial class BuildVersion
    {
        [Key]
        public byte SystemInformationId { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
