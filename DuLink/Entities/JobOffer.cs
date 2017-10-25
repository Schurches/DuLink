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
        public String Description
        {
            get;
            set;

        }
        [BsonElement("JobOfferContact")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        public String Contact
        {
            get;
            set;
        }
        [BsonElement("JobOfferContactPhoneNumber")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        public String ContactPhoneNumber
        {
            get;
            set;
        }
        [BsonElement("JobOfferPosition")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        public String Position
        {
            get;
            set;
        }
        [BsonElement("JobOfferCompanyName")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        public String CompanyName
        {
            get;
            set;
        }

        [BsonElement("JobOfferCareer")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        public String Career
        {
            get;
            set;
        }


    }
}