using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerGreen.Core.Entities
{    
    public class OrgSurveyGoal : BaseEntity
    {
        public long OrgId { get; set; }
        public long SurveyId { get; set; }
        public string Goal { get; set; }
        public double Value { get; set; }
    }
}