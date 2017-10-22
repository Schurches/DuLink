using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DuLink.Entities
{
    public class Jobs
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("JobName")]
        public String Name
        {
            get;
            set;
        }

        [BsonElement("JobEmployeeId")]
        public String EmployeeId
        {
            get;
            set;
        }
        [BsonElement("JobPosition")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [StringLength(50, ErrorMessage = "String length must be greater than {2}", MinimumLength = 4)]
        public String Position
        {
            get;
            set;
        }
        [BsonElement("JobCompanyName")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [StringLength(100, ErrorMessage = "Company name must contain at least {2} characters", MinimumLength = 4)]
        public String CompanyName
        {
            get;
            set;
        }
        [BsonElement("JobStartDate")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public String StartDate
        {
            get;
            set;
        }

        [BsonElement("JobEndDate")]
        [DataType(DataType.Date)]
        public String EndDate
        {
            get;
            set;
        }
    }
}