using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DuLink.Entities
{
    public class JobOffer
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("JobOfferName")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(15, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String Name
        {
            get;
            set;
        }
        
        [BsonElement("JobOfferSalary")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "This field must only contain numbers")]
        public int Salary
        {
            get;
            set;
        }
        [BsonElement("JobOfferDescription")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(40, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 15)]
        public String Description
        {
            get;
            set;

        }
        [BsonElement("JobOfferContact")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(15, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String Contact
        {
            get;
            set;
        }
        [BsonElement("JobOfferContactPhoneNumber")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "This field must only contain numbers")]
        [StringLength(10, ErrorMessage = "Name must not exceed {1}")]
        public String ContactPhoneNumber
        {
            get;
            set;
        }
        [BsonElement("JobOfferPosition")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(15, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String Position
        {
            get;
            set;
        }
        [BsonElement("JobOfferCompanyName")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(15, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String CompanyName
        {
            get;
            set;
        }

        [BsonElement("JobOfferCareer")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(20, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String Career
        {
            get;
            set;
        }
    }
}