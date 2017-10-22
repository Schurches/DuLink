using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        public String Name
        {
            get;
            set;
        }
        
        [BsonElement("JobOfferSalary")]
        public int Salary
        {
            get;
            set;
        }
        [BsonElement("JobOfferDescription")]
        public String Description
        {
            get;
            set;

        }
        [BsonElement("JobOfferContact")]
        public String Contact
        {
            get;
            set;
        }
        [BsonElement("JobOfferContactPhoneNumber")]
        public String ContactPhoneNumber
        {
            get;
            set;
        }
        [BsonElement("JobOfferPosition")]
        public String Position
        {
            get;
            set;
        }
        [BsonElement("JobOfferCompanyName")]
        public String CompanyName
        {
            get;
            set;
        }
        [BsonElement("JobOfferStartDate")]
        public String StartDate
        {
            get;
            set;
        }

        [BsonElement("JobOfferEndDate")]
        public String EndDate
        {
            get;
            set;
        }
    }
}