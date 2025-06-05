using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s.Transaction
{
    public class ReqGetTransactionsByDate
    {
        [Required(ErrorMessage = "@ERROR_ID: IdUserRequired | @ERROR_DESCRIPTION: IdUser is required")]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "@ERROR_ID: StartDateRequired | @ERROR_DESCRIPTION: StartDate is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "@ERROR_ID: EndDateRequired | @ERROR_DESCRIPTION: EndDate is required")]
        public DateTime EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Page Number")]
        public int PageNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (StartDate > EndDate)
            {
                errors.Add(new ValidationResult(
                    "@ERROR_ID: InvalidDateRange | @ERROR_DESCRIPTION: StartDate must be earlier than or equal to EndDate",
                    new[] { nameof(StartDate), nameof(EndDate) }));
            }

            return errors;
        }

    }
}
