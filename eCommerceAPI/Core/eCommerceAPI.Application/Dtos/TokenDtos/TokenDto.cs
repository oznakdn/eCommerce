﻿namespace eCommerceAPI.Application.Dtos.TokenDtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
