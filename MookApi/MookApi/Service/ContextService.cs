

namespace MookApi.Service
{
    public class ContextService
    {

        public enum ModelName
        {
            Admin = 0,
            Book = 1,
            BookToBuy = 2,
            Comment = 3,
            History = 4,
            RequestDetail = 5,
            RequestHeader = 6,
            Students = 7
        }

        public static string getModelData(string Model)
        {

            switch (Enum.Parse(typeof(ModelName), Model).ToString())
            {
                case "Admin":

                    break;
                case "Book":
                    break;
                case "BookToBuy":
                    break;
                case "Comment":
                    break;
                case "History":
                    break;
                case "RequestDetail":
                    break;
                case "RequestHeader":
                    break;
                case "Students":
                    break;
                default:
                    break;
            }
            return "ok";
        }
    }
}
