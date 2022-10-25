using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.Service.Dto
{
    public class AdvertisementDto
    {
        public string AdvertisementStatus { get; set; }

        public string AdvertisementType { get; set; }  // عادی ، برنزی ، نقره ای ، طلایی 

        public DateTime Date
        {
            get; set;
        }
        public string JobTitle { get; set; }

        public string JobCategory { get; set; }

        public string CooperationType { get; set; }

        public string MilitaryStatusNeed { get; set; }

        public string WorkExperienceNeed { get; set; }

        public string EducationNeed { get; set; }

        public string GenderNeed { get; set; }

        public string CompanyDescription { get; set; }

        public string JobDescription { get; set; }

        public string SkillsNeed { get; set; }

        public string City { get; set; }

        public string Salary { get; set; }

        public bool JobPromotion { get; set; }  // امکان ترفیع سمت

        public bool InsuranceStatus { get; set; } // داشتن بیمه

        public bool Training { get; set; } // دوره های آموزشی حین کار

        public bool Food { get; set; } // ناهار به عهده شرکت

        public bool FlexibleTime { get; set; } // ساعت کاری منعطف یا شناور

        public string ContactForSendRezume { get; set; }
    }
}
