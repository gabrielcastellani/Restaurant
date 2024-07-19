using Restaurant.Orders.Common.Abstracts;

namespace Restaurant.Orders.Common.Responses
{
    public class ServerResponse<TModel> : ServerResponse
        where TModel : ModelBase
    {
        public TModel Model { get; private set; }

        public ServerResponse(TModel model)
            : base()
        {
            Model = model;
        }

        public ServerResponse(Exception error)
            : base(error) { }
    }

    public class ServerResponse
    {
        public bool Success { get; private set; }
        public Exception Error { get; private set; }

        public ServerResponse()
        {
            Success = true;
        }

        public ServerResponse(Exception error)
        {
            Error = error;
            Success = false;
        }
    }
}
