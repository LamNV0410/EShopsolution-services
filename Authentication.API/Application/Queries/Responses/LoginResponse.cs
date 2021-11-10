namespace Authentication.API.Application.Queries.Responses
{
    public class LoginResponse
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Phiên đăng nhập của người dùng
        /// </summary>
        //public string SessionId { get; set; }

        /// <summary>
        /// Ip public của người dùng
        /// </summary>
        //public string PublicIp { get; set; }
        //public int PublicPort { get; set; }
        //public string ClientId { get; set; }
        //public string LocalIp { get; set; }
        //public int LocalPort { get; set; }
    }
}
