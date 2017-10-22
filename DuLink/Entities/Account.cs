using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DuLink.Entities
{
    public class Account
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }
        [BsonElement("EmployeeName")]
        public String Name
        {
            get;
            set;
        }
        [BsonElement("EmployeeLastName")]
        public String LastName
        {
            get;
            set;
        }
        [BsonElement("EmployeeUsername")]
        public String UserName
        {
            get;
            set;
        }
        [BsonElement("EmployeePassword")]
        public String Password
        {
            get;
            set;
        }
        [BsonElement("EmployeeMail")]
        public String Mail
        {
            get;
            set;
        }
        [BsonElement("EmployeeCareer")]
        public String Career
        {
            get;
            set;
        }

        [BsonElement("EmployeeSemester")]
        public String Semester
        {
            get;
            set;
        }


        [BsonElement("EmployeeFriends")]
        public List<String> FriendsList
        {
            get;
            set;
        }

        [BsonElement("EmployeeJobs")]
        public List<String> JobsList
        {
            get;
            set;
        }
    }
}