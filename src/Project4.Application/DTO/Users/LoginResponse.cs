using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Application.DTO.Users
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = null!;
        public string? Token { get; set; } = null!;
        public GetUserInfo? user {  get; set; }
    }


}
