namespace Helpers
{

    public class StatusResponse
    {
        // Successful responses (200–299)
        public const int OK = 200;
        public const int Created = 201;
        public const int NoContent = 204;

        // Client error responses (400–499)
        public const int Unauthorized = 401;
        public const int BadRequest = 400;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int Proxy = 407;
        public const int ReqTimeout = 408;

        // Server error responses (500–599)
        public const int InternalServerError = 500;
        public const int BadGateway = 502;
        public const int ServiceUnavailable = 503;
        public const int GatewayTimeout = 504;

    }
}