using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        public String Position
        {
            get;
            set;
        }
        [BsonElement("JobCompanyName")]
        public String CompanyName
        {
            get;
            set;
        }
        [BsonElement("JobStartDate")]
        public DateTime StartDate
        {
            get;
            set;
        }

        [BsonElement("JobEndDate")]
        public DateTime EndDate
        {
            get;
            set;
        }
    }
}