namespace AlertManager.Application.Models.Requests
{
    public class CreateAlertRequest
    {
        public CreateAlertRequest(string expression)
        {
            Expression = expression;
        }

        public string Expression { get; set; }
    }
}
