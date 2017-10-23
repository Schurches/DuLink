using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;

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
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must only contain letters")]
        [StringLength(15, ErrorMessage = "Name must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String Name
        {
            get;
            set;
        }
        [BsonElement("EmployeeLastName")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "This field must only contain letters")]
        [StringLength(50, ErrorMessage = "Last name field must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String LastName
        {
            get;
            set;
        }
        [BsonElement("EmployeeUsername")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Usernames with spaces or @ are not allowed!")]
        [StringLength(15, ErrorMessage = "Username must not exceed {1} characters or be less than {2}", MinimumLength = 4)]
        public String UserName
        {
            get;
            set;
        }
        [BsonElement("EmployeePassword")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "Password must not exceed {1} characters or be less than {2}", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public String Password
        {
            get;
            set;
        }
        [BsonElement("EmployeeMail")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        [StringLength(40, ErrorMessage = "Username must not exceed {1} characters or be less than {2}", MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        public String Mail
        {
            get;
            set;
        }
        [BsonElement("EmployeeCareer")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and white spaces are allowed!")]
        [StringLength(40, ErrorMessage = "Username must not exceed {1} characters or be less than {2}", MinimumLength = 5)]
        public String Career
        {
            get;
            set;
        }

        [BsonElement("EmployeeSemester")]
        [Required(ErrorMessage = "This field is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers only!")]
        [StringLength(2, ErrorMessage = "100+ semesters? please...", MinimumLength = 1)]
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