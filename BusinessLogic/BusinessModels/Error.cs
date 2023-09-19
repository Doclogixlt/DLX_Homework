

namespace BusinessLogic.BusinessModels
{
	public class Error
	{
		public string errorMessage { get; set; }
		public string exceptionMessage { get; set; }
		public Error(string errorMessage, string exceptionMessage)
		{
			this.errorMessage = errorMessage;
			this.exceptionMessage = exceptionMessage;
		}
	}
}
