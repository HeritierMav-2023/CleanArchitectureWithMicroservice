using Book.Application.DTOs;
using System;


namespace Book.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
